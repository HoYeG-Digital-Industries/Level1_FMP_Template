using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemies;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0.1f, 2f);    
    }

    void SpawnEnemies(){
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform);
        
    }

    
}
