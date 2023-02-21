using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject tank;

    public Vector3 offset;
    public Vector3 returnOffset;

    public float cameraMoveSpeed;

    [HideInInspector]
    public bool setReturnOffset = false;

    private bool moveToPlayer;
    // Start is called before the first frame update
    void Start() {
        setReturnOffset = false;
    }

    // Update is called once per frame
    void Update() {
        if (moveToPlayer) {
            float step = cameraMoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, tank.transform.position, step);
        } else {
            if (!setReturnOffset) {
                transform.position = new Vector3(tank.transform.position.x, transform.position.y, tank.transform.position.z) + offset;
            } else {
                transform.position = new Vector3(tank.transform.position.x, transform.position.y, tank.transform.position.z) + returnOffset;
            }
        }
    }

    public void MoveTowardsPlayer() {
        moveToPlayer = true; ;
    }
}
