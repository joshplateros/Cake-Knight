using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public GameObject player;
    public int itemHealth;
    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.Find("Player");
        int curr = player.GetComponent<Player>().currentHealth;
        int maxH = player.GetComponent<Player>().maxHealth;
        // Prevents getting more health than maxhealth
        if (curr < maxH) {
            FindObjectOfType<AudioMgr>().Play("Nom");
            int difference = maxH - curr;
            
            // Ex current health is 95, add 5 hp to currentHealth 
            if (itemHealth > difference) {
                Destroy(gameObject);
                player.GetComponent<Player>().AddHealth(difference);

            // Ex current health is 50, add itemHealth
            } else {
                Destroy(gameObject);
                player.GetComponent<Player>().AddHealth(itemHealth);
            }
        }
    }
}
