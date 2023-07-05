using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button8) || Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }
    }

}
