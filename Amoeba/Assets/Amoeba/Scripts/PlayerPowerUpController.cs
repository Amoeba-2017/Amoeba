using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpController : MonoBehaviour {

    private PlayerController playerController;

	// Use this for initialization
	void Start ()
    {
        playerController = gameObject.GetComponent<PlayerController>();	
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "IncreasedSpeed")
        {
            playerController.increasedSpeedPowerUp();

            Debug.Log("IncreasedSpeed!");

        }
    }
}
