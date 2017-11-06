using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : MonoBehaviour
{

    [SerializeField]
    private GameObject BulletWallSplat;

    [SerializeField]
    private GameObject BulletSlimeSplat;

    bool isPickupAble = false;

    Vector3 newRandomPos;

    [SerializeField]
    private GameObject Puddle;

    float myMass;
    float hitMass;


    public void SetMyMass(float mass)
    {
        myMass = mass;
    }

    public void SetHitMass(float mass)
    {
        hitMass = mass;
    }

    private void CreatePuddles(Collision x)
    {
        if (x != null)
        {
            Vector3 randomRotDir = Vector3.zero;

            if (myMass > 0)
            {
                int randomPos = Random.Range(1, 4);

                if (randomPos == 1)
                {
                    randomRotDir = ((transform.position + transform.up) + transform.right + transform.forward);
                }
                else if (randomPos == 2)
                {
                    randomRotDir = ((transform.position + transform.up) + -transform.right + transform.forward);
                }
                else if (randomPos == 3)
                {
                    randomRotDir = ((transform.position + transform.up) + transform.right + -transform.forward);
                }

                else if (randomPos == 4)
                {
                    randomRotDir = ((transform.position + transform.up) + -transform.right + -transform.forward);
                }



                GameObject puddle;
                puddle = Instantiate(Puddle, Vector3.one * 1000.0f, Quaternion.identity);
                CharacterController cc;


                Physics.IgnoreCollision(puddle.GetComponent<Collider>(), x.transform.GetComponent<CharacterController>(), true);
                puddle.transform.position = randomRotDir;
                puddle.GetComponent<SlimePuddle>().SetMass(myMass);


            }
            else
            {
                Debug.Log("0 mass to Throw");
                Debug.Log(myMass);
                Debug.Log(hitMass);
            }
        }
    }


    // Collision Code
    // Different particle effect depending on which If Statement is triggered
    void OnCollisionEnter(Collision x)
    {
        if (x.transform.tag == "Slime")
        {
            Instantiate(BulletSlimeSplat, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            CreatePuddles(x);
            Destroy(gameObject);
        }

        if (x.gameObject.tag == "Wall" || x.gameObject.tag == "Rock")
        {
            Instantiate(BulletWallSplat, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }

}