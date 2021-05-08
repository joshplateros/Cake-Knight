using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    GameObject boss;
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name != "FinalLevel") {
            if (other.CompareTag("Player")) {
                Debug.Log("Trigger");

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
