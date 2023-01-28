using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePosition;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject deathEffect;

    public float bulletSpeed = 20f;

    public HealthbarScript healthbar;

    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead;
    public GameManagerScript gameManager;
    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isDead);
        if(currentHealth <=0 && !isDead)
        {
            Debug.Log("s-a terminat smecheria");
            isDead = true;
            gameManager.gameOver();

        }

        //map borders
        if (transform.position.y >= 46)
        {
            transform.position = new Vector3(transform.position.x, 46, 0);
        }

        if (transform.position.y <= -44)
        {
            transform.position = new Vector3(transform.position.x, -44, 0);
        }

        if (transform.position.x >= 45)
        {
            transform.position = new Vector3(45, transform.position.y, 0);
        }

        if (transform.position.x <= -37)
        {
            transform.position = new Vector3(-37, transform.position.y, 0);
        }
        //map borders

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SoundManagerScript.PlaySound("fire1");
                Shoot();
            }
            if (Input.GetMouseButtonDown(1))
            {
                SecondaryAttack();
            }
        }

            // testing health system
            if (Input.GetKeyDown(KeyCode.B))
        {
            TakeDamage(20);
            Debug.Log(currentHealth);
            Debug.Log(maxHealth);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddHealth(20);
            Debug.Log(currentHealth);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
        
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void SecondaryAttack()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }

    void AddHealth(int healthAmount)
    {
        currentHealth = Mathf.Min(100, currentHealth + healthAmount);
        healthbar.SetHealth(currentHealth);
    }
}
