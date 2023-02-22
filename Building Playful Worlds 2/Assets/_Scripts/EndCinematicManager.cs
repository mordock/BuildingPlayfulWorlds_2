using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCinematicManager : MonoBehaviour
{
    public List<int> endConversationIds;
    public GameObject endChoiceUI, endPanel;

    [HideInInspector]
    public bool endCinematicStarted;
    private bool endChoiceOpen, gameEnd;
    // Start is called before the first frame update
    void Start() {
        endCinematicStarted = false;
        endChoiceOpen = false;
        endChoiceUI.SetActive(false);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (endCinematicStarted) {
            if (endConversationIds.Count > 0) {
                GetComponent<ConversationManager>().StartConversation(endConversationIds[0]);
            }

            if(endConversationIds.Count <= 0) {
                GetComponent<ConversationManager>().CloseConversation();
                //show suicide option
                endChoiceOpen = true;
                endChoiceUI.SetActive(true);
            }

            //this is a really botched solution but its quick :)
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (endConversationIds.Count > 0) {
                    endConversationIds.Remove(endConversationIds[0]);
                }
            }
        }

        if (endChoiceOpen) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                endPanel.SetActive(true);
                endPanel.transform.GetChild(0).gameObject.SetActive(true);
                endPanel.transform.GetChild(1).gameObject.SetActive(true);
                gameEnd = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                endPanel.SetActive(true);
                endPanel.transform.GetChild(1).gameObject.SetActive(true);
                endPanel.transform.GetChild(0).gameObject.SetActive(true);
                gameEnd = true;
            }
        }

        if (gameEnd) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                ReturnToStartMenu();
            }
        }
    }

    public void ReturnToStartMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
