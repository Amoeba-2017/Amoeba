using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SlimeMovement : MonoBehaviour {

    Rigidbody rb;
    GameObject player;

    [SerializeField]
    float speed;

    [SerializeField]
    float distanceMultiplier;

    [SerializeField]
    float avoidWallsForce;


    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Seek();
      //  Avoid();

     //   rb.AddForce(Vector3.down * gravityMultiplier);

	}

    void Seek()
    {
        
        
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
        if (collision.transform.tag == "Wall")
        {
            Avoid(collision.gameObject);
        }
    }

    public void Dodge(Vector3 pos, float force)
    {
        Vector3 vecBetween = pos - transform.position;
        Debug.DrawLine(pos, transform.position);
        rb.AddForce(-vecBetween.normalized * force,ForceMode.Impulse);

    }

}
