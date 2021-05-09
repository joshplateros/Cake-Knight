using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public static LevelControl inst;
    public GameObject boxes;
    public GameObject spotLight;

    public void Awake() {
        inst = this;
    }

    public void Start() {
        deadEnemies = 0;
    }

    public int numEnemies;
    GameObject boss;
    public bool doorOpen = false;
    public int deadEnemies;

    public void Update() {
        if (deadEnemies == numEnemies) { 
            doorOpen = true;
            boxes.SetActive(false);
            spotLight.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name != "FinalLevel") {
            if (doorOpen == true) {
                if (other.CompareTag("Player")) {
                    Debug.Log("Trigger");

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }



        } else if (SceneManager.GetActiveScene().name == "FinalLevel") {
            boss = GameObject.Find("Boss");
            int curr = boss.GetComponentInChildren<BossBehavior>().currentHealth;
     
            if (curr <= 0) {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
