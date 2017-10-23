using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    [SerializeField]
    private float spawnX;
    [SerializeField]
    private float spawnY;
    [SerializeField]
    private float spawnZ;

    [SerializeField]
    private float spawnFrequency;
    [SerializeField]
    private float speed;

    //[SerializeField]
    //private GameObject cloudA;
    //[SerializeField]
    //private GameObject cloudB;

    // Initialization
    void Start ()
    {
        transform.Translate(spawnX, spawnY, spawnZ);
	}
	
	// Update (Per Frame)
	void Update ()
    {	
	}
}
