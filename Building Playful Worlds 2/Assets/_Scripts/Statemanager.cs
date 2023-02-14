using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public GameObject startObjects, endObjects;
    public enum worldState
    {
        startState,
        endState
    }

    public worldState currentstate = worldState.startState;
    // Start is called before the first frame update
    void Start()
    {
        startObjects.SetActive(true);
        endObjects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToEndState() {
        currentstate = worldState.endState;

        startObjects.SetActive(false);
        endObjects.SetActive(true);
    }
}
