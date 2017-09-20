using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour {

    Rigidbody rb;
    GameObject[] invisibleWalls;
    GameObject player;

    [SerializeField]
    float speed;

    [SerializeField]
    float distanceMultiplier;

    [SerializeField]
    float gravityMultiplier;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        invisibleWalls = GameObject.FindGameObjectsWithTag("InvisibleWall");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Seek();
        Avoid();

        rb.AddForce(Vector3.down * gravityMultiplier);

	}

    void Seek()
    {
        
        
         Vector3 vecBetween = player.transform.position - transform.position;
         vecBetween = new Vector3(vecBetween.x, 0, vecBetween.z);
         rb.AddForce(vecBetween * (vecBetween.magnitude * distanceMultiplier) * speed * Time.deltaTime, ForceMode.Force);
        

    }

    void Avoid()
    {
        Vector3 vecBetween;
        foreach(GameObject x in invisibleWalls)
        {
            vecBetween = transform.position - x.transform.position;
            if(vecBetween.magnitude < 2)
            {
                rb.AddForce(vecBetween * 1, ForceMode.Impulse);
            }
        }
    }

    public void Dodge()
    {

    }

}
