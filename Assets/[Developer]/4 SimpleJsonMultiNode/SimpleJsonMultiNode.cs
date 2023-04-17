using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;

public class SimpleJsonMultiNode : MonoBehaviour
{
    public ListOfFirstClassNode _listOfFirstClassNode = new ListOfFirstClassNode();
    public TMP_Text TextOutPut;

    private void Start()
    {

        string TotalArrayString = JsonUtility.ToJson(_listOfFirstClassNode);
        //File.WriteAllText(Application.persistentDataPath + "/jsonfilecreatNode.json", TotalArrayString);
        Debug.Log("Json File Created Sucsessfull " + TotalArrayString);


        JSONNode nodejson = JSON.Parse(TotalArrayString);
        JSONNode multies = nodejson["secoundClassNode"];

        for (int i = 0; i < multies.Count; i++)
        {
            string jsonId = multies[i]["Id"];
            string jsonName = multies[i]["Name"];           
            TextOutPut.text += "Name Is : " + jsonName + "\n" + "Id Is : " + jsonId + "\n";           
        }
    }

}



[System.Serializable]
public class FirstClassNode
{
    public string Name;
    public int Id;
}
[System.Serializable]
public class SecoundClassNode
{
    public string Name;
    public int Id;
}
[System.Serializable]
public class ListOfFirstClassNode
{
    public List<FirstClass> listfirstclassnode = new List<FirstClass>();
    public List<SecoundClassNode> secoundClassNode = new List<SecoundClassNode>();
}