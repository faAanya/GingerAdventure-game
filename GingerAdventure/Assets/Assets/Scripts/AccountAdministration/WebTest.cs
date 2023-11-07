using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WebTest : MonoBehaviour
{
    IEnumerator StartTest()
    {
        UnityWebRequest request = new UnityWebRequest("http://localhost/sqlconnect/webtest.php");
        yield return request;
        Debug.Log(request.result);
    }
}
