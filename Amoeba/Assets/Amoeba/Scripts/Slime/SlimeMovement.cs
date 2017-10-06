using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SlimeMovement : MonoBehaviour
{


    //declaring variables
    CharacterController cc;
    GameObject player;
    bool seeking = false;

    private List<GameObject> slimes;

    [SerializeField]
    [Tooltip("The speed that the slimes will move")]
    float speed;


    [SerializeField]
    [Tooltip("The amount of force applied when a slime hits a wall to try get around it")]
    float avoidWallsForce;

    [HideInInspector]
    public string parent;

    [SerializeField]
    float speedRandomRange;

    [SerializeField]
    float separationDistance;

    Vector3 newPos;

    private float newPosRandomRange;

    private CharacterController playersController;

    private Vector3 separationForce;

    private float StuckTimer;

    void Start()
    {
        //finding the ridgedbody
        cc = gameObject.GetComponent<CharacterController>();
        speed = Random.Range(speed - speedRandomRange, speed + speedRandomRange);
    }


    void Update()
    {
        //if the player hasnt been defined yet
        if (player == null)
        {
            //define it
            player = GameObject.FindGameObjectWithTag(parent);
            slimes = player.GetComponent<PlayerController>().slimes;
            newPosRandomRange = player.GetComponent<PlayerController>().slimeRandomDistanceToPlayer;
            newPos = new Vector3(Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.x, transform.position.y, Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.z);
            playersController = player.GetComponent<CharacterController>();
        }




        foreach (GameObject x in slimes)
        {
            if (x != gameObject)
            {
                if (Vector3.Distance(gameObject.transform.position, x.transform.position) < separationDistance)
                {
                    Vector3 vecBetween = x.transform.position - transform.position;
                    separationForce += vecBetween;
                }
            }
        }

        if (Vector3.Distance(transform.position, newPos) < 1 && playersController.velocity != Vector3.zero)
        {
            //StartCoroutine(FindNewPos());
            newPos = new Vector3(Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.x + (separationForce.normalized.x * separationDistance), transform.position.y, Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.z + (separationForce.normalized.z * separationDistance));
        }

        if (cc.velocity == Vector3.zero && Vector3.Distance(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z)) > newPosRandomRange)
        {
            Debug.Log("new pos");
            newPos = new Vector3(Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.x + (separationForce.normalized.x * separationDistance), transform.position.y, Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.z + (separationForce.normalized.z * separationDistance));
        }

        if (Vector3.Distance(transform.position, newPos) > 1)
        {
            Vector3 vecBetween = newPos - transform.position;

            cc.Move(vecBetween.normalized * speed * Time.deltaTime);

        }

        //seek the player
        //Alignment()
        //Seek();
        //separation()
    }


    //IEnumerator FindNewPos()
    //{
    //  yield return new WaitForSeconds(.1f);
    //        newPos = new Vector3(Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.x + (separationForce.normalized.x * separationDistance), transform.position.y, Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.z + (separationForce.normalized.z * separationDistance));

    //  }




    //void Seek()
    //{
    //    //get the vector between the player and the me and add a force to it (ignoring y)
    //    Vector3 vecBetween = player.transform.position - transform.position;
    //    vecBetween = new Vector3(vecBetween.x, 0, vecBetween.z);
    //    cc.Move(vecBetween.normalized * speed * Time.deltaTime);
    //}

    //void Avoid(GameObject col)
    //{

    //    Vector3 vecBtwSlimeAndWall = col.transform.position - transform.position;
    //    Vector3 vecBtwSlimeAndPlayer = player.transform.position - transform.position;
    //    Vector3 finalvec = new Vector3();


    //    if (Vector3.SignedAngle(vecBtwSlimeAndWall, vecBtwSlimeAndPlayer, Vector3.up) > 0)
    //    {

    //        finalvec = Vector3.Cross(vecBtwSlimeAndPlayer.normalized, Vector3.up);
    //        finalvec = -finalvec;
    //    }

    //    else
    //    {
    //        finalvec = Vector3.Cross(vecBtwSlimeAndPlayer.normalized, Vector3.up);

    //    }

    //    cc.Move(finalvec * speed * Time.deltaTime);
    //    cc.Move(-vecBtwSlimeAndPlayer * avoidWallsForce * vecBtwSlimeAndPlayer.magnitude * Time.deltaTime);
    //}


    //void OnCollisionStay(Collision collision)
    //{
    //    //if the slime collides with a wall
    //    if (collision.transform.tag == "Wall")
    //    {
    //        //avoid the wall
    //        Avoid(collision.gameObject);
    //    }
    //}

    public void Dodge(Vector3 centerPoint, float force)
    {

        //get the vector between the center point and me
        Vector3 vecBetween = centerPoint - transform.position;

        //inverse that vector and add a force to it
        cc.Move(-vecBetween.normalized * force);

    }

}
