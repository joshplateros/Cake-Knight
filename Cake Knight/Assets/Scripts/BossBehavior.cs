using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehavior : MonoBehaviour {
    public static BossBehavior inst;
    
    // Enabled when boss is dead
    public GameObject spotLight;
    public GameObject boxes;

    // Health bar
    public Animator animator;
    public HealthBar healthbar;
    public int maxHealth = 100;
    public int currentHealth;

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

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Health bar
    void Start() {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);
        animator.speed = 0.8f;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        animator.SetTrigger("damage");
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        animator.SetBool("isDead", true);
        // animator.SetTrigger("Die");
        GetComponent<Collider>().enabled = false;

        spotLight.SetActive(true);
        boxes.SetActive(false);

        // Set script to off once enemey is dead
        this.enabled = false;
    }



    // Ai movement
    private void Awake() {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        inst = this;
    }

    private void Update() {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) {
            animator.SetBool("Walk", false);

        }
        if (playerInSightRange && !playerInAttackRange) {
            animator.SetBool("Walk", true);
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange) {
            AttackPlayer();
        }
    }


    
    private void ChasePlayer() {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer() {

        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        animator.SetBool("Walk", false);
        // Heading
        transform.LookAt(player);

        if (!alreadyAttacked) {

            /// Attack Code here (guy also has projectile tutorials)
            /// https://www.youtube.com/watch?v=UjkSFoLxesw
            /// 
            WhichAttack();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

    }

    private void dealDamageToPlayer(int extraDmg) {
        Collider[] thePlayer = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, whatIsPlayer);

        // Damage player (Didn't need to be a list but using previous tutorial only used list (can't just use player object)))
        foreach (Collider player in thePlayer) {
            player.GetComponent<Player>().TakeDmg(enemyDamage + extraDmg);
        }
    }

    void Attack1() {
        // Play damage sound here

         FindObjectOfType<AudioMgr>().PlayMob("Thud 1");
         dealDamageToPlayer(0);
    }

    void Attack2() {
         FindObjectOfType<AudioMgr>().PlayMob("Thud 2");
         dealDamageToPlayer(10);
    }


    // Might implement something here
    private void ResetAttack() {
        alreadyAttacked = false;

    }
    void WhichAttack() {
        int num = Random.Range(0, 10);

        if (num < 8) {
            // Play sound here
            animator.SetTrigger("attack_03");
        } else {
            animator.SetTrigger("attack_01");
        }



    }

}
