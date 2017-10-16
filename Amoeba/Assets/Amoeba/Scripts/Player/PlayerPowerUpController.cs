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


    public void Shield()
    {
        foreach(GameObject x in playerController.slimes)
        {
            x.GetComponent<SlimeHealth>().IsShielded = true;
        }   
    }

}
