using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject shell, shootPoint, testBoom;

    public float minShootTime, maxShootTime;

    private float shootTime;
    private float timePassed = 0;

    private GameObject tankTop;
    private GameObject player;
    private bool moveTurret;

    private Transform oldPlayerPos;
    private bool hasOldPlayerPos;
    // Start is called before the first frame update
    void Start() {
        shootTime = Random.Range(minShootTime, maxShootTime);
        tankTop = transform.GetChild(0).gameObject;
        player = GameObject.Find("Tank");

        moveTurret = true;
        hasOldPlayerPos = false;
    }

    // Update is called once per frame
    void Update() {
        timePassed += Time.deltaTime;
        if (moveTurret) {
            tankTop.transform.LookAt(player.transform, Vector3.up);
            tankTop.transform.Rotate(0, 180, 0);
        }

        if (timePassed > shootTime) {
            Shoot();
            timePassed = 0;
        }

        if(timePassed > shootTime - 1) {
            moveTurret = false;
            if (!hasOldPlayerPos) {
                oldPlayerPos = player.transform;
                hasOldPlayerPos = true;
            }
        }

        if (timePassed < .5f) {
            moveTurret = false;
        }
        if(timePassed >= 0.5f && timePassed <= shootTime - 1) {
            moveTurret = true;
        }
    }

    public void Shoot() {
        shootTime = Random.Range(minShootTime, maxShootTime);
        Instantiate(testBoom, shootPoint.transform);

        GameObject currentShell = Instantiate(shell);
        currentShell.transform.position = shootPoint.transform.position;
        currentShell.transform.LookAt(transform.GetChild(0));
        currentShell.transform.eulerAngles = new Vector3(0, currentShell.transform.eulerAngles.y, 0);
        currentShell.GetComponent<TankShell>().player = player;

        moveTurret = true;
        hasOldPlayerPos = false;
    }
}
