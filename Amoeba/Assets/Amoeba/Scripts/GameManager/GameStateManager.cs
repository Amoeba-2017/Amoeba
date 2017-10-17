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
    public int maxRounds;


    [HideInInspector]
    public int playerCount = 1;


    private List<GameObject> players = new List<GameObject>();

    private UserInterfaceManager uim;

    [HideInInspector]
    public List<InputDevice> inputDevices = new List<InputDevice>();

    [HideInInspector]
    public bool spawnPlayers = true;


    // Use this for initialization
    void Awake()
    {
        maxRounds = 3;
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        uim = gameObject.GetComponent<UserInterfaceManager>();
        spawnPlayers = true;

        foreach (InputDevice x in InputManager.Devices)
        {
            Debug.Log(x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (spawnPlayers == true)
            {
                loadPlayers();
                spawnPlayers = false;
            }
        }

        if (uim != null)
        {
            if (uim.currentCanvas == UserInterfaceManager.CanvasCount.playerSelect)
            {
                foreach (InputDevice x in InputManager.Devices)
                {
                    if (x == InputManager.ActiveDevice)
                    {

                        if (x.DPadUp.WasPressed || x.LeftStick.Up.WasPressed)
                        {
                            if (maxRounds < 30)
                            {
                                maxRounds++;
                                uim.maxRoundText.text = maxRounds.ToString();
                            }
                        }
                        else if (x.DPadDown.WasPressed || x.LeftStick.Down.WasPressed)
                        {
                            if (maxRounds > 1)
                            {
                                maxRounds--;
                                uim.maxRoundText.text = maxRounds.ToString();

                            }

                        }
                        if (x.Action1.WasPressed)
                        {
                            if (inputDevices.Contains(x) == false)
                            {
                                Debug.Log("add a player");
                                playerCount++;
                                uim.AddPlayer();
                                inputDevices.Add(x);
                            }

                        }

                    }


                    InputDevice removeFromArray = null;

                    foreach (InputDevice i in inputDevices)
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
                        inputDevices.Remove(removeFromArray);
                    }
                }
            }


            //if(inputDivices.Count == 4)
            //{
            //    SceneManager.LoadScene(1);
            //}

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
                    players.Add(Instantiate(playerYellowPrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                }
                else if (playerCount == 3)
                {
                    players.Add(Instantiate(playerBluePrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                }
                else
                {
                    players.Add(Instantiate(playerPurplePrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
                }
                // }

            }
        }
    }


    private void loadPlayers()
    {
        GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Debug.Log(inputDevices.Count);
        if (GameObject.FindGameObjectWithTag("PlayerRed") == false)
        {
            if (inputDevices.Count >= 1)
            {
                Debug.Log("added Red Player");
                GameObject temp = Instantiate(playerRedPrefab, spawnpoints[0].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(inputDevices[0]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerYellow") == false)
        {
            if (inputDevices.Count >= 2)
            {
                GameObject temp = Instantiate(playerYellowPrefab, spawnpoints[1].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(inputDevices[1]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerBlue") == false)
        {
            if (inputDevices.Count >= 3)
            {
                GameObject temp = Instantiate(playerBluePrefab, spawnpoints[2].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(inputDevices[2]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerPurple") == false)
        {
            if (inputDevices.Count >= 3)
            {
                GameObject temp = Instantiate(playerPurplePrefab, spawnpoints[3].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(inputDevices[3]);
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
