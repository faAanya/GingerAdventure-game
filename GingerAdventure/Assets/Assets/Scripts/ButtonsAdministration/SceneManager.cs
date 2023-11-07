using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
