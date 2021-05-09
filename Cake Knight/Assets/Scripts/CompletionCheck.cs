using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public List<EnemyBehavior> Enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (EnemyBehavior enemy in Enemies) {
            Debug.Log(enemy.currentHealth);
        }
        
    }
}
