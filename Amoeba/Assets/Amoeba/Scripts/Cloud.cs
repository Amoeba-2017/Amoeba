using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
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
	// Start point
	public GameObject start;
	// End point
	public GameObject end;

	private Vector3 moveHere;
	private Vector3 stopHere;
	// This objects position
	private float currentDistance;

	// Use this for initialization
	void Start ()
    {
		moveHere = start.transform.position;
		stopHere = end.transform.position;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
    {
		Debug.Log (currentDistance);
		Vector3 transtemp = transform.position;

		//Movement
		rb.velocity = new Vector3(speedX, speedY, speedZ);
		currentDistance = Vector3.Distance(stopHere, transform.position);
		// If the current distance exceeds the reset distance, reset the distance back to start.
		if (currentDistance <= 100)
		{
			transform.position = moveHere;
			Debug.Log ("working");
		}
//		if (transtemp.x <= end)
//		{
//			
//			Debug.Log ("working");
//		}
	}
}
