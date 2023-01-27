using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUpScript : MonoBehaviour
{
    public GameObject player;
/*    void Start()
    {
        player = (GameObject)Resources.Load("Assets/Prefabs/Player.prefab", typeof(GameObject));
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerScript>().moveSpeed = 7.5f;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(speedIncreaseTime());
        }
    }

    IEnumerator speedIncreaseTime()
    {
        //player.GetComponent<PlayerScript>().moveSpeed = 7.5f;
        yield return new WaitForSeconds(3);
        revertSpeed();
        Destroy(gameObject);
    }

    void revertSpeed()
    {
        player.GetComponent<PlayerScript>().moveSpeed = 5f;
    }
}
