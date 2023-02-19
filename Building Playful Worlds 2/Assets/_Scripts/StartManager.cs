using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject warningPanel, startMenu;

    private bool warningIsOpen = false;
    // Start is called before the first frame update
    void Start() {
        warningPanel.SetActive(false);
        startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (warningIsOpen) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                StartGame();
            }
        }
    }

    public void GoToWarning() {
        startMenu.SetActive(false);
        warningPanel.SetActive(true);

        warningIsOpen = true;
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
