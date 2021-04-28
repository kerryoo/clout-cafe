using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.SceneManagement;

public class DemoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DisplayTag;
    [SerializeField] WindowManager windowManager;
    [SerializeField] string nextWindowName;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTag.SetText("Logging you in...");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            setNextText();
        }
    }

    void setNextText()
    {
        switch (count)
        {
            case 0:
                DisplayTag.SetText("Logged in!");
                break;
            case 1:
                DisplayTag.SetText("No characters found...");
                break;
            case 2:
                DisplayTag.SetText("Please create a character!");
                break;
            default:
                windowManager.OpenPanel(nextWindowName);
                break;
        }
        count++;
    }

    public void enterMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
