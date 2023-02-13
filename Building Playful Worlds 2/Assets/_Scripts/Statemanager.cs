using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public enum worldState
    {
        startState,
        endState
    }

    public worldState currentstate = worldState.startState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToEndState() {
        currentstate = worldState.endState;
    }
}
