using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

    [SerializeField]
    [Tooltip("Time from particle spawn at which the object will be destroyed.")]
    private float DestroyTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
//        if (Time.deltaTime == DestroyTime)
//        {
            Destroy(gameObject, DestroyTime);
//        }
	}
}
