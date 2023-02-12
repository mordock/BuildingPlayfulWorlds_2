using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTank : MonoBehaviour
{
    public GameObject tankBottom, tankTop;

    public float topSpeed, lowSpeed, currentSpeed, speedIncrease, rotateSpeed, topTankRotateSpeed;

    public int targetFrameRate = 60;

    private Vector2 turn;

    bool increase;
    // Start is called before the first frame update
    void Start() {
        currentSpeed = lowSpeed;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(currentSpeed);
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
            Debug.Log("UP");
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            increase = false;
            currentSpeed = lowSpeed;
        }

        if (Input.GetKey(KeyCode.A)) {
            tankBottom.transform.Rotate(0, -rotateSpeed, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.D)) {
            tankBottom.transform.Rotate(0, rotateSpeed, 0, Space.Self);
        }

        turn.x += Input.GetAxis("Mouse X") * topTankRotateSpeed;

        tankTop.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
