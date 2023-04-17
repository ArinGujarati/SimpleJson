using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
public class JsonSignin : MonoBehaviour
{
    public LoginArray loginArray = new LoginArray();
    public TMP_Text AlertText;
    public TMP_InputField InputUsernameSignin, InputPasswordSignin;

    public void Singin()
    {
        string Username = InputUsernameSignin.text;
        string Password = InputPasswordSignin.text;

        string TotalArrayString = File.ReadAllText(Application.persistentDataPath + "/ClassSaveOnJson.json");

        loginArray = JsonUtility.FromJson<LoginArray>(TotalArrayString);                        

        JSONNode nodejson = JSON.Parse(TotalArrayString);

        JSONNode multies = nodejson["loginJsonsList"];
        
        for (int i = 0; i < multies.Count; i++)
        {
            string jsonId = multies[i]["Password"];
            string jsonName = multies[i]["Username"];
            if (Username == jsonName && Password == jsonId)
            {
                AlertText.text = "Login Succesfull";
                return;
            }
            else
            {
                AlertText.text = "Incorect Username And Password";                
            }
        }
    }
}
