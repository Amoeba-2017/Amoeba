using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SlimeMovement : MonoBehaviour
{


    //declaring variables
    CharacterController cc;
    [HideInInspector]
    public GameObject player;
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

    [HideInInspector]
    public bool isMoving = true;

    void Start()
    {
        //finding the ridgedbody
        cc = gameObject.GetComponent<CharacterController>();
        speed = Random.Range(speed - speedRandomRange, speed + speedRandomRange);
        //define it
        player = GameObject.FindGameObjectWithTag(parent);
        slimes = player.GetComponent<PlayerController>().slimes;
        newPosRandomRange = player.GetComponent<PlayerController>().slimeRandomDistanceToPlayer;
        newPos = new Vector3(Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.x, transform.position.y, Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.z);
        playersController = player.GetComponent<CharacterController>();
        isMoving = true;
    }


    void Update()
    {


        if (isMoving == true)
        {
            Seek();
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




    void Seek()
    {
        foreach (GameObject x in slimes)
        {
            if (x != null)
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

        if (Vector3.Distance(transform.position, newPos) > 0.5f)
        {
            Vector3 vecBetween = newPos - transform.position;

            cc.Move(vecBetween.normalized * speed * Time.deltaTime);
        }
    }

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


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if the slime collides with a wall
        if (hit.transform.tag == "InvisibleWall")
        {
            Debug.Log("WALL");
            newPos = new Vector3(Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.x + (separationForce.normalized.x * separationDistance), transform.position.y, Random.Range(newPosRandomRange, -newPosRandomRange) + player.transform.position.z + (separationForce.normalized.z * separationDistance));
        }
    }

    public void Expand(Vector3 centerPoint)
    {

        //get the vector between the center point and me
        Vector3 vecBetween = centerPoint - transform.position;

        //inverse that vector and add a force to it
        cc.Move(-vecBetween.normalized * speed * Time.deltaTime);

    }


    public void Retract(Vector3 centerPoint)
    {
        Vector3 vecBetween = centerPoint - transform.position;
        cc.Move(vecBetween.normalized * speed * Time.deltaTime);
    }

}
