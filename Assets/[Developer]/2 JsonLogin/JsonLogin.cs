using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;



[System.Serializable]
public class LoginJson
{
    public string Username;
    public string Password;
}

[System.Serializable]
public class LoginArray
{
    public List<LoginJson> loginJsonsList = new List<LoginJson>();
}
public class Staticdata
{
    public static int Index
    {
        get => PlayerPrefs.GetInt("Index", 0);
        set => PlayerPrefs.SetInt("Index", value);
    }
}
public class JsonLogin : MonoBehaviour
{
    public TMP_Text AlertText;
    public TMP_InputField InputUsernameLogin, InputPasswordLogin;
    public LoginArray loginArray = new LoginArray();
    public void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        LoginJson jsonlogin = new LoginJson();
        string Username = InputUsernameLogin.text;
        string Password = InputPasswordLogin.text;
        loginArray.loginJsonsList.Add(jsonlogin);
        loginArray.loginJsonsList[Staticdata.Index].Username = Username;
        loginArray.loginJsonsList[Staticdata.Index].Password = Password;
        Staticdata.Index++;

        string ClassSaveOnJson = JsonUtility.ToJson(loginArray);
        File.WriteAllText(Application.persistentDataPath + "/ClassSaveOnJson.json", ClassSaveOnJson);


    }
    public void LoadData()
    {
        string ClassLoadOnJson = File.ReadAllText(Application.persistentDataPath + "/ClassSaveOnJson.json");

        loginArray = JsonUtility.FromJson<LoginArray>(ClassLoadOnJson);

        Debug.Log(ClassLoadOnJson);

    }

}