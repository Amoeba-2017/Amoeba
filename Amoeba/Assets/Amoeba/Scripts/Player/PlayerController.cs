using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{
    //declaring variables
    [SerializeField]
    [Tooltip("The slime that will be spawned by this player")]
    private GameObject slimePrefab;

    private XboxController controller;

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
    public float mass = 50;

    private bool hasMovedRetical = false;
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

        controllerRetical = transform.GetChild(2).gameObject;

        //making the first slime
        GameObject tempSlime = Instantiate(slimePrefab, new Vector3(transform.position.x, 45.25f, transform.position.z), transform.rotation);
        tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
        slimes.Add(tempSlime);
        isMoving = false;
    }

    public void SetController(XboxController device)
    {
        controller = device;
    }

    void Update()
    {
        if(mass <= 30)
        {
            mass = 30;
        }

        if(mass >= 100)
        {
            mass = 100;
        }     

        ShootTimer += Time.deltaTime;

        //if there is no controller
        if (controller == XboxController.None)
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
        if(hasMovedRetical == false && (controllerRetical.transform.position - transform.position).magnitude == 0.0f) //if no movement of stick, set shooting direction to forward
        {
            dirRot = Vector3.forward;
        }
        else
        { 
            dirRot = (controllerRetical.transform.position - transform.position).normalized;
            hasMovedRetical = true;
        }
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

    void ControllerUpdate()
    {
        //add movment to the player if the user adds input 
        //cc.Move(transform.right * controller.LeftStick.X * speed * Time.deltaTime);
        //cc.Move(transform.forward * controller.LeftStick.Y * speed * Time.deltaTime);

        cc.Move((((transform.right * XCI.GetAxis(XboxAxis.LeftStickX, controller)) + (transform.forward * XCI.GetAxis(XboxAxis.LeftStickY, controller)).normalized) * speed  * Time.deltaTime));

        controllerRetical.transform.position = transform.position + new Vector3(XCI.GetAxisRaw(XboxAxis.RightStickX, controller), 0, XCI.GetAxisRaw(XboxAxis.RightStickY, controller));

        //shooting on controller
        if (XCI.GetAxis(XboxAxis.RightTrigger, controller) > 0  && ShootTimer > BufferTime)
        {
            ShootTimer = 0.0f;

            foreach (GameObject i in slimes)
            {
                i.GetComponent<SlimeActions>().Shoot(lastRot, mass);
            }
        }
    }

    void KeyboredUpdate()
    {
        //using keybored controls

        //add movment to the player if the user adds input
        cc.Move(((transform.right * Input.GetAxis("HorizontalKeys")) + (transform.forward * Input.GetAxis("VerticalKey"))).normalized  * speed  * Time.deltaTime);
        //   cc.Move(transform.forward * Input.GetAxis("VerticalKeys") * speed * Time.deltaTime);     

        //Shooting on keybored
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Vector3 vec3 = Vector3.zero;
        if (Physics.Raycast(ray, out rayHit))
        {
            vec3 = new Vector3(rayHit.point.x, startPos.y, rayHit.point.z) - transform.position;
        }

        controllerRetical.transform.position = vec3;

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