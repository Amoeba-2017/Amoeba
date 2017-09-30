using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class GameStateManager : MonoBehaviour {

    [HideInInspector]
    public bool debugMode = false;

    [SerializeField]
    private GameObject playerRedPrefab;

    [SerializeField]
    private GameObject playerBluePrefab;

    [SerializeField]
    private GameObject playerYellowPrefab;

    [SerializeField]
    private GameObject playerPurplePrefab;




    [HideInInspector]
    public int playerCount = 1;

    private int maxPlayerCount = 1;

    private List<GameObject> players = new List<GameObject>();


    // Use this for initialization
    void Start ()
    {
        maxPlayerCount = InputManager.Devices.Count + 1;
    }
	
	// Update is called once per frame
	void Update ()
    {

        //TEMP
        if(players.Count == 0)
        {
            players.Add(GameObject.FindGameObjectWithTag("PlayerRed"));
        }

	    if(Input.GetKey("b"))
        {
            if(Input.GetKey("u"))
            {
                if (Input.GetKeyDown("g"))
                {
                    debugMode = !debugMode;
                    Debug.Log("debug mode = " + debugMode);
                }            
            }
        }
        
        if(debugMode == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(playerCount < maxPlayerCount)
                {
                    playerCount++;
                    if (playerCount == 1)
                    {
                        players.Add(Instantiate(playerRedPrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                    }
                    else if (playerCount == 2)
                    {
                        players.Add(Instantiate(playerBluePrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                    }
                    else if (playerCount == 3)
                    {
                        players.Add(Instantiate(playerYellowPrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                    }
                    else
                    {
                        players.Add(Instantiate(playerPurplePrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                    }
                }
            }
        }	
	}


    public List<GameObject> Players
    {

        get
        {
            return players;
        }

    }

}
