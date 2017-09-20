using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    [HideInInspector]
    public bool debugMode = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey("b"))
        {
            if(Input.GetKey("u"))
            {
                if (Input.GetKey("g"))
                {
                    debugMode = true;
                    Debug.Log("debug Turned on");
                }            
            }
        }	
	}
}
