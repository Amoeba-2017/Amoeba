using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private GameObject slime;

    [SerializeField]
    float speed;
    private GameStateManager gameManager;
    CharacterController cc;
    Vector3 startPos;


    // Use this for initialization
    void Start ()
    {
        cc = GetComponent<CharacterController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update ()
    {
        if(transform.position.y != startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }

        cc.Move(transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        cc.Move(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        if(gameManager.debugMode == true)
        {
            DebugMode();
        }
    }

    void DebugMode()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            Instantiate(slime, transform.position + transform.right, transform.rotation);
        }
    }

}
