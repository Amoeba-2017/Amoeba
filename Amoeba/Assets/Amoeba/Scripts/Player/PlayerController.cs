using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour
{
    //declaring variables
    [SerializeField]
    [Tooltip("The slime that will be spawned by this player")]
    private GameObject slimePrefab;

    private InputDevice controller;

    [SerializeField]
    [Tooltip("The speed that the player will move")]
    public float speed;

    private bool increasedSpeed;

    [SerializeField]
    private float powerUpTime;

    private GameStateManager gameManager;
    [HideInInspector]
    public CharacterController cc;
    Vector3 startPos;

    public List<GameObject> slimes = new List<GameObject>();

    [HideInInspector]
    public int playerNumber = 1;

    private Vector3 lastRot;

    [SerializeField]
    [Tooltip("The amount of force applied when dodging")]
    float dodgeForce;

    [SerializeField]
    private float BufferTime;

    private float ShootTimer;

    private GameObject controllerRetical;

    public float slimeRandomDistanceToPlayer;

    [SerializeField]
    public float slimeMovementDistanceScalar;

    private Vector3 dirRot;
    int randomKingSlime = 0;
    bool isMoving;

    [SerializeField]
    public float mass = 100;

    void Start()
    {

        increasedSpeed = false;

        //defining the Character Controller
        cc = GetComponent<CharacterController>();

        //defining the GameManager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();

        ShootTimer = BufferTime;

        //getting the amount of players in the game
        playerNumber = gameManager.playerCount;

        controllerRetical = transform.GetChild(0).gameObject;

        //making the first slime
        GameObject tempSlime = Instantiate(slimePrefab, new Vector3(transform.position.x, 45.25f, transform.position.z), transform.rotation);
        tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
        slimes.Add(tempSlime);
        isMoving = false;

    }

    public void SetController(InputDevice device)
    {
        controller = device;
    }




    void Update()
    {
        //if (slimes.Count == 0)
        //{
        //    gameManager.Players.Remove(gameObject);

        //    // Play Defeat sound
        //    AudioManager.PlaySound("DefeatSound");

        //    Destroy(gameObject);
        //}


       // slimeRandomDistanceToPlayer = (slimes.Count * 0.1f) * slimeMovementDistanceScalar;

        //isMoving = false

        //if not moving
        //and isMoving == true
        // just stopped
        // isMoving = false
        // choose random slime
        //else
        //isMoving = true

        //if (cc.velocity == Vector3.zero)
        //{
        //    if (isMoving == true)
        //    {
        //        isMoving = false;
        //    }
        //}
        //else
        //{
        //    isMoving = true;
        //}


        //if(slimeRandomDistanceToPlayer < 0)
        //{
        //    slimeRandomDistanceToPlayer = 0;
        //}

        //if(slimeRandomDistanceToPlayer > maxSlimeRandomDistance)
        //{
        //    slimeRandomDistanceToPlayer = maxSlimeRandomDistance;
        //}

        ShootTimer += Time.deltaTime;

        //if there is no controller
        if (controller == null)
        {
            KeyboredUpdate();
        }


        //controller
        else
        {
            ControllerUpdate();
        }


        //if debug mode is active
        //if (gameManager.debugMode == true)
        //{
        //    DebugMode();
        //}

        lastRot = dirRot;
        dirRot = (controllerRetical.transform.position - transform.position).normalized;

        if (dirRot == Vector3.zero)
        {
            dirRot = lastRot;
        }

        foreach (GameObject x in slimes)
        {
            x.GetComponent<SlimeMovement>().setTargetRot(dirRot);
        }

        /////////RETICAL WORK

        if (dirRot != Vector3.zero)
        {
            transform.GetChild(1).rotation = Quaternion.LookRotation(dirRot, Vector3.up);
        }

        transform.GetChild(1).transform.position = slimes[randomKingSlime].transform.position;

    }





    //void DebugMode()
    //{
    //    //if enter is pressed
    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        //make a new slime
    //        GameObject tempSlime;
    //        tempSlime = Instantiate(slimePrefab, new Vector3(transform.position.x, 45.25f, transform.position.z) + transform.right, transform.rotation);
    //        tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
    //        slimes.Add(tempSlime);
    //    }
    //}


    //public void newKingSlime()
    //{
    //    if (slimes.Count > 0)
    //    {
    //        slimes[randomKingSlime].GetComponent<SlimeMovement>().kingSlime = false;

    //        randomKingSlime = Random.Range(0, slimes.Count - 1);
    //        Debug.Log(randomKingSlime);
    //        transform.position = slimes[randomKingSlime].transform.position;
    //        slimes[randomKingSlime].GetComponent<SlimeMovement>().kingSlime = true;
    //    }
    //}


    void ControllerUpdate()
    {



        //add movment to the player if the user adds input 
        //cc.Move(transform.right * controller.LeftStick.X * speed * Time.deltaTime);
        //cc.Move(transform.forward * controller.LeftStick.Y * speed * Time.deltaTime);

        cc.Move(((transform.right * controller.LeftStick.X) + (transform.forward * controller.LeftStick.Y)).normalized * speed * Time.deltaTime);


        controllerRetical.transform.position = transform.position + new Vector3(controller.RightStick.X, 0, controller.RightStick.Y);


        //if the a button is pressed on xbox or the x button is pressed on controller (this will probs change)
        //if q button is pressed
        //if (cc.velocity == Vector3.zero)
        //if (controller.LeftBumper.IsPressed)
        //{
        //    //find the center of all of the slimes
        //    Vector3 centerPoint = new Vector3();
        //    foreach (GameObject x in slimes)
        //    {
        //        centerPoint += x.transform.position;
        //    }

        //    //average all the slimes positions
        //    centerPoint /= slimes.Count;

        //    foreach (GameObject x in slimes)
        //    {
        //        //call dodge on each slime passing though the centerpoint and the amount of force 
        //        x.GetComponent<SlimeMovement>().Retract(transform.position);
        //    }


        //}


        //if (controller.RightBumper.IsPressed)
        //{
        //    //find the center of all of the slimes
        //    Vector3 centerPoint = new Vector3();
        //    foreach (GameObject x in slimes)
        //    {
        //        centerPoint += x.transform.position;
        //    }

        //    //average all the slimes positions
        //    centerPoint /= slimes.Count;

        //    foreach (GameObject x in slimes)
        //    {
        //        //call dodge on each slime passing though the centerpoint and the amount of force 
        //        x.GetComponent<SlimeMovement>().Expand(transform.position);
        //    }
        //}

        //if (controller.RightBumper.WasReleased)
        //{
        //    //foreach (GameObject x in slimes)
        //    //{
        //    //    x.GetComponent<SlimeMovement>().isMoving = true;
        //    //}
        //}

        //shooting on controller


        if (controller.RightTrigger.WasPressed && ShootTimer > BufferTime)
        {
            ShootTimer = 0.0f;

            foreach (GameObject i in slimes)
            {
                //i.GetComponent<SlimeActions>().Shoot(dirRot);
            }
        }


    }

    void KeyboredUpdate()
    {
        //using keybored controls

        //add movment to the player if the user adds input
        cc.Move(((transform.right * Input.GetAxis("HorizontalKeys")) + (transform.forward * Input.GetAxis("VerticalKey"))).normalized * speed * Time.deltaTime);
        //   cc.Move(transform.forward * Input.GetAxis("VerticalKeys") * speed * Time.deltaTime);

        //if q button is down
        //if (Input.GetKey(KeyCode.Q))
        //{


        //    //find the center of all of the slimes
        //    Vector3 centerPoint = Vector3.zero;
        //    foreach (GameObject x in slimes)
        //    {
        //        centerPoint += x.transform.position;
        //    }

        //    //average all the slimes positions
        //    centerPoint /= slimes.Count;


        //    foreach (GameObject x in slimes)
        //    {
        //        //call dodge on each slime passing though the centerpoint and the amount of force 
        //        x.GetComponent<SlimeMovement>().Retract(centerPoint);
        //    }


        //}
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    //foreach (GameObject x in slimes)
        //    //{
        //    //    x.GetComponent<SlimeMovement>().isMoving = true;
        //    //}
        //}

        //if (Input.GetKey(KeyCode.E))
        //{
        //    //find the center of all of the slimes
        //    Vector3 centerPoint = Vector3.zero;
        //    foreach (GameObject x in slimes)
        //    {
        //        centerPoint += x.transform.position;
        //    }

        //    //average all the slimes positions
        //    centerPoint /= slimes.Count;


        //    foreach (GameObject x in slimes)
        //    {
        //        //call dodge on each slime passing though the centerpoint and the amount of force 
        //        x.GetComponent<SlimeMovement>().Expand(centerPoint);
        //    }

        //}
        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    //foreach (GameObject x in slimes)
        //    //{
        //    //    x.GetComponent<SlimeMovement>().isMoving = true;
        //    //}
        //}

        //Shooting on keybored
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Vector3 vec3 = Vector3.zero;
        if (Physics.Raycast(ray, out rayHit))
        {
            vec3 = new Vector3(rayHit.point.x, startPos.y, rayHit.point.z) - transform.position;
            Debug.DrawLine(rayHit.point, transform.position);
        }

        //if mousebutton 0 is pressed
        if (Input.GetMouseButtonDown(0) && ShootTimer > BufferTime)
        {
            ShootTimer = 0.0f;
            foreach (GameObject i in slimes)
            {
                i.GetComponent<SlimeActions>().Shoot(vec3.normalized, mass);
            }
        }
    }

    public void allSlimesAreIsInvincible()
    {
        foreach (GameObject x in slimes)
        {
            x.GetComponent<SlimeHealth>().isInvincible = true;
            StartCoroutine(x.GetComponent<SlimeHealth>().InvincibleFrames());
        }
    }
}