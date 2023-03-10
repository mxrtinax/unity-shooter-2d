using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 targetOffset;
    [SerializeField] float movementSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        moveCamera();
    }

    void moveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }
}
