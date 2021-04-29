using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void Start()
    {
        currChatBox = Instantiate(ChatBoxComponent, ChatBoxPos, Quaternion.identity, ParentUIComponent.transform);
        nameField = GameObject.Find("NPC Name").GetComponent<TextMeshProUGUI>();
        textField = GameObject.Find("ConversationText").GetComponent<TextMeshProUGUI>();
        nameField.SetText(NPCName);
        currChatBox.SetActive(false);
        
    }

    public override void Interact()
    {
        if (!interacting)
        {
            
            Debug.Log("Entered");
            currChatBox.SetActive(true);
            interacting = true;

            if (playerStats.clout < 50)
            {
                mainSceneDemoManager.createLowCloutInteraction();
                currInteraction = mainSceneDemoManager.lowCloutInteraction;
            } else
            {
                mainSceneDemoManager.createHighCloutInteraction();
                currInteraction = mainSceneDemoManager.highCloutInteraction;
            }
            
            
        }
        UpdateChatBox();
        
    }

    private void UpdateChatBox()
    {
        if (currInteraction.hasNext())
        {
            textField.SetText(currInteraction.getNextLine());
        } else
        {
            currChatBox.SetActive(false);
            interacting = false;
        }
    }

    public override void Introduce()
    {
        throw new System.NotImplementedException();
    }
}
