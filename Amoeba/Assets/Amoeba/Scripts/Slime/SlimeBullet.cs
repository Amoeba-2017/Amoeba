﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : MonoBehaviour
{
    //[SerializeField]
    //[Tooltip("Time from bullet model being removed at which the object will be destroyed.")]
    //private float ParentExpireTime;

    [SerializeField]
    private GameObject BulletSplat;

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
                if (GameObject.FindGameObjectWithTag(x.gameObject.GetComponent<SlimeMovement>().parent).GetComponent<PlayerController>().mass > 30)
                {
                    int randomPos = Random.Range(1, 4);

                    if (randomPos == 1)
                    {
                        randomRotDir = ((transform.position + transform.up) + transform.right * 2 + transform.forward * 2);
                    }
                    else if (randomPos == 2)
                    {
                        randomRotDir = ((transform.position + transform.up) + -transform.right * 2 + transform.forward * 2);
                    }
                    else if (randomPos == 3)
                    {
                        randomRotDir = ((transform.position + transform.up) + transform.right * 2 + -transform.forward * 2);
                    }

                    else if (randomPos == 4)
                    {
                        randomRotDir = ((transform.position + transform.up) + -transform.right * 2 + -transform.forward * 2);
                    }
                    GameObject puddle;
                    puddle = Instantiate(Puddle, randomRotDir, Quaternion.identity);
                    puddle.GetComponent<SlimePuddle>().ShootOut = true;
                    Physics.IgnoreCollision(puddle.GetComponent<Collider>(), x.transform.GetComponent<CharacterController>(), true);
                    puddle.GetComponent<SlimePuddle>().SetMass(myMass);
                }
            }
        }
    }

    // Collision Code
    // Different particle effect depending on which If Statement is triggered
    void OnCollisionEnter(Collision x)
    {
        if (x.transform.tag == "Slime")
        {
            CreatePuddles(x);
        }
        Instantiate(BulletSplat, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
//        Debug.Log("destroying this");
        //Destroy(gameObject.transform.GetChild(1).gameObject);
        //Destroy(gameObject, ParentExpireTime);
        Destroy(gameObject);
    }
}