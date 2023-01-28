using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyObject;

    private float movementSpeed;
    
    private Transform target;
    private Vector2 targetPosition;
    private Vector2 currentPosition;

    private Rigidbody2D rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        movementSpeed = enemyObject.speed;
        target = enemyObject.target;
    }

    void Update()
    {
        targetPosition = (Vector2)target.position;
        currentPosition = rb.position;

        Vector2 direction = targetPosition - currentPosition;
        direction.Normalize();
        rb.MovePosition(rb.position + movementSpeed * Time.deltaTime * direction);
        transform.up = direction;
    }
}
