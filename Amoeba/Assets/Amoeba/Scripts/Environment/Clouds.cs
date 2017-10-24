using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    // Scaling
    [SerializeField]
    [Tooltip("X axis scale.")]
    private float scaleX;       // X axis
    [SerializeField]
    [Tooltip("Y axis scale.")]
    private float scaleY;       // Y axis
    [SerializeField]
    [Tooltip("Z axis scale.")]
    private float scaleZ;       // Z axis

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

    private Rigidbody rb;
    private Vector3 startPosition;
    public float dist;

    // Initialization
    void Start ()
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;
        startPosition.z = transform.position.z;
        rb = GetComponent<Rigidbody>();
        dist = Vector3.Distance(startPosition, transform.position);
    }
	
	// Update (Per Frame)
	void Update ()
    {
        rb.velocity = new Vector3(speedX, speedY, speedZ);

        if (dist >= 10)//distance >= 200)
        {
            transform.position = startPosition;
        }
    }
}
