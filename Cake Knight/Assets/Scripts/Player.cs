using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player inst;
    private void Awake() {
        inst = this;
    }

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
        if (SceneManager.GetActiveScene().name == "FinalLevel") {
            FindObjectOfType<AudioMgr>().PlayBGM("Level3 BG Music");
        } else if (SceneManager.GetActiveScene().name == "Level2") {
            // Play level 2 BGM here
            FindObjectOfType<AudioMgr>().PlayBGM("Level1 BG Music");
        } else {
            FindObjectOfType<AudioMgr>().PlayBGM("Level1 BG Music");
        }
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
        FindObjectOfType<AudioMgr>().StopBGM("Level1 BG Music");
        FindObjectOfType<AudioMgr>().StopBGM("Final Boss Music");
        FindObjectOfType<AudioMgr>().Play("Player Death");
        FindObjectOfType<AudioMgr>().PlayBGM("Death Music");

        // Death menu
        DeathMenuManager.inst.playerDead = true;

        this.enabled = false;
                
    }
    public void TakeDmg(int dmg)
    {
        // Play random damage noise
        StartCoroutine(ColorDamage());
        if (currentHealth > 0) {
            FindObjectOfType<AudioMgr>().PlayDmg();
        }
        currentHealth -= dmg;
        healthbar.SetHealth(currentHealth);
    }
    IEnumerator ColorDamage() {

        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = new Color(0.78f, 0, 0, 1);

        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = new Color(1f, 1f, 1f, 1);


    }
    public void AddHealth(int health) {
        currentHealth += health;
        healthbar.SetHealth(currentHealth);
    }

 }
