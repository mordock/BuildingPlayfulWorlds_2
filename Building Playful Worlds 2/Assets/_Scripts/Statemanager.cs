using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public GameObject startObjects, endObjects;
    public enum worldState
    {
        startState,
        endState
    }

    public worldState currentstate = worldState.startState;

    public delegate void StartPlaneDelegate();

    public StartPlaneDelegate m_startPlaneDelegate;

    [Header("Plane cinematic values")]
    public GameObject planeGroupObject;
    public GameObject explosionObject;
    public int lowExplosionTimer;
    public int highExplosionTimer;
    public AudioClip planesClip;
    public GameObject timeline;

    private List<GameObject> explosionParticles = new List<GameObject>();
    private bool startExplosions;
    private float currentExplosionTimer;
    private float randomExplosionTimer;

    private void Awake() {
        foreach (Transform explosion in explosionObject.transform) {
            explosionParticles.Add(explosion.gameObject);
            explosion.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start() {
        m_startPlaneDelegate = StartPlaneCinematic;

        startObjects.SetActive(true);
        endObjects.SetActive(false);
        planeGroupObject.SetActive(false);

        randomExplosionTimer = Random.Range(lowExplosionTimer, highExplosionTimer);
    }

    // Update is called once per frame
    void Update() {
        if (startExplosions) {
            currentExplosionTimer++;
            if (explosionParticles.Count > 0) {
                if (currentExplosionTimer > randomExplosionTimer) {
                    explosionParticles[0].SetActive(true);
                    explosionParticles.Remove(explosionParticles[0]);

                    randomExplosionTimer = Random.Range(lowExplosionTimer, highExplosionTimer);
                    currentExplosionTimer = 0;
                }
            }
        }
    }

    public void ChangeToEndState() {
        currentstate = worldState.endState;

        GetComponent<FadeManager>().fadeToBlackAndBack(1, 1, 1);

        StartCoroutine(DoMethodAfterSeconds(2, m_startPlaneDelegate));

        //switch to different objects
        startObjects.SetActive(false);
        endObjects.SetActive(true);
    }

    IEnumerator DoMethodAfterSeconds(int secs, StartPlaneDelegate startPlane) {
        yield return new WaitForSeconds(secs);
        startPlane();
    }

    private void StartPlaneCinematic() {
        planeGroupObject.SetActive(true);
        startExplosions = true;
        timeline.SetActive(true);

        //play flying planes sound
        AudioSource source = GameObject.Find("AudioPlayer").GetComponent<AudioSource>();
        source.clip = planesClip;
        source.loop = false;
        source.Play();

        //change camera for after cinematic
        GameObject mainCam = Camera.main.gameObject;

        mainCam.GetComponent<CameraScript>().setReturnOffset = true;
        mainCam.transform.eulerAngles = new Vector3(
            mainCam.transform.eulerAngles.x,
            mainCam.transform.eulerAngles.y + 180,
            mainCam.transform.eulerAngles.z
        );
    }
}
