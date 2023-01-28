using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyObject;

    public Transform firePoint;
    public GameObject projectilePrefab;

    private Vector2 selfPosition;
    private Vector2 targetPosition;
    
    private float projectileSpeed;
    private float attackRange;
    private float shootInterval;

    private float timeSinceLastShot = 0f;

    public float shootDelay = 0f;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        projectileSpeed = enemyObject.projectileSpeed;
        shootInterval = enemyObject.attackSpeed;
        attackRange = enemyObject.attackRange;
    }

    void Update()
    {
        if (Vector2.Distance(selfPosition, targetPosition) <= attackRange)
        {
            if (timeSinceLastShot >= shootInterval)
            {
                audioSource.Play();
                // wait for shootDelay miliseconds before shooting
                Invoke("Shoot", shootDelay / 1000);
                timeSinceLastShot = 0f;
            }
            else
            {
                timeSinceLastShot += Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        UpdatePositions();
    }

    void Shoot()
    {
        Vector2 direction = targetPosition - selfPosition;
        direction.Normalize();
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    void UpdatePositions()
    {
        selfPosition = transform.position;
        targetPosition = enemyObject.target.position;
    }
}
