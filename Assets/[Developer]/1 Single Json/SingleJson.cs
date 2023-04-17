using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class jsondata
{
    public int age;
    public string name;
}

public class SingleJson : MonoBehaviour
{
    public TMP_InputField InputName, InputAge;
    public TMP_Text TextOutPut;


    #region Json Save Data
    public void SaveData()
    {
        jsondata jsondata = new jsondata();

        jsondata.name = InputName.text;
        jsondata.age = int.Parse(InputAge.text);

        string jsontextfile = JsonUtility.ToJson(jsondata);

        File.WriteAllText(Application.persistentDataPath + "/jsonfilecreat.json", jsontextfile);

        Debug.Log("Json File Created Sucsessfull " + jsontextfile);

        TextOutPut.text = "Name Is : " + jsondata.name + "\n" + "Age Is : " + jsondata.age + "\n";

    }
    #endregion 

    #region Json Load Data
    public void LoadData()
    {

        string JsonFileLoad = File.ReadAllText(Application.persistentDataPath + "/jsonfilecreat.json");

        jsondata jsondata = JsonUtility.FromJson<jsondata>(JsonFileLoad);

        TextOutPut.text = "Name Is : " + jsondata.name + "\n" + "Age Is : " + jsondata.age + "\n";

        Debug.Log(JsonFileLoad);
    }
    #endregion
}
