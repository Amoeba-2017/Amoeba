using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private GameObject slimePrefab;

    [SerializeField]
    float speed;
    private GameStateManager gameManager;
    CharacterController cc;
    Vector3 startPos;


    [SerializeField]
    List<GameObject> slimes;


    [SerializeField]
    float dodgeForce;


    // Use this for initialization
    void Start ()
    {
        cc = GetComponent<CharacterController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        slimes.Add(Instantiate(slimePrefab, transform.position + -transform.up, transform.rotation));
    }

    // Update is called once per frame
    void Update ()
    {


        cc.Move(transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        cc.Move(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        if(gameManager.debugMode == true)
        {
            DebugMode();
        }



        if(Input.GetKeyDown("q"))
        {

            Vector3 centerPoint = new Vector3();
            foreach (GameObject x in slimes)
            {
                centerPoint += x.transform.position;
            }


            centerPoint /= slimes.Count ;

            foreach (GameObject x in slimes)
            {
                x.GetComponent<SlimeMovement>().Dodge(centerPoint, dodgeForce);
            }


        }


    }

    void DebugMode()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameObject tempSlime;
            tempSlime = Instantiate(slimePrefab, transform.position + -transform.up  + transform.right, transform.rotation);
            slimes.Add(tempSlime);
        }
    }

}
