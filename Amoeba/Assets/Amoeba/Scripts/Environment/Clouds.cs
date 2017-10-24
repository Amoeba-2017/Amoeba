using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    // Spawn Coordinates
    [SerializeField]
    [Tooltip("X axis spawn position.")]
    private float spawnX;
    [SerializeField]
    [Tooltip("Y axis spawn position.")]
    private float spawnY;
    [SerializeField]
    [Tooltip("Z axis spawn position.")]
    private float spawnZ;

    // Scaling
    [SerializeField]
    [Tooltip("X axis scale.")]
    private float scaleX;
    [SerializeField]
    [Tooltip("Y axis scale.")]
    private float scaleY;
    [SerializeField]
    [Tooltip("Z axis scale.")]
    private float scaleZ;

    // Velocity
    [SerializeField]
    [Tooltip("X axis movement speed.")]
    private float speedX;
    [SerializeField]
    [Tooltip("Y axis movement speed.")]
    private float speedY;
    [SerializeField]
    [Tooltip("Z axis movement speed.")]
    private float speedZ;

    [SerializeField]
    [Tooltip("The set time which a cloud will spawn after the last.")]
    private float spawnSetTime;
    private float spawnCurrentTime;

    private Rigidbody rb;

    public Transform cloudPrefab;

    // Initialization
    void Start ()
    {
        transform.Translate(spawnX, spawnY, spawnZ);
        rb = GetComponent<Rigidbody>();
        spawnCurrentTime = 0.0f;
    }
	
	// Update (Per Frame)
	void Update ()
    {
        rb.velocity = new Vector3(speedX, speedY, speedZ);
        if ((transform.position.z <= 350 || transform.position.z >= -350) || (transform.position.x <= 350 || transform.position.x >= -350))
        {
            //DestroyCloud();
        }
        spawnCurrentTime += Time.deltaTime;
        if (spawnCurrentTime == spawnSetTime)
        {
            SpawnCloud();
        }
    }

    // Spawn
    void SpawnCloud ()
    {
        Instantiate(cloudPrefab, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
        spawnCurrentTime = 0.0f;
    }

    // Destroy
    void DestroyCloud ()
    {
        Destroy(gameObject);
    }
}
