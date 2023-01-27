using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerUpSpawnerRoutine());
    }

    IEnumerator PowerUpSpawnerRoutine()
    {
        while(true)
        {
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-35, 43), Random.Range(-41, 43), 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
