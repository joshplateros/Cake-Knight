using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthBonus = 15;

    void Awake()
    {
        GetComponent<Player>().healthbar = FindObjectOfType<HealthBar>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(GetComponent<Player>().currentHealth < GetComponent<Player>().maxHealth)
        {
            Destroy(gameObject);
            GetComponent<Player>().currentHealth = GetComponent<Player>().currentHealth + healthBonus; 
        }
    }
}
