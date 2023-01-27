using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyObject;

    private Vector2 direction;
    public GameObject projectilePrefab;
    private float projectileSpeed = 10f;
    private float shootInterval;

    private float timeSinceLastShot = 0f;
    void Start()
    {
        shootInterval = enemyObject.attackSpeed;
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
