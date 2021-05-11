using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UINetworkManager : MonoBehaviour
{
    public WindowManager windowManager;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    // Start is called before the first frame update

    public void LemmeIn()
    {
        StartCoroutine(GetRequest("http://admin:password@52.54.57.136:5984/" +usernameInput.text));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    windowManager.OpenPanel("Character Loading Screen");
                 
                    break;
            }
        }
    }
}
