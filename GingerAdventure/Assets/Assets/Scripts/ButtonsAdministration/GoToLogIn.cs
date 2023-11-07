using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLogIn : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenLogIn()
    {
        SceneManager.LoadScene(5);
    }
}
