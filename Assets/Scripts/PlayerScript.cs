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

    public float bulletSpeed = 20f;
    public float health = 100f;

    public HealthBarBehaviour healthBar;

    void Start()
    {
        healthBar.SetHealth(health, 100f);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
        health -= 5;
        healthBar.SetHealth(health, 100f);
    }
}
