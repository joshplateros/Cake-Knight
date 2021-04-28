using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour
{
    public static bool isPlayerDead = false; // TO PREVENT PAUSE MENU USE

    public GameObject deathMenuUi;
    public GameObject healthBar;

    public bool playerDead = false; // FOR TESTING PURPOSES

    // Update is called once per frame
    void Update()
    {
        if (playerDead)
        {
            deathMenuUi.SetActive(true);
            healthBar.SetActive(false);
            isPlayerDead = true;
        }
        else
        {
            deathMenuUi.SetActive(false);
            healthBar.SetActive(true);
            isPlayerDead = false;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
}