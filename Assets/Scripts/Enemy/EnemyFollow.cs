using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyObject;

    private float movementSpeed;
    private Transform target;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    
    void Start()
    {
        movementSpeed = enemyObject.speed;
        target = enemyObject.target;
        targetPosition = target.position;
        currentPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
    }
}
