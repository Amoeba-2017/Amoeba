using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour {

    //declaring variables

    [SerializeField] [Tooltip("The slime that will be spawned by this player")]
    private GameObject slimePrefab;

    private InputDevice controller;

    [SerializeField][Tooltip("The speed that the player will move")]
    float speed;


    private GameStateManager gameManager;
    CharacterController cc;
    Vector3 startPos;

    List<GameObject> slimes = new List<GameObject>();

    [HideInInspector]
    public int playerNumber = 1;


    [SerializeField] [Tooltip("The amount of force applied when dodging")]
    float dodgeForce;


    void Start ()
    {
        //defining the Character Controller
        cc = GetComponent<CharacterController>();

        //defining the GameManager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();

        //getting the amount of players in the game
        playerNumber = gameManager.playerCount;

        //making the first slime
        GameObject tempSlime = Instantiate(slimePrefab, transform.position + -transform.up, transform.rotation);
        tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
        slimes.Add(tempSlime);

        //if this player number is less then or equal to the amount of controllers
        if (playerNumber <= InputManager.Devices.Count)
        {
            Debug.Log("Added a controller to player number" + playerNumber);
            
            //give this player a controller
            controller = InputManager.Devices[playerNumber - 1];

        }

    }


    void Update ()
    {
        //if there is no controller
        if (controller == null)
        {

            //using keybored controls


            //add movment to the player if the user adds input
            cc.Move(transform.right * Input.GetAxis("HorizontalKeys") * speed * Time.deltaTime);
            cc.Move(transform.forward * Input.GetAxis("VerticalKeys") * speed * Time.deltaTime);
        



            //if q button is pressed
            if (Input.GetKeyDown("q"))
            {
                //find the center of all of the slimes
                Vector3 centerPoint = new Vector3();
                foreach (GameObject x in slimes)
                {
                    centerPoint += x.transform.position;
                }

                //average all the slimes positions
                centerPoint /= slimes.Count;

                
                foreach (GameObject x in slimes)
                {
                    //call dodge on each slime passing though the centerpoint and the amount of force 
                    x.GetComponent<SlimeMovement>().Dodge(centerPoint, dodgeForce);
                }


            }


            //Shooting on keybored

            //if mousebutton 0 is pressed
                
                //find the normilised vector Between the the player(this gameobject) and the mouse 

                // foreach slime in the list slimes

                 // call shoot on current slime

        }
       
        
        //controller
        else
        {


            //add movment to the player if the user adds input 
            cc.Move(transform.right * controller.LeftStick.X * speed * Time.deltaTime);
            cc.Move(transform.forward * controller.LeftStick.Y * speed * Time.deltaTime);


            //if the a button is pressed on xbox or the x button is pressed on controller (this will probs change)
            if (controller.Action1.WasPressed)
            {
                //find the center of all of the slimes
                Vector3 centerPoint = new Vector3();
                foreach (GameObject x in slimes)
                {
                    centerPoint += x.transform.position;
                }

                //average all the slimes positions
                centerPoint /= slimes.Count;

                foreach (GameObject x in slimes)
                {
                    //call dodge on each slime passing though the centerpoint and the amount of force 
                    x.GetComponent<SlimeMovement>().Dodge(centerPoint, dodgeForce);
                }
            }


            //shooting on controller

            // idk how this is going to be done yet


        }


        //if debug mode is active
        if (gameManager.debugMode == true)
        {
            DebugMode();
        }



    }

    void DebugMode()
    {
        //if enter is pressed
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //make a new slime
            GameObject tempSlime;
            tempSlime = Instantiate(slimePrefab, transform.position + -transform.up  + transform.right, transform.rotation);
            tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
            slimes.Add(tempSlime);
        }
    }

}
