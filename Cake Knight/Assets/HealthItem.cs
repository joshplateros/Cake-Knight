using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {    
        Destroy(gameObject);
        Player.inst.AddHealth(20);
    }
}
