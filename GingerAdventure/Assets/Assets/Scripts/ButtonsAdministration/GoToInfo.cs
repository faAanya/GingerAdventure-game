using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToInfo : MonoBehaviour
{
    public void OpenInfo()
    {
        SceneManager.LoadScene(3);
    }
}
