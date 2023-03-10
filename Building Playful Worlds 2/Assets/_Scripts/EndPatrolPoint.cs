using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPatrolPoint : MonoBehaviour
{
    public bool retreating;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (!triggered) {
            if (other.gameObject.tag.Equals("Player")) {
                if (retreating) {
                    GameObject.Find("GameManager").GetComponent<Statemanager>().StartEndPart();
                } else {
                    GameObject.Find("GameManager").GetComponent<Statemanager>().ChangeToEndState();
                }
                triggered = true;
            }
        }
    }
}
