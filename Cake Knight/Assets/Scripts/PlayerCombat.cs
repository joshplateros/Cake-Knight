using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public Transform attackPoint;
    public Rigidbody m_rigidbody;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public LayerMask enemyLayers;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    float nextRollTime = 0f;
    float rollRate = 1f;

    // float playerAttackCooldown = 1f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update() {

        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.L)) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if (Time.time >= nextRollTime) {
            if (Input.GetKeyDown(KeyCode.J)) {
                Roll();
                nextRollTime = Time.time + 1f / rollRate;
            }
        }
        // Maybe implement
        // if (Input.GetKey(KeyCode.LeftShift)) {
        //    animator.SetTrigger("Block");
        //}

    }

    void Roll() {
        animator.SetTrigger("Roll");
    }

    void Attack() {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.SetTrigger("Attack 2");
        } else if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack 2")) {
            animator.SetTrigger("Attack 3");
        } else {
            animator.SetTrigger("Attack");
        }


       
    }

    void DealDamage(int addedDmg) {
        // Detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider enemy in hitEnemies) {
            enemy.GetComponent<EnemyBehavior>().TakeDamage(attackDamage + addedDmg);
        }
    }
    
    // Special functions to sync animation with attack
    void Attack1() {
        DealDamage(0);
    }

    void Attack2() {
        DealDamage(0);
    }
    void Attack3() {
        DealDamage(10);
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
