using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel1 : MonoBehaviour
{
    private AudioSource finishSound;
    public string levelName;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            finishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
