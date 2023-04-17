using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;

public class SimpleJsonMulti : MonoBehaviour
{
    public ListOfFirstClass _listOfFirstClass = new ListOfFirstClass();
    public TMP_Text TextOutPut;

   
    #region Json Save Data
    public void SaveData()
    {
        TextOutPut.text = "";
        string jsontextfile = JsonUtility.ToJson(_listOfFirstClass);

        File.WriteAllText(Application.persistentDataPath + "/jsonfilecreat.json", jsontextfile);

        Debug.Log("Json File Created Sucsessfull " + jsontextfile);

        for (int i = 0; i < _listOfFirstClass.listfirstclass.Count; i++)
        {
            TextOutPut.text += $"Name = {_listOfFirstClass.listfirstclass[i].Name} => Id = {_listOfFirstClass.listfirstclass[i].Id}\n";
            //Debug.Log($"Name = {_listOfFirstClass.listfirstclass[i].Name} => Id = {_listOfFirstClass.listfirstclass[i].Id}\n");           
        }

    }
    #endregion 

    #region Json Load Data
    public void LoadData()
    {
        TextOutPut.text = "";
        string JsonFileLoad = File.ReadAllText(Application.persistentDataPath + "/jsonfilecreat.json");

        _listOfFirstClass = JsonUtility.FromJson<ListOfFirstClass>(JsonFileLoad);
       
        Debug.Log(JsonFileLoad);

        for (int i = 0; i < _listOfFirstClass.listfirstclass.Count; i++)
        {
            TextOutPut.text += $"Name = {_listOfFirstClass.listfirstclass[i].Name} => Id = {_listOfFirstClass.listfirstclass[i].Id}\n";
            //Debug.Log($"Name = {_listOfFirstClass.listfirstclass[i].Name} => Id = {_listOfFirstClass.listfirstclass[i].Id}\n");           
        }
    }
    #endregion
}



[System.Serializable]
public class FirstClass
{
    public string Name;
    public int Id;
}
[System.Serializable]
public class ListOfFirstClass
{
    public List<FirstClass> listfirstclass = new List<FirstClass>();
}