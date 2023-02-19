using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationManager : MonoBehaviour
{
    public List<Conversation> conversations;
    public GameObject conversationUI;
    public GameObject audioPlayer;

    private bool conversationIsOpen;
    private TankMovement player;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TankMovement>();
        conversationIsOpen = false;
        conversationUI.SetActive(false);
        StartConversation(1);
    }

    // Update is called once per frame
    void Update() {
        if (conversationIsOpen) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                player.canDrive = true;
                CloseConversation();
            }
        }
    }

    public void StartConversation(int currentId) {
        player.canDrive = false;
        conversationIsOpen = true;
        //get correct conversation
        Conversation conversationToPlay = ScriptableObject.CreateInstance<Conversation>();
        foreach (Conversation conversation in conversations) {
            if (conversation.id.Equals(currentId)) {
                conversationToPlay = conversation;
                break;
            }
        }

        AudioSource source = audioPlayer.GetComponent<AudioSource>();
        if (conversationToPlay.audioFragmant != null) {
            source.clip = conversationToPlay.audioFragmant;
            source.loop = false;
            source.Play();
        }

        conversationUI.SetActive(true);

        conversationUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = conversationToPlay.speakerName;
        conversationUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = conversationToPlay.textEnglish;
    }

    public void CloseConversation() {
        conversationUI.SetActive(false);
        conversationIsOpen = false;
    }
}
