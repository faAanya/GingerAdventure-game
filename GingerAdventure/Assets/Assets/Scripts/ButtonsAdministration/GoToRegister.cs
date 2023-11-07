using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRegister : MonoBehaviour
{
    public void OpenRegister()
    {
        SceneManager.LoadScene(4);
    }
}
