using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject tank;

    public Vector3 offset;
    public Vector3 returnOffset;

    [HideInInspector]
    public bool setReturnOffset = false;
    // Start is called before the first frame update
    void Start() {
        setReturnOffset = false;
    }

    // Update is called once per frame
    void Update() {
        if (!setReturnOffset) {
            transform.position = new Vector3(tank.transform.position.x, transform.position.y, tank.transform.position.z) + offset;
            Debug.Log("1");
        } else {
            transform.position = new Vector3(tank.transform.position.x, transform.position.y, tank.transform.position.z) + returnOffset;
            Debug.Log("2");
        }
    }
}
