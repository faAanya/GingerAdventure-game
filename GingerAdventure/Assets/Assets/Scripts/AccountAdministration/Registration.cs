using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Registration : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;
    public TMP_InputField passwordFieldMatch;

    public Button submitButton;

  

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;


        if(www.text == "0")
        {
            Debug.Log("Successfully created");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error 0" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length > 0) && (passwordField.text.Length >= 8) && (passwordField.text == passwordFieldMatch.text);
    }

}
