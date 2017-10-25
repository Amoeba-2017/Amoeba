using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    // Velocity
    [SerializeField]
    [Tooltip("X axis movement speed.")]
    private float speedX;       // X axis
    [SerializeField]
    [Tooltip("Y axis movement speed.")]
    private float speedY;       // Y axis
    [SerializeField]
    [Tooltip("Z axis movement speed.")]
    private float speedZ;       // Z axis

    // Positional Stuffs
    private Vector3 startPosition;
    private float currentDistance;
    [SerializeField]
    [Tooltip("Set distance that when reached will cause the cloud's current position to be reset to its starting position.")]
    private float resetDistance;

    private Rigidbody rb;

    // Initialization
    void Start ()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update (Per Frame)
	void Update ()
    {
        rb.velocity = new Vector3(speedX, speedY, speedZ);
        currentDistance = Vector3.Distance(startPosition, transform.position);
        if (currentDistance >= resetDistance)
        {
            transform.position = startPosition;
        }
    }
}
