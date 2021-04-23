using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMgr : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public LayerMask whatIsPlayer;

    //Damage
    public int damage;
    public float attackRange;

    private void Start()
    {

    }

    private void Update()
    {
    }

    private void DealDMG()
    {
        //Check for player 
        Collider[] thePlayer = Physics.OverlapSphere(transform.position, attackRange, whatIsPlayer);

        // Damage player (Didn't need to be a list but using previous tutorial only used list (can't just use player object)))
        foreach (Collider player in thePlayer)
        {
            player.GetComponent<Player>().TakeDmg(damage);
        }

        //Add a little delay, just to make sure everything works fine
        Invoke("Delay", 0.05f);
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) DealDMG();
    }
}
