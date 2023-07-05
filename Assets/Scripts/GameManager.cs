using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public bool gameIsOn {get; private set;} = true;
    public GameObject gameOverUIPanel;

    private void Start() {
        gameOverUIPanel.SetActive(false);
    }

    public void GameOver() {
        gameIsOn = false;
        gameOverUIPanel.SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Joystick1Button8) || Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(0);
        }
    }

}