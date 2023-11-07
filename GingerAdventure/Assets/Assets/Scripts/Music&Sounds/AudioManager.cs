using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSourse;
    [SerializeField] AudioSource SFXSourse;

    public AudioClip bg;
    public static AudioManager instance;
    private void Awake()
    {
     
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
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            musicSourse.Pause();
        }
    }

    private void Start()
    {
        musicSourse.clip = bg;
        musicSourse.Play();
    }
}
