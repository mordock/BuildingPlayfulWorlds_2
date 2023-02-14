using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateObject : MonoBehaviour
{
    public GameObject objectToSwitchTo;

    private Statemanager stateManager;
    // Start is called before the first frame update
    void Start() {
        stateManager = GameObject.Find("GameManager").GetComponent<Statemanager>();
    }

    // Update is called once per frame
    void Update() {
        if (stateManager.currentstate.Equals(Statemanager.worldState.endState)) {

        }
    }
}
