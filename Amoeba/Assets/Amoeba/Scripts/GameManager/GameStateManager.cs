using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
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
    public int playerCount = 0;

    [HideInInspector]
    public List<XboxController> controllers = new List<XboxController>();


    private List<GameObject> players = new List<GameObject>();

    private UserInterfaceManager uim;


    [HideInInspector]
    public bool spawnPlayers = true;

    [SerializeField]
    private bool minMaxRandomSpawn;


    [SerializeField]
    private GameObject puddle;

    [SerializeField]
    float puddleIntervalTimer;

    [SerializeField]
    float minPuddleSpawnTime;

    [SerializeField]
    float maxPuddleSpawnTime;

    

    private float minMaxPuddleTime;

    float puddleTimer;

    // Use this for initialization
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        maxRounds = 3;
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        uim = gameObject.GetComponent<UserInterfaceManager>();
        spawnPlayers = true;

        minMaxPuddleTime = Random.Range(minPuddleSpawnTime, maxPuddleSpawnTime);
    }

    void Update()
    {

        //if in the game scene
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            //spawn the players if they dont exist
            if (spawnPlayers == true)
            {
                loadPlayers();
                spawnPlayers = false;
            }

            float highestMass = float.MinValue;
            GameObject higestGO = null;

            foreach (GameObject x in players)
            {
                float currentMass = x.GetComponent<PlayerController>().mass;
                if (currentMass > highestMass)
                {
                    highestMass = currentMass;
                    higestGO = x;
                }
            }

            if (higestGO != null)
            {
                higestGO.GetComponent<PlayerUI>().score += Time.deltaTime;
            }




            puddleTimer += Time.deltaTime;
            if (puddleTimer > minMaxPuddleTime)
            {
                minMaxPuddleTime = Random.Range(minPuddleSpawnTime, maxPuddleSpawnTime);
                puddleTimer = 0;


                GameObject[] ts = GameObject.FindGameObjectsWithTag("PuddleSpawners");

                int amountOfLoops = 0;

                while (true)
                {
                    amountOfLoops++;
                    if (amountOfLoops >= ts.Length)
                    {
                        break;
                    }


                    int randomNumber = Random.Range(0, ts.Length - 1);

                    GameObject x = ts[randomNumber];

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

            else
            {
                if (puddleTimer > puddleIntervalTimer)
                {
                    puddleTimer = 0;

                    GameObject[] ts = GameObject.FindGameObjectsWithTag("PuddleSpawners");

                    int amountOfLoops = 0;

                    while (true)
                    {
                        amountOfLoops++;
                        if (amountOfLoops >= ts.Length)
                        {
                            break;
                        }


                        int randomNumber = Random.Range(0, ts.Length - 1);

                        GameObject x = ts[randomNumber];

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
        }

        //if the userInterfaceManager exist
        if (uim != null)
        {
            //if the current canvas is playerSelect 
            if (uim.currentCanvas == UserInterfaceManager.CanvasCount.playerSelect)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (XCI.GetButtonDown(XboxButton.A, (XboxController)i) && !controllers.Contains((XboxController)i))
                    {
                        controllers.Add((XboxController)i);
                        uim.AddPlayer();
                    }
                }

                //if (playerCount == 1)
                //{ 
                //    controllers.Add(XboxController.First);
                //    uim.AddPlayer();
                //}
                //else if (playerCount == 2)
                //{
                //    controllers.Add(XboxController.Second);
                //    uim.AddPlayer();
                //}
                //else if (playerCount == 3)
                //{
                //    controllers.Add(XboxController.Third);
                //    uim.AddPlayer();
                //}
                //else if (playerCount == 4)
                //{
                //    controllers.Add(XboxController.Fourth);
                //    uim.AddPlayer();
                //}
                //if(playerCount > 4)
                //{
                //    playerCount = 4;
                //}

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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (uim.currentCanvas == UserInterfaceManager.CanvasCount.playerSelect)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    uim.AddPlayer();
                    playerCount++;
                    controllers.Add(XboxController.None);
                }
            }

        }

        //if (debugMode == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        // if (playerCount < maxPlayerCount)
        //        // {
        //        playerCount++;
        //        if (playerCount == 1)
        //        {
        //            players.Add(Instantiate(playerRedPrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
        //        }
        //        else if (playerCount == 2)
        //        {
        //            players.Add(Instantiate(playerYellowPrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
        //        }
        //        else if (playerCount == 3)
        //        {
        //            players.Add(Instantiate(playerBluePrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
        //        }
        //        else
        //        {
        //            players.Add(Instantiate(playerPurplePrefab, new Vector3(7f, 47.376f, -131.3f), Quaternion.identity));
        //        }
        //        // }

        //    }
        //}
    }


    private void loadPlayers()
    {
        GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (GameObject.FindGameObjectWithTag("PlayerRed") == false)
        {
            if (controllers.Count >= 1)
            {
                GameObject temp = Instantiate(playerRedPrefab, spawnpoints[0].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(controllers[0]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerYellow") == false)
        {
            if (controllers.Count >= 2)
            {
                GameObject temp = Instantiate(playerYellowPrefab, spawnpoints[1].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(controllers[1]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerBlue") == false)
        {
            if (controllers.Count >= 3)
            {
                GameObject temp = Instantiate(playerBluePrefab, spawnpoints[2].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(controllers[2]);
            }
        }

        if (GameObject.FindGameObjectWithTag("PlayerPurple") == false)
        {
            if (controllers.Count >= 4)
            {
                GameObject temp = Instantiate(playerPurplePrefab, spawnpoints[3].transform.position, Quaternion.identity);
                players.Add(temp);
                temp.GetComponent<PlayerController>().SetController(controllers[3]);
            }
        }

    }

    public void SpawnPlayers()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
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
    }

    public List<GameObject> Players
    {

        get
        {
            return players;
        }

    }

}
