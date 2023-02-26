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

    public delegate void MethodToCall();

    public MethodToCall m_methodToCall;

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

    [Header("End cinematic values")]
    public GameObject endCinematicCam;

    private void Awake() {
        foreach (Transform explosion in explosionObject.transform) {
            explosionParticles.Add(explosion.gameObject);
            explosion.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start() {
        m_methodToCall = StartPlaneCinematic;

        planeGroupObject.SetActive(false);

        randomExplosionTimer = Random.Range(lowExplosionTimer, highExplosionTimer);

        startObjects.SetActive(true);
        endObjects.SetActive(false);
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

        StartCoroutine(DoMethodAfterSeconds(2, m_methodToCall));
    }

    IEnumerator DoMethodAfterSeconds(int secs, MethodToCall currentMethod) {
        yield return new WaitForSeconds(secs);
        currentMethod();
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

        //mainCam.GetComponent<CameraScript>().setReturnOffset = true;
        //mainCam.transform.eulerAngles = new Vector3(
        //    mainCam.transform.eulerAngles.x,
        //    mainCam.transform.eulerAngles.y + 180,
        //    mainCam.transform.eulerAngles.z
        //);
    }

    public void StartEndPart() {
        GetComponent<FadeManager>().fadeToBlackAndBack(2.5f, 1, 1);
        //Camera.main.gameObject.GetComponent<CameraScript>().MoveTowardsPlayer();

        m_methodToCall = StartEndCinematic;
        StartCoroutine(DoMethodAfterSeconds(3, m_methodToCall));
    }

    private void StartEndCinematic() {
        Camera.main.gameObject.SetActive(false);
        endCinematicCam.SetActive(true);

        GetComponent<EndCinematicManager>().endCinematicStarted = true;
    }

    public void SetEndObjects() {
        //switch to different objects
        startObjects.SetActive(false);
        endObjects.SetActive(true);
    }
}
