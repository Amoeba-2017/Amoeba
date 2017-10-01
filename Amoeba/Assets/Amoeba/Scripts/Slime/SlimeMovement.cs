using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SlimeMovement : MonoBehaviour {


    //declaring variables
    Rigidbody rb;
    GameObject player;

    [SerializeField] [Tooltip("The speed that the slimes will move")]
    float speed;

    [SerializeField] [Tooltip("The amount of force applied depending upon the distance from the slime to the player")]
    float distanceMultiplier;

    [SerializeField] [Tooltip("The amount of force applied when a slime hits a wall to try get around it")]
    float avoidWallsForce;

    [HideInInspector]
    public string parent;


    void Start ()
    {
        //finding the ridgedbody
        rb = gameObject.GetComponent<Rigidbody>();

    }
	

	void Update ()
    {
        //if the player hasnt been defined yet
        if(player == null)
        {
            //define it
            player = GameObject.FindGameObjectWithTag(parent);
        }

        //seek the player
        Seek();
	}

    void Seek()
    {        
        //get the vector between the player and the me and add a force to it (ignoring y)
         Vector3 vecBetween = player.transform.position - transform.position;
         vecBetween = new Vector3(vecBetween.x, 0, vecBetween.z);
         rb.AddForce(vecBetween * (vecBetween.magnitude * distanceMultiplier) * speed * Time.deltaTime, ForceMode.Force);
    }

    void Avoid(GameObject col)
    {

        Vector3 vecBtwSlimeAndWall = col.transform.position - transform.position;
        Vector3 vecBtwSlimeAndPlayer = player.transform.position - transform.position;
        Vector3 finalvec = new Vector3();


        if (Vector3.SignedAngle(vecBtwSlimeAndWall, vecBtwSlimeAndPlayer, Vector3.up) > 0)
        {

            finalvec = Vector3.Cross(vecBtwSlimeAndPlayer.normalized, Vector3.up);
            finalvec = -finalvec;
        }

        else
        {
            finalvec = Vector3.Cross(vecBtwSlimeAndPlayer.normalized, Vector3.up);

        }

        rb.AddForce(finalvec * (vecBtwSlimeAndPlayer.magnitude * distanceMultiplier) * speed * Time.deltaTime, ForceMode.Impulse);
        rb.AddForce(-vecBtwSlimeAndPlayer * avoidWallsForce * vecBtwSlimeAndPlayer.magnitude * Time.deltaTime, ForceMode.Impulse);
    }


    void OnCollisionStay(Collision collision)
    {
        //if the slime collides with a wall
        if (collision.transform.tag == "Wall")
        {
            //avoid the wall
            Avoid(collision.gameObject);
        }
    }

    public void Dodge(Vector3 centerPoint, float force)
    {
        //get the vector between the center point and me
        Vector3 vecBetween = centerPoint - transform.position;

        //inverse that vector and add a force to it
        rb.AddForce(-vecBetween.normalized * force,ForceMode.Impulse);

    }

}
