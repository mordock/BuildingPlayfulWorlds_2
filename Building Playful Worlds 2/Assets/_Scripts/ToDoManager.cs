using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToDoManager : MonoBehaviour
{
    public GameObject toDoUI;
    // Start is called before the first frame update
    void Start() {
        UpdateToDo("- Follow the road - \n Patrol the town");
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateToDo(string text) {
        toDoUI.SetActive(true);
        toDoUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    public void CloseToDo() {
        toDoUI.SetActive(false);
    }
}
