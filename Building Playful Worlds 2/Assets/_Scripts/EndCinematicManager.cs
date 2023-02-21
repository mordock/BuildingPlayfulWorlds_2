using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCinematicManager : MonoBehaviour
{
    public List<int> endConversationIds;

    [HideInInspector]
    public bool endCinematicStarted;
    // Start is called before the first frame update
    void Start() {
        endCinematicStarted = false;
    }

    // Update is called once per frame
    void Update() {
        if (endCinematicStarted) {
            if (endConversationIds.Count > 0) {
                GetComponent<ConversationManager>().StartConversation(endConversationIds[0]);
            } else {
                //show suicide option
            }

            //this is a really botched solution but its quick :)
            if (Input.GetKeyDown(KeyCode.Space)) {
                endConversationIds.Remove(endConversationIds[0]);
            }
        }
    }
}
