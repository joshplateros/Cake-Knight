using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class CakeActivate : MonoBehaviour
{
    public GameObject CakeUI;
    public GameObject Cake;
    public GameObject VictoryCanvas;
    public GameObject Credits;

    public Animator animator;
   
    private void OnTriggerEnter(Collider other) {
        Debug.Log("ACITVATE");
        CakeUI.SetActive(true);

        // Freeze game
        Time.timeScale = 0f;

        // Pause music
        FindObjectOfType<AudioMgr>().StopBGM("Level1 BG Music");

    }
    public void eatCake() {
        Time.timeScale = 1f;
        VictoryCanvas.SetActive(true);
        FindObjectOfType<AudioMgr>().PlayBGM("Cheers");
        FindObjectOfType<AudioMgr>().PlayBGM("CAKE MUSIC");
        Cake.SetActive(false);
        CakeUI.SetActive(false);
        animator.SetTrigger("CAKE");
        StartCoroutine(PlayCredits());

        GetComponent<ThirdPersonCharacter>().enabled = false;
        GetComponent<ThirdPersonUserControl>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;



        // Turn off script
        // this.enabled = false;

    }

    public void noEatCake() { 
        Time.timeScale = 1f;
        CakeUI.SetActive(false);
        FindObjectOfType<AudioMgr>().PlayBGM("Level1 BG Music");
    }


    public IEnumerator PlayCredits() {

        yield return new WaitForSeconds(1f);
        Credits.SetActive(true);
    }
}
