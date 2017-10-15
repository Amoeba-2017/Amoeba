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

    private float randomCircleRadius;

    private CharacterController playersController;

    private Vector3 separationForce;

    private float StuckTimer;

    [HideInInspector]
    public bool isMoving = true;

    [SerializeField]
    private float maxSpreadDistance;

    [SerializeField]
    private float minSpreadDistance;

    [SerializeField]
    private float randomSlimeOffset;

    [SerializeField]
    private float ExpandAndSrinkSpeed;

    [SerializeField]
    private float beginYPos;

    void Start()
    {
        //finding the ridgedbody
        cc = gameObject.GetComponent<CharacterController>();
        speed = Random.Range(speed - speedRandomRange, speed + speedRandomRange);
        //define it
        player = GameObject.FindGameObjectWithTag(parent);
        slimes = player.GetComponent<PlayerController>().slimes;
        randomCircleRadius = player.GetComponent<PlayerController>().slimeRandomDistanceToPlayer;
        newPos = FindnewPosition();
        playersController = player.GetComponent<CharacterController>();
        isMoving = true;

        transform.position = new Vector3(transform.position.x, beginYPos, transform.position.z);
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

    Vector3 FindnewPosition()
    {
        //Vector3 pointOnCircle = transform.position + new Vector3(Mathf.Cos(randAngle), 0.0f, Mathf.Sin(randAngle)) * (radius + offset);

        float angle = Random.Range(0, Mathf.PI * 2);
        return new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (randomCircleRadius + Random.Range(randomSlimeOffset, -randomSlimeOffset));

    }


    void Seek()
    {


        //if(slimes.Count > 1)
        //{

        //    Vector3 posOnCircle = FindnewPosition();
        //    Vector3 vecBetween = posOnCircle - transform.position;
        //    cc.Move(vecBetween.normalized * speed * Time.deltaTime);
        //}
        //else
        //{
        //    Vector3 vecBetween = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position;
        //    cc.Move(vecBetween * speed * Time.deltaTime);
        //}


        if (player != null)
        {
            if (slimes.Count > 1)
            {
                //if the player is moving and we're far enough away from our target
                if (Vector3.Distance(transform.position, newPos) < 1 && playersController.velocity != Vector3.zero)
                {
                    //StartCoroutine(FindNewPos());
                    newPos = FindnewPosition();
                }

                if (cc.velocity == Vector3.zero && Vector3.Distance(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z)) > randomCircleRadius)
                {
                    Debug.Log("new pos");
                    newPos = FindnewPosition();
                }

                if (Vector3.Distance(transform.position, newPos) > 0.5f)
                {
                    Vector3 vecBetween = newPos - transform.position;
                    cc.Move(vecBetween.normalized * speed * Time.deltaTime);
                }
            }
            else
            {
                Vector3 vecBetween = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position;
                cc.Move(vecBetween * speed * Time.deltaTime);
            }
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
            newPos = FindnewPosition();
        }
    }

    public void Expand(Vector3 centerPoint)
    {

        if (randomCircleRadius == maxSpreadDistance)
        {
            return;
        }

        randomCircleRadius += (Time.deltaTime * (ExpandAndSrinkSpeed));

        if (randomCircleRadius > maxSpreadDistance)
        {
            randomCircleRadius = maxSpreadDistance;
            newPos = FindnewPosition();
        }
        else if (Vector3.Distance(transform.position, newPos) < 1.0f)
        {
            newPos = FindnewPosition();
        }



        // if (randomCircleRadius < maxSpreadDistance)
        //{

        ////if (isMoving == true)
        ////{
        ////    isMoving = false;
        ////}
        ////get the vector between the center point and me
        //// if (Vector3.Distance(transform.position, newPos) < 1)
        ////{

        //Vector3 vecBetween = centerPoint - transform.position;

        //        //inverse that vector and add a force to it
        //        newPos = (-vecBetween.normalized * speed * Time.deltaTime);
        //    //}
        //    randomCircleRadius += (Time.deltaTime * (speed / 3));
        ////}

    }


    public void Retract(Vector3 centerPoint)
    {



        if (randomCircleRadius == minSpreadDistance)
        {
            return;
        }

        randomCircleRadius -= (Time.deltaTime * (ExpandAndSrinkSpeed));

        if (randomCircleRadius < minSpreadDistance)
        {
            randomCircleRadius = minSpreadDistance;
            newPos = FindnewPosition();
        }
        else if (Vector3.Distance(transform.position, newPos) < 1.0f)
        {
            newPos = FindnewPosition();
        }




        //if (randomCircleRadius > minSpreadDistance)
        //{

        //    //if (isMoving == true)
        //    //{
        //    //    isMoving = false;
        //    //}
        //    if (Vector3.Distance(transform.position, newPos) < 1)
        //    {
        //        Vector3 vecBetween = centerPoint - transform.position;
        //        newPos = (vecBetween.normalized * speed * Time.deltaTime);
        //    }
        //    randomCircleRadius -= (Time.deltaTime *(speed / 3));

        //}

    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(newPos, 0.5f);
    }

}
