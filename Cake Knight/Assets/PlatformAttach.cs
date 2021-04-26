using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody p;

    private void Update() {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerStay(Collider other) {
            if (p.velocity == Vector3.zero) {
                Player.transform.parent = transform;
            } else {
                Player.transform.parent = null;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }



}
