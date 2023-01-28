using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    public int timeBetweenSpawns = 5;
    
    public int maxEnemies = 20;

    [HideInInspector]
    public static int numberOfEnemies;
    
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
            Enemy enemy = enemyPrefabs[randomIndex].GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.target = GameObject.Find("Player").transform;
                Instantiate(enemy, new Vector3(Random.Range(-35, 43), Random.Range(-41, 43), 0), Quaternion.identity);
                numberOfEnemies++;
            }
        }
    }
}
