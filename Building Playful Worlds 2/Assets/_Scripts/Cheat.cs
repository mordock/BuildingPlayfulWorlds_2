using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public GameObject player;
    public Vector3 teleportPlace;
    public Vector3 endTeleportPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            player.transform.position = teleportPlace;
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            player.transform.position = endTeleportPlace;
        }
    }
}
