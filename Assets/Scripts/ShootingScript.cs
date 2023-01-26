using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Vector2 direction;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float shootInterval = 1f;

    private float timeSinceLastShot = 0f;
    void Start()
    {

    }

    void Update()
    {
        if (timeSinceLastShot > shootInterval)
        {
            timeSinceLastShot = 0f;
            Shoot();
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }

    void Shoot()
    {
        direction.Normalize();
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        projectile.AddComponent<ProjectileScript>();
    }
}
