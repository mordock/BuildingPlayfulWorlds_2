using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGroup : MonoBehaviour
{
    public List<GameObject> planeGroups;

    public float planeSpeed;
    // Start is called before the first frame update
    void Start() {
        foreach(GameObject planeGroup in planeGroups) {
            foreach(Transform plane in planeGroup.transform) {
                plane.gameObject.GetComponent<Plane>().speed = planeSpeed;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
