﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{

    // Health stat of the Slimes
    //[SerializeField]
    //private float HeathPoints;

    // Is the Slime shielded?
    [HideInInspector]
    public bool IsShielded;

    // Damage a Slime takes from bullets
    [SerializeField]
    private float BulletDamagePercent = 5;

    // Amount of times a Slime has split
    //[HideInInspector]
    //public float amountOfSplits = 0;

    [SerializeField]
    private GameObject Puddle;

    [SerializeField]
    private float invincibilityFramesTime;

    private SlimeActions slimeAction;

    private bool firstColor;

    private Color color;

    private float colorTimer;

    public float massAdded;

    [SerializeField]
    float sizeMuliplyer;

    public bool isInvincible;

    private PlayerController playerC;

    private SlimeMovement slimeMovement;

    [SerializeField]
    private float slimeCollliderMulitplyer;

    public float massLoss;

    private SphereCollider slimeCollider;

    // Use this for initialization
    void Start()
    {
        //     HeathPoints = 1f;
        slimeCollider = gameObject.GetComponent<SphereCollider>();
        IsShielded = false;
        firstColor = true;
        slimeAction = gameObject.GetComponent<SlimeActions>();
        isInvincible = true;
        StartCoroutine(InvincibleFrames());
        slimeMovement = gameObject.GetComponent<SlimeMovement>();
        playerC = GameObject.FindGameObjectWithTag(slimeMovement.parent).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Backspace))
        //{
        //   // HeathPoints = 0;
        //    Debug.Log("split");
        //}

        gameObject.transform.GetChild(0).localScale = new Vector3((playerC.mass / 100) * sizeMuliplyer, (playerC.mass / 100) * sizeMuliplyer, (playerC.mass / 100) * sizeMuliplyer);
        slimeCollider.radius = ((playerC.mass / 100) * slimeCollliderMulitplyer);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (IsShielded == false)
            {
                if (isInvincible == false)
                {
                    if (playerC.mass > 30)
                    {
                        //gameObject.GetComponent<SlimeMovement>().flyingVel = col.rigidbody.velocity;
                        Vector3 randomRotDir = Vector3.zero;

                        int randomPos = Random.Range(1, 4);

                        if (randomPos == 1)
                        {
                            randomRotDir = ((transform.position + (Vector3.up * 2)) + transform.right * 3 + transform.forward * 3);
                        }
                        else if (randomPos == 2)
                        {
                            randomRotDir = ((transform.position + (Vector3.up * 2)) + -transform.right * 3 + transform.forward * 3);
                        }
                        else if (randomPos == 3)
                        {
                            randomRotDir = ((transform.position + (Vector3.up * 2)) + transform.right * 3 + -transform.forward * 3);
                        }
                        else if (randomPos == 4)
                        {
                            randomRotDir = ((transform.position + (Vector3.up * 2)) + -transform.right * 3 + -transform.forward * 3);
                        }

                        // Play getting hit sound
                        AudioManager.PlaySound("GettingHitSound");

                        GameObject puddle;
                        puddle = Instantiate(Puddle, randomRotDir, Quaternion.identity);
                        puddle.GetComponent<SlimePuddle>().ShootOut = true;
                        puddle.GetComponent<SlimePuddle>().SetMass(massAdded);
                        playerC.mass -= massLoss;
                    }
                }
            }
        }
    }

    public IEnumerator InvincibleFrames()
    {
        yield return new WaitForSeconds(invincibilityFramesTime);
        isInvincible = false;
    }
}