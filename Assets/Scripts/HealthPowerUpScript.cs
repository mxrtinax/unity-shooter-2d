using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerScript>().currentHealth = collision.GetComponent<PlayerScript>().maxHealth;
            collision.GetComponent<PlayerScript>().healthbar.SetHealth(collision.GetComponent<PlayerScript>().currentHealth);
            Debug.Log(collision.GetComponent<PlayerScript>().currentHealth);
        }
    }
}
