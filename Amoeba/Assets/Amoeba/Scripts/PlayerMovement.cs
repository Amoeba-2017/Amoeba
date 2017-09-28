using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private GameObject slimePrefab;

    private InputDevice controller;

    [SerializeField]
    float speed;
    private GameStateManager gameManager;
    CharacterController cc;
    Vector3 startPos;


    [SerializeField]
    List<GameObject> slimes;

    [HideInInspector]
    public int playerNumber = 1;


    [SerializeField]
    float dodgeForce;


    // Use this for initialization
    void Start ()
    {
        
        cc = GetComponent<CharacterController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        playerNumber = gameManager.playerCount;
        GameObject tempSlime = Instantiate(slimePrefab, transform.position + -transform.up, transform.rotation);
        tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
        slimes.Add(tempSlime);
        Debug.Log(playerNumber);
        Debug.Log(InputManager.Devices.Count);

        if (playerNumber <= InputManager.Devices.Count)
        {
            Debug.Log("im a controller");
            controller = InputManager.Devices[playerNumber - 1];

        }

    }

    // Update is called once per frame
    void Update ()
    {

        if (controller == null)
        {
            cc.Move(transform.right * Input.GetAxis("HorizontalKeys") * speed * Time.deltaTime);
            cc.Move(transform.forward * Input.GetAxis("VerticalKeys") * speed * Time.deltaTime);
        

            
            if (gameManager.debugMode == true)
            {
                DebugMode();
            }



            if (Input.GetKeyDown("q"))
            {

                Vector3 centerPoint = new Vector3();
                foreach (GameObject x in slimes)
                {
                    centerPoint += x.transform.position;
                }


                centerPoint /= slimes.Count;

                foreach (GameObject x in slimes)
                {
                    x.GetComponent<SlimeMovement>().Dodge(centerPoint, dodgeForce);
                }


            }
        }
        //controller
        else
        {
            cc.Move(transform.right * controller.LeftStick.X * speed * Time.deltaTime);
            cc.Move(transform.forward * controller.LeftStick.Y * speed * Time.deltaTime);

            if (gameManager.debugMode == true)
            {
                DebugMode();
            }

            if (controller.Action1.WasReleased)
            {

                Vector3 centerPoint = new Vector3();
                foreach (GameObject x in slimes)
                {
                    centerPoint += x.transform.position;
                }


                centerPoint /= slimes.Count;

                foreach (GameObject x in slimes)
                {
                    x.GetComponent<SlimeMovement>().Dodge(centerPoint, dodgeForce);
                }
            }
        }


    }

    void DebugMode()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameObject tempSlime;
            tempSlime = Instantiate(slimePrefab, transform.position + -transform.up  + transform.right, transform.rotation);
            tempSlime.GetComponent<SlimeMovement>().parent = gameObject.tag;
            slimes.Add(tempSlime);
        }
    }

}
