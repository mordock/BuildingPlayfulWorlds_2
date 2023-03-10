using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public GameObject tankTop;
    public List<ParticleSystem> particlesOnDrive;

    public float topSpeed, startSpeed, currentSpeed, speedIncrease, tankRotateSpeed, topTankRotateSpeed;

    [Header("use when UI is open")]
    public bool canDrive = true;

    private Vector2 turn;

    private bool increase;

    private void Awake() {
        canDrive = true;
    }

    // Start is called before the first frame update
    void Start() {
        currentSpeed = startSpeed;

        foreach (ParticleSystem particle in particlesOnDrive) {
            particle.Stop();
        }
    }

    // Update is called once per frame
    void Update() {
        if (canDrive) {
            if (increase) {
                if (currentSpeed < topSpeed) {
                    currentSpeed += speedIncrease;
                }
            }

            if (Input.GetKey(KeyCode.W)) {
                Drive(-currentSpeed);
            }
            if (Input.GetKey(KeyCode.S)) {
                Drive(currentSpeed);
            }

            if (Input.GetKeyUp(KeyCode.W)) {
                StopDrive();
            }
            if (Input.GetKeyUp(KeyCode.S)) {
                StopDrive();
            }

            if (Input.GetKey(KeyCode.A)) {
                gameObject.transform.Rotate(0, -tankRotateSpeed, 0, Space.Self);
            }

            if (Input.GetKey(KeyCode.D)) {
                gameObject.transform.Rotate(0, tankRotateSpeed, 0, Space.Self);
            }

            turn.x += Input.GetAxis("Mouse X") * topTankRotateSpeed;

            tankTop.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        }
    }

    void ActivateParticles() {
        foreach (ParticleSystem particle in particlesOnDrive) {
            particle.Emit(1);
            particle.Play();
        }
    }

    void Drive(float speed) {
        gameObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        increase = true;

        ActivateParticles();

        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying) {
            GetComponent<AudioSource>().Play();
        }
    }

    void StopDrive() {
        increase = false;
        currentSpeed = startSpeed;

        foreach (ParticleSystem particle in particlesOnDrive) {
            particle.Stop();
        }

        GetComponent<AudioSource>().Stop();
    }
}
