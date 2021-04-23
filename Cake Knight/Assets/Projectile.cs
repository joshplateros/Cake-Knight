using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    // Projectile
    public GameObject arrow;

    // Force
    public float shootForce, upwardForce;

    // Stats
    public float delay, spread;
    public Camera fpscam;
    public Transform attackPoint;



    // Update is called once per frame
    void Update()
    {
        
    }
}
