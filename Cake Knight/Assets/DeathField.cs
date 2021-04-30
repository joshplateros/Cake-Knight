using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player.inst.ObstacleTrap(100);
    }
}
