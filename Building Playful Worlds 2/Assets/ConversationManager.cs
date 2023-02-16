using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    public List<Conversation> conversations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartConversation(int currentId) {
        //get correct conversation
        Conversation conversationToPlay;
        foreach(Conversation conversation in conversations) {
            if (conversation.id.Equals(currentId)) {
                conversationToPlay = conversation;
                break;
            }
        }
    }
}
