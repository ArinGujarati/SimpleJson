using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;

public class MultiJson : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ServerJsonEnum1());
    }
    #region Json Server
    public TMP_Text ServerJosnOutPut;   
    public string url = "https://aeringujarati.000webhostapp.com/JsonServerOld.json";
    IEnumerator ServerJsonEnum1()
    {
        //WWW _wWW1 = new WWW(url);
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.error == null)
        {
            JSONNode JsonValues = JSON.Parse(unityWebRequest.downloadHandler.text);
            string JsonValuesId = JsonValues["id"];
            string JsonValuesTitle = JsonValues["title"];
            ServerJosnOutPut.text = "Player Titel Is = " + JsonValuesTitle + "\n" + "Player Id Is = " + JsonValuesId+ "\n";
        }
        else
        {
            Debug.Log("Not Conected !");
        }
    }
    #endregion
}
