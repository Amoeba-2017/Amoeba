using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{

    //debug Mode
    [HideInInspector]
    public bool debugMode = false;

    [SerializeField] [Tooltip("The Red Player Prefab")]
    private GameObject playerRedPrefab;

    [SerializeField] [Tooltip("The Blue Player Prefab")]
    private GameObject playerBluePrefab;

    [SerializeField] [Tooltip("The Yellow Player Prefab")] 
    private GameObject playerYellowPrefab;

    [SerializeField] [Tooltip("The Purple Player Prefab")]
    private GameObject playerPurplePrefab;

    //the amount of players that are in the game
    [HideInInspector]
    public int playerCount = 0;

    //a list for every controller connected
    [HideInInspector]
    public List<XboxController> controllers = new List<XboxController>();

    //a list for every player in the scene 
    private List<GameObject> players = new List<GameObject>();

    //a referance to the User Interface Manager
    private UserInterfaceManager uim;

    //bool to see if the players need to be spawned yet
    [HideInInspector]
    public bool spawnPlayers = true;

    [SerializeField] [Tooltip("The Puddle Player Prefab")] 
    private GameObject puddle;

    [SerializeField] [Tooltip("The Min Amount of Time for A Slime Puddle To Spawn")]
    float minPuddleSpawnTime;

    [SerializeField] [Tooltip("The Min Amount of Time for A Slime Puddle To Spawn")] 
    float maxPuddleSpawnTime;


    //the random number between min and max for the puddle Spawner
    private float minMaxPuddleTime;

    //the timer for the puddles
    float puddleTimer;

    [SerializeField]
    private Material WTFMaterial;


    // Use this for initialization
    void Awake()
    {
        //remove the mouse from the game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //dont destroy the gamemanger between scenes
        DontDestroyOnLoad(gameObject);

        //if there is more then one gamemanager destroy all of them exept one
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        //the referance to the user interface manager
        uim = gameObject.GetComponent<UserInterfaceManager>();

        //making sure that the players are going to be spawned
        spawnPlayers = true;

        //find a random number between min and max puddle spawn times
        minMaxPuddleTime = Random.Range(minPuddleSpawnTime, maxPuddleSpawnTime);
    }

    void Update()
    {

        //if in the game scene
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            //incress the puddle spawn timer
            puddleTimer += Time.deltaTime;

            //spawn the players if they dont exist
            if (spawnPlayers == true)
            {
                loadPlayers();
                spawnPlayers = false;
            }


            //spawns a random puddle
            SpawnPuddle();

        }

        //if the userInterfaceManager exist
        if (uim != null)
        {
            //if the current canvas is playerSelect 
            if (uim.CurrentGameState == UserInterfaceManager.GameState.PlayerSelect)
            {
                //add a player if any of the controllers press a
                for (int i = 1; i < 5; i++)
                {
                    if (XCI.GetButtonDown(XboxButton.A, (XboxController)i) && !controllers.Contains((XboxController)i))
                    {
                        controllers.Add((XboxController)i);
                        uim.AddPlayer();
                    }
                }

            }
        }

        //check the if debug is true
        DebugUpdate();
    }

    void SpawnPuddle()
    {
        // if the timer is greater then the spawn time
        if (puddleTimer > minMaxPuddleTime)
        {
            //find a new random time
            minMaxPuddleTime = Random.Range(minPuddleSpawnTime, maxPuddleSpawnTime);

            //reset the timer
            puddleTimer = 0;

            //find all the puddle Spawners in the scene
            GameObject[] ts = GameObject.FindGameObjectsWithTag("PuddleSpawners");

            //the amout of times been though the loop
            int amountOfLoops = 0;

            while (true)
            {
                amountOfLoops++;

                //if the loop has been thought more then there are spawn points
                if (amountOfLoops >= ts.Length)
                {
                    break;
                }

                //find a random number between 
                int randomNumber = Random.Range(0, ts.Length - 1);

                //get a random puddle Spawner
                GameObject x = ts[randomNumber];

                //spawn the random puddle
                if (x != null)
                {
                    if (x.transform.childCount == 0)
                    {
                        GameObject i = Instantiate(puddle, x.transform.position + transform.up * 10, Quaternion.identity);
                        i.GetComponent<SlimePuddle>().ShootOut = false;
                        i.transform.SetParent(x.transform);
                        break;
                    }
                    else
                    {
                        ts[randomNumber] = null;
                    }
                }
            }
        }
    }

    void DebugUpdate()
    {
        //if "b" "u " "g" is pressed all at once turn debug mode on
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

        //if debug mode is on
        if (debugMode == true)
        {

            if (Input.GetKey("w"))
            {
                if (Input.GetKey("t"))
                {
                    if (Input.GetKeyDown("f"))
                    {
                        GameObject[] allGO = GameObject.FindObjectsOfType<GameObject>();
                        foreach (var i in allGO)
                        {
                            i.GetComponent<Renderer>().material = WTFMaterial;
                        }
                    }
                }
            }

                        //turn on the mouse
                        Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //if we are in playerselect and the space key is pressed add a debug player
            if (uim.CurrentGameState == UserInterfaceManager.GameState.PlayerSelect)
            { 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    uim.AddPlayer();
                    playerCount++;
                    //if controller none use keybored
                    controllers.Add(XboxController.None);
                }
            }

        }
    }

    private void loadPlayers()
    {
        //pick a spawn point and make a player for each controller 
        GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (GameObject.FindGameObjectWithTag("PlayerRed") == false)
        {
            if (controllers.Count >= 1)
            {
                GameObject temp = Instantiate(playerRedPrefab, spawnpoints[0].transform.position, Quaternion.identity);
                //add a player to the list
                players.Add(temp);
                //set this players controller to the person that hit "A"
                temp.GetComponent<PlayerController>().SetController(controllers[0]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerYellow") == false)
        {
            if (controllers.Count >= 2)
            {
                GameObject temp = Instantiate(playerYellowPrefab, spawnpoints[1].transform.position, Quaternion.identity);
                //add a player to the list
                players.Add(temp);
                //set this players controller to the person that hit "A"
                temp.GetComponent<PlayerController>().SetController(controllers[1]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerBlue") == false)
        {
            if (controllers.Count >= 3)
            {
                GameObject temp = Instantiate(playerBluePrefab, spawnpoints[2].transform.position, Quaternion.identity);
                //add a player to the list
                players.Add(temp);
                //set this players controller to the person that hit "A"
                temp.GetComponent<PlayerController>().SetController(controllers[2]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerPurple") == false)
        {
            if (controllers.Count >= 4)
            {
                GameObject temp = Instantiate(playerPurplePrefab, spawnpoints[3].transform.position, Quaternion.identity);
                //add a player to the list
                players.Add(temp);
                //set this players controller to the person that hit "A"
                temp.GetComponent<PlayerController>().SetController(controllers[3]);
            }
        }

    }

    public List<GameObject> Players
    {
        //getter
        get
        {
            return players;
        }

    }

}
