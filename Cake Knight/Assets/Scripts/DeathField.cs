using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    public int TrapDmg;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.Find("Player");
        player.GetComponent<Player>().TakeDmg(TrapDmg);
    }
}
