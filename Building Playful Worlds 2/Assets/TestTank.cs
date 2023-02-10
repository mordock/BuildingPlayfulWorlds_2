using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTank : MonoBehaviour
{
    public GameObject tankBottom, tankTop;

    public float topSpeed, lowSpeed, currentSpeed, speedIncrease, rotateSpeed, topTankRotateSpeed;

    private Vector2 turn;

    bool increase;
    // Start is called before the first frame update
    void Start() {
        currentSpeed = lowSpeed;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (increase) {
            if (currentSpeed < topSpeed) {
                currentSpeed += speedIncrease;
            }
        }

        if (Input.GetKey(KeyCode.W)) {
            tankBottom.transform.Translate(new Vector3(0, 0, -currentSpeed * Time.deltaTime));
            increase = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            tankBottom.transform.Translate(new Vector3(0, 0, currentSpeed * Time.deltaTime));
            increase = true;
        }

        if (Input.GetKeyUp(KeyCode.W)) {
            increase = false;
            currentSpeed = lowSpeed;
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            increase = false;
            currentSpeed = lowSpeed;
        }

        if (Input.GetKey(KeyCode.A)) {
            tankBottom.transform.Rotate(0, -rotateSpeed, 0, Space.Self);
            Debug.Log("meep");

        }

        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("bees");
            tankBottom.transform.Rotate(0, rotateSpeed, 0, Space.Self);
        }

        turn.x += Input.GetAxis("Mouse X") * topTankRotateSpeed;

        tankTop.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
