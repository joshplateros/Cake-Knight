using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour
{
   
    public int maxHealth = 100;
    public int currentHealth = 100;

    public GameObject mainPlayer;
    public Animator animator;
    public Rigidbody m_rigidbody;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);
        FindObjectOfType<PlayerAudioMgr>().PlayBGM("Level1 BG Music");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TakeDmg(20);
        }
        if (currentHealth <= 0) {
            Die();
        }

    }
    void Die() {
        animator.SetTrigger("Die");

        // Deactivating all scripts when character is dead
        GetComponent<ThirdPersonCharacter>().enabled = false;
        GetComponent<ThirdPersonUserControl>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;

        m_rigidbody.velocity = Vector3.zero;

        // Death noise
        FindObjectOfType<PlayerAudioMgr>().StopBGM("Level1 BG Music");
        FindObjectOfType<PlayerAudioMgr>().Play("Player Death");
        FindObjectOfType<PlayerAudioMgr>().PlayBGM("Death Music");

        // Death menu
        DeathMenuManager.inst.playerDead = true;

        this.enabled = false;

        // Have restart button here
                
    }
    public void TakeDmg(int dmg)
    {
        // Play random damage noise
        if (currentHealth > 0) {
            FindObjectOfType<PlayerAudioMgr>().PlayDmg();
        }
        currentHealth -= dmg;
        healthbar.SetHealth(currentHealth);
    }
}
