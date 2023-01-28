using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    public int timeBetweenSpawns = 5;
    
    public int maxEnemies = 20;
    private int numberOfEnemies;

    private float timeSinceLastSpawn = 0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
    }
    
    void SpawnEnemy()
    {
        if (numberOfEnemies < maxEnemies)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], new Vector3(Random.Range(-35, 43), Random.Range(-41, 43), 0), Quaternion.identity);
            numberOfEnemies++;
        }
    }
}
