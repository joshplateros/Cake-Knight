using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyBehavior : MonoBehaviour
{
    // Health bar
    public Animator animator;
    public HealthBar healthbar;
    public int maxHealth = 100;
    int currentHealth;

    // Enemy damage
    public int enemyDamage = 20;
    public Transform enemyAttackPoint;

    // Agent is the enemy AI
    public NavMeshAgent agent;
    public Transform player;

    // Getting ground and player masks
    public LayerMask whatIsGround, whatIsPlayer;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacks
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Health bar
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Take Damage");
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        // animator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;

        // Set script to off once enemey is dead
        this.enabled = false;
    }



    // Ai movement
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("Walk Forward", true);
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("Walk Forward", false);
            animator.SetBool("Run Forward", true);
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {

        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        // Stop running animation
        animator.SetBool("Run Forward", false);
        // Heading
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);

            animator.SetTrigger("Attack 01");

            /// Attack Code here (guy also has projectile tutorials)
            /// https://www.youtube.com/watch?v=UjkSFoLxesw
            /// 
            //dealDamageToPlayer();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void dealDamageToPlayer()
    {
        Collider[] thePlayer = Physics.OverlapSphere(transform.position, attackRange, whatIsPlayer);
        
        // Damage player (Didn't need to be a list but using previous tutorial only used list (can't just use player object)))
        foreach (Collider player in thePlayer)
        {
            player.GetComponent<Player>().TakeDmg(enemyDamage);
        }

        
    }

    // Might implement something here
    private void ResetAttack()
    {
        alreadyAttacked = false;

    }


}

