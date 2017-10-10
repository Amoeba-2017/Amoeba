using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{

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


    private List<GameObject> players = new List<GameObject>();

    private UserInterfaceManager uim;

    private List<InputDevice> inputDivices = new List<InputDevice>();


    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") != true)
        {
            DontDestroyOnLoad(gameObject);
        }
        uim = gameObject.GetComponent<UserInterfaceManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if (uim != null)
        {
            if (uim.currentCanvas == UserInterfaceManager.CanvasCount.playerSelect)
            {
                foreach (InputDevice x in InputManager.Devices)
                {
                    if (x.Action1.WasPressed)
                    {
                        if (inputDivices.Contains(x) == false)
                        {
                            Debug.Log("add a player");
                            playerCount++;
                            uim.AddPlayer();
                            inputDivices.Add(x);
                        }

                    }
                }
            }

            InputDevice removeFromArray = null;

            foreach (InputDevice i in inputDivices)
            {
                if (i.Action2.WasPressed)
                {
                    uim.RemovePlayer();

                    playerCount--;
                    removeFromArray = i;
                    Debug.Log("removePlayer");
                }

                if (playerCount > InputManager.Devices.Count + 1)
                {
                    Debug.Log("too many players");
                    uim.RemovePlayer();
                    playerCount--;
                }
            }


            if (removeFromArray != null)
            {
                inputDivices.Remove(removeFromArray);
            }
        }


        //if(inputDivices.Count == 4)
        //{
        //    SceneManager.LoadScene(1);
        //}


        //TEMP
        if (players.Count == 0)
        {
            players.Add(GameObject.FindGameObjectWithTag("PlayerRed"));
        }

        DebugUpdate();
    }



    void DebugUpdate()
    {
        if (Input.GetKey("b"))
        {
            if (Input.GetKey("u"))
            {
                if (Input.GetKeyDown("g"))
                {
                    debugMode = !debugMode;
                    Debug.Log("debug mode = " + debugMode);
                }
            }
        }

        if (debugMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // if (playerCount < maxPlayerCount)
                // {
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
                // }

            }
        }
    }


    public void SpawnPlayers()
    {
        if (playerCount >= 1)
        {
            Instantiate(playerRedPrefab);
        }
        if (playerCount >= 2)
        {
            Instantiate(playerRedPrefab);
        }
        if (playerCount >= 3)
        {
            Instantiate(playerRedPrefab);
        }
        if (playerCount >= 4)
        {
            Instantiate(playerRedPrefab);
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
