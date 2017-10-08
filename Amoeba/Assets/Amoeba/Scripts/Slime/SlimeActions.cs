﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeActions : MonoBehaviour {

    // GameObject-type variable for the projectile
    [SerializeField]
    private GameObject projectileShot;

    // The speed of the projectile
    [SerializeField]
    private float projectileShotSpeed;

    // The time that, when reached, will cause the projectile to be destroyed
    [SerializeField]
    private float destroyTimer;

    [SerializeField]
    private GameObject slime;

    private SlimeMovement slimeMovement;

    private PlayerController playerController;

    // Use this for initialization
    void Start ()
    {
        slimeMovement = gameObject.GetComponent<SlimeMovement>();

    }


    public void Shoot(Vector3 rot)
    {
        Debug.Log(rot);
        if (rot != Vector3.zero)
        {
            // Create a Bullet object
            GameObject Bullet;

            Bullet = Instantiate(projectileShot, transform.position + (rot * 2), Quaternion.identity);

            // Get the object (Bullet) and add the force to it
            Bullet.GetComponent<Rigidbody>().AddForce(rot * projectileShotSpeed, ForceMode.Impulse);

            // Destroy the Bullet when the DestroyTimer has been reached
            Destroy(Bullet, destroyTimer);

        }
    }


    public void Split(float amount)
    {
        Debug.Log(amount);

        if (playerController == null)
        {
            playerController = slimeMovement.player.GetComponent<PlayerController>();
        }
        playerController.slimes.Remove(gameObject);

        if (amount == 0)
        {
            playerController.slimeRandomDistanceToPlayer = 2.5f;
            playerController.speed = 15.5f;

            newSlime(2f, 1);
            newSlime(2f, 1);
        }
        else if(amount == 1)
        {
            
            playerController.speed = 15.7f;

            newSlime(1.5f, 2);
            newSlime(1.5f, 2);
            newSlime(1.5f, 2);
        }

        else if(amount == 2)
        {
            playerController.speed = 16;

            newSlime(1f, 3);
            newSlime(1f, 3);
            newSlime(1f, 3);
            newSlime(1f, 3);
        }


    }


    void newSlime(float size , float amount)
    {
        GameObject tempSlime = Instantiate(slime, transform.position, transform.rotation);
        playerController.slimes.Add(tempSlime);
        tempSlime.GetComponent<SlimeMovement>().parent = slimeMovement.parent;
        tempSlime.GetComponent<SlimeHealth>().amountOfSplits = amount;
        tempSlime.transform.localScale = new Vector3(size, size, size);
    }



    // Update is called once per frame
}
