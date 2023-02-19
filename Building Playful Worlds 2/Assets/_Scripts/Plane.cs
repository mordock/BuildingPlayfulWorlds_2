using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public bool fly;
    public float speed;
    public GameObject propellor;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (fly) {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        propellor.transform.Rotate(0, 0, 15f);
    }
}
