using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    public Button submitButton;



    public void CallLogIN()
    {
        StartCoroutine(LogIN());
    }
    IEnumerator LogIN()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.score = Convert.ToInt32(www.text.Split('\t')[1]);
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("User Login failed. Error #" + www.text);
        }
       

    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length > 0) && (passwordField.text.Length >= 8);
    }


}
