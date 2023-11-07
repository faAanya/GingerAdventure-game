using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAccountInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    //[SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (DBManager.loggedIn)
        {
            nameText.text = DBManager.username;
            //scoreText.text = Convert.TDBManager.score;

        }
    }

}
