using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public LayerMask enemyLayers;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

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

    }

    void Attack() {
        animator.SetTrigger("Attack");

        // Detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider enemy in hitEnemies) {
            enemy.GetComponent<EnemyBehavior>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
