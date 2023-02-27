using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(playerHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        healthText.text = "Health: " + playerHealth.ToString();
    }

    public void ReduceHealth() {
        playerHealth--;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Shell")) {
            ReduceHealth();
            Destroy(other.gameObject);
        }
    }

}
