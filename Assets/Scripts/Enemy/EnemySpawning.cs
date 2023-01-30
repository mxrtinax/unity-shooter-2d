using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    public int secBetweenSpawns = 5;

    private int maxEnemiesWave = 5;
    public int maxEnemyNumber = 20;
    
    [HideInInspector]
    public static int numberOfEnemies;
    private static int numberOfWaveEnemiesKilled = 0;


    private float timeSinceLastSpawn = 0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (timeSinceLastSpawn >= secBetweenSpawns)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }

        if (numberOfWaveEnemiesKilled >= maxEnemiesWave)
        {
            maxEnemiesWave = GameManagerScript.IncrementWave();
            numberOfWaveEnemiesKilled = 0;
        }

    }
    
    void SpawnEnemy()
    {
        if (numberOfEnemies < Mathf.Min(maxEnemyNumber, maxEnemiesWave))
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

    public static void OnEnemyKilled()
    {
        numberOfWaveEnemiesKilled++;
        numberOfEnemies--;
    }

    public static void ResetSpawning()
    {
        numberOfEnemies = 0;
        numberOfWaveEnemiesKilled = 0;
    }
}
