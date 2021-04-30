using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.UI;

public class KatieNetes : NPC
{
    public override string NPCName
    {
        get
        {
            return "Katie Netes";
        }
    }


    private bool interacting = false;
    private GameObject currChatBox;
    private TextMeshProUGUI nameField;
    private TextMeshProUGUI textField;
    private Interaction currInteraction;


    [SerializeField] PlayerStats playerStats;
    [SerializeField] MainSceneDemoManager mainSceneDemoManager;
    [SerializeField] NotificationManager notificationManager;
    [SerializeField] TextMeshProUGUI notificationTitle;
    [SerializeField] TextMeshProUGUI notificationDescription;

    private GameObject firstObj;
    private GameObject secondObj;
    private Button firstOption;
    private Button secondOption;

    private ButtonManager firstOpt;
    private ButtonManager secondOpt;

    private ButtonManager a;

    private bool flag = false;

    private void Start()
    {
        currChatBox = Instantiate(ChatBoxComponent, ChatBoxPos, Quaternion.identity, ParentUIComponent.transform);
        nameField = GameObject.Find("NPC Name").GetComponent<TextMeshProUGUI>();
        textField = GameObject.Find("ConversationText").GetComponent<TextMeshProUGUI>();
        firstObj = GameObject.Find("FirstOption");
        secondObj = GameObject.Find("SecondOption");

        firstOpt = firstObj.GetComponent<ButtonManager>();
        secondOpt = secondObj.GetComponent<ButtonManager>();

        firstOption = firstObj.GetComponent<Button>();
        secondOption = secondObj.GetComponent<Button>();
        firstObj.SetActive(false);
        secondObj.SetActive(false);

        nameField.SetText(NPCName);
        currChatBox.SetActive(false);
        
    }

    public override void Interact()
    {
        if (!interacting)
        {
            currChatBox.SetActive(true);
            interacting = true;
            mainSceneDemoManager.refresh();

            if (!playerStats.metKatie && playerStats.clout < 50)
            {
                currInteraction = mainSceneDemoManager.lowCloutInteraction;
                playerStats.metKatie = true;
                notificationTitle.SetText("That didn't go well.");
                notificationDescription.SetText("Maybe you should have a better reputation before trying that again!");
            } else if (playerStats.clout < 50)
            {
                currInteraction = mainSceneDemoManager.lowCloutMetInteraction;
                notificationTitle.SetText("That didn't go well.");
                notificationDescription.SetText("You really should have a better reputation before trying that again!");
            } else if (playerStats.metKatie)
            {
                currInteraction = mainSceneDemoManager.highCloutMetInteraction;
                notificationTitle.SetText("Katie likes you more!");
                notificationDescription.SetText("You'll be friends in no time!");

            } else
            {
                currInteraction = mainSceneDemoManager.highCloutInteraction;
                notificationTitle.SetText("You just met Katie!");
                notificationDescription.SetText("Hopefully the two of you can become friends!");
                playerStats.metKatie = true;
            }
            
            
        }
        UpdateChatBox();
        
    }

    private void UpdateChatBox()
    {
        if (currInteraction.hasNext())
        {
            textField.SetText(currInteraction.getNextLine());
        } else if (!flag)
        {
            textField.SetText("");
            firstObj.SetActive(true);
            secondObj.SetActive(true);
            firstObj.GetComponent<ButtonManager>().buttonText = currInteraction.options[1];
            secondObj.GetComponent<ButtonManager>().buttonText = currInteraction.options[0];

            firstOption.onClick.AddListener(delegate { close();});
            secondOption.onClick.AddListener(delegate { close(); });
            flag = true;
        } else
        {
            close();
        }
    }

    private void close()
    {
        currChatBox.SetActive(false);
        firstObj.SetActive(false);
        secondObj.SetActive(false);
        flag = false;
        interacting = false;
        notificationManager.OpenNotification();
    }

    public override void Introduce()
    {
        throw new System.NotImplementedException();
    }
}
