using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePuddle : MonoBehaviour {

    [SerializeField]
    private float mass;

    Vector3 randomRotDir;

    [HideInInspector]
    public bool ShootOut;

    [SerializeField]
    private float minRanForce = 2;

    [SerializeField]
    private float maxRanForce = 5;

    //mass needs to be added here 


    public void SetMass(float a_mass)
    {
        mass = a_mass;
    }

	// Use this for initialization
	void Start ()
    {
        if (ShootOut == true)
        {

            gameObject.GetComponent<Rigidbody>().AddForce(randomRotDir * Random.Range(minRanForce, maxRanForce), ForceMode.Impulse);
        }
    }
	

    void OnCollisionEnter(Collision x)
    {
        if (x.transform.tag == "Slime")
        {
            Physics.IgnoreCollision(x.collider, transform.GetComponent<Collider>(), true);
            GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass += mass;
            Destroy(gameObject);
        }
    }




    // Update is called once per frame
    void Update ()
    {
		
	}
}
