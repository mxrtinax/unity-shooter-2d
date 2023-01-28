using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUpScript : MonoBehaviour
{
    public GameObject player;
    public float increaseAmount = 2.5f;
    public int duration = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerScript>().moveSpeed += increaseAmount;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(speedIncreaseTime(collision));
        }
    }

    IEnumerator speedIncreaseTime(Collider2D player)
    {
        yield return new WaitForSeconds(duration);
        player.GetComponent<PlayerScript>().moveSpeed -= increaseAmount;
        Destroy(gameObject);
    }
}
