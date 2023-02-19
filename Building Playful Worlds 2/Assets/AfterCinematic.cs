using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCinematic : MonoBehaviour
{
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.Find("GameManager");

        gameManager.GetComponent<ConversationManager>().StartConversation(2);
    }

    // Update is called once per frame
    void Update() {

    }
}
