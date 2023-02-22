using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShell : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private Vector3 forward;
    // Start is called before the first frame update
    void Start() {
        forward = Vector3.forward;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(forward * Time.deltaTime * speed);
    }
}
