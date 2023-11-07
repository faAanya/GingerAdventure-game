using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSourse;
    [SerializeField] AudioSource SFXSourse;
    private GameObject startMenu;

    public AudioClip bg;
    public static AudioManager instance;
    private void Awake()
    {
        if (startMenu)
        {
            musicSourse.playOnAwake = false;
        }


        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
     
    }

    private void Start()
    {
        musicSourse.clip = bg;
        musicSourse.Play();
    }
}
