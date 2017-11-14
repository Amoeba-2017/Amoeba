using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePuddle : MonoBehaviour
{

    [SerializeField]
    private float mass;

    Vector3 randomRotDir;

    [HideInInspector]
    public bool ShootOut;

    [SerializeField]
    private float minRanForce = 2;

    [SerializeField]
    private float maxRanForce = 5;

    private GameObject player;



    //mass needs to be added here 


    public void SetMass(float a_mass)
    {
        mass = a_mass;
    }

    // Use this for initialization
    void Start()
    {
        float closestPlayerDist = float.MaxValue;
        GameObject closestPlayer = null;

        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Slime"))
        {
            float currentPlayerDist = Vector3.Distance(x.transform.position, transform.position);

            if (currentPlayerDist < closestPlayerDist)
            {
                closestPlayerDist = currentPlayerDist;
                closestPlayer = x;
            }
        }
        player = closestPlayer;
        Shoot();
    }


    void Shoot()
    {
        if (ShootOut)
        {
            gameObject.GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position).normalized * Random.Range(minRanForce, maxRanForce), ForceMode.Impulse);
        }
    }


    void OnCollisionEnter(Collision x)
    {
        if (x.transform.tag == "Slime")
        {
            if (GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass > 30 && GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass < 100)
            {
                GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass += mass;
                Destroy(gameObject);

                // Play collecting mass sound
                AudioManager.PlaySound("CollectMassSound");
            }
        }
        if (x.transform.tag == "PlayerRed" || x.transform.tag == "PlayerBlue" || x.transform.tag == "PlayerPurple" || x.transform.tag == "PlayerYellow")
        {
            if (GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass > 30 && GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass < 100)
            {
                GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass += mass;
                Destroy(gameObject);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit x)
    {
        if (GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass > 30 && GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass < 100)
        {
            Debug.Log("hit the player or the slime");
            GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass += mass;
            Destroy(gameObject);
        }
    }





    // Update is called once per frame
    void Update()
    {

    }
}
