using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float speed = 1f;

    public GameObject deathEffect;
    public HealthbarScript healthBar;
    
    public float attackSpeed = 1f;
    public float attackRange = 1f;
    public float projectileSpeed = 1f;

    public int score = 10;
    
    public Transform target;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        GameManagerScript.AddScore(score);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        EnemySpawning.OnEnemyKilled();
    }
}
