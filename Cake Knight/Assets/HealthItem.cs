using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    int healthBonus = 15; 

    private void OnTriggerEnter(Collider other)
    {    
        Destroy(gameObject);
        Player.inst.AddHealth(healthBonus);
    }
}
