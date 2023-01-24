using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    Vector3 wantedPosition;
    public float movement_resistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        wantedPosition = Camera.main.transform.position * movement_resistance;
        wantedPosition.z = transform.position.z;
        transform.position = wantedPosition;
    }
}
