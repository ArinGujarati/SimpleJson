using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;




public class MultiJsonManyy : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(multiJson());
    }
    #region Json Multi
    public TMP_Text TextOutPutMulti;
    public string urlmulti = "https://mocki.io/v1/ccb76f9f-7bd2-465f-937d-4114aadfa2e1";
    IEnumerator multiJson()
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(urlmulti);
        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.error == null)
        {

            JSONNode nodejson = JSON.Parse(unityWebRequest.downloadHandler.text);
            JSONNode multies = nodejson["jsonMulties"];

            for (int i = 0; i < multies.Count; i++)
            {
                string jsonId = multies[i]["id"];
                string jsonName = multies[i]["name"];
                //string jsonId2 = multies["jsonMulties2"][i]["id"];
                //string jsonName2 = multies["jsonMulties2"][i]["name"];
                TextOutPutMulti.text += "Name Is : " + jsonName + "\n" + "Id Is : " + jsonId + "\n";
                //Debug.Log(jsonId + " :: "+ jsonName + " :: "+ jsonId2 + " :: " + jsonName2);
            }

        }
        else
        {
            Debug.Log(" WWW Not Loaded...");
        }


    }
    public void JsonMultiLoad()
    {
        StartCoroutine(multiJson());
    }
    public void MultiServerClicik()
    {
        Application.OpenURL(urlmulti);
    }
    #endregion
}
