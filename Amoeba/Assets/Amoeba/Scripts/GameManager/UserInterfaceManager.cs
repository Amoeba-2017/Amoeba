using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;
public class UserInterfaceManager : MonoBehaviour
{
    // Menu Canvases
    [SerializeField]
    [Tooltip("Canvas for the Main Menu.")]
    private Canvas mainMenu;        // Main Menu
    [SerializeField]
    [Tooltip("Canvas for the Player/Slime Selection Menu.")]
    private Canvas selectScreen;    // Player/Slime Selection
    [SerializeField]
    [Tooltip("Canvas for the Credits Screen.")]
    private Canvas creditsScreen;   // Credits Screen
    private Canvas pauseScreen;     // Pause Screen
    private Canvas victoryScreen;   // Victory Screen
    private Canvas timerCanvas;     // Timer

    private Canvas drawScreen;

    // Slime Icon Sprites
    [SerializeField]
    [Tooltip("Sprite for the Red Slime icon.")]
    private Sprite redSlime;        // Colored
    private Sprite redSlimebw;      // Black & White
    [SerializeField]
    [Tooltip("Sprite for the Yellow Slime icon.")]
    private Sprite yellowSlime;     // Colored
    private Sprite yellowSlimebw;   // Black & White
    [SerializeField]
    [Tooltip("Sprite for the Blue Slime icon.")]
    private Sprite blueSlime;       // Colored
    private Sprite blueSlimebw;     // Black & White
    [SerializeField]
    [Tooltip("Sprite for the Purple Slime icon.")]
    private Sprite purpleSlime;     // Colored
    private Sprite purpleSlimebw;   // Black & White

    // Round Timer
    // Intergers represents minutes (i.e. 1f == 1 minute)
    [SerializeField]
    [Tooltip("Amount of minutes for each round.")]
    private float roundTime;

    // Current Timer
    // Counts seconds mid-round
    private float currentTimer;

    // Game State Manager
    private GameStateManager gsm;

    // Amount of Players
    private int currentAmountofPlayers;

    // List of sprites
    private List<Image> sprites = new List<Image>();

    //a bool to see if the game is paused or not
    bool isPaused = false;

    //the first run of update
    bool firstRun;

    //for ui controller use
    bool axisInUse = false;

    //the current selection for UI using a controller
    private ControllerUISelection currentControllerUISelection;

    //the game time count down for ui only
    float gameCountDownTimer = 0.0f;

    //the game time for code only
    Coroutine gameCoroutineCountdown;

    //the current gameState
    public GameState CurrentGameState;

    //the mesh for the main screen
    [SerializeField]
    private GameObject mainScreenMesh;

    //an enum for changing ui buttons using a controller
    public enum ControllerUISelection
    {
        play,
        exit,
    }

    //a enum to control what point you are upto in the game
    public enum GameState
    {
        MainMenu,
        PlayerSelect,
        Credits,
        GameScene,
        GameOver,
        Pause

    };

    [SerializeField]
    private GameObject UICrowm;

    // Initialization
    void Start()
    {
        firstRun = true;
        currentControllerUISelection = ControllerUISelection.play;
        CurrentGameState = GameState.MainMenu;
        gsm = gameObject.GetComponent<GameStateManager>();
        redSlimebw = (selectScreen.transform.GetChild(0).GetComponent<Image>().sprite);
        yellowSlimebw = (selectScreen.transform.GetChild(1).GetComponent<Image>().sprite);
        blueSlimebw = (selectScreen.transform.GetChild(2).GetComponent<Image>().sprite);
        purpleSlimebw = (selectScreen.transform.GetChild(3).GetComponent<Image>().sprite);
    }

    // Update (Per Frame)
    void Update()
    {
        //if the current scene is not the menu scene (the Gamescene)
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            //first run of Update start the coroutine to count down the game Timer
            if (firstRun == true)
            {
             //   gameCoroutineCountdown = StartCoroutine(GameTimer(roundTime));
                firstRun = false;

                // check to see if all of the canvas are refrenced properly 
                if (victoryScreen == null)
                {
                    victoryScreen = GameObject.FindGameObjectWithTag("VictoryScreen").transform.GetComponent<Canvas>();
                }
                if (pauseScreen == null)
                {
                    pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen").transform.GetComponent<Canvas>();
                }
                if (drawScreen == null)
                {
                    drawScreen = GameObject.FindGameObjectWithTag("DrawCanvas").transform.GetComponent<Canvas>();
                }
                if (timerCanvas == null)
                {
                    timerCanvas = GameObject.FindGameObjectWithTag("TimerCanvas").transform.GetComponent<Canvas>();
                }

            }

            //UItimerUpdate();

            PauseCheck();
        }

        //if the current scene is the main menu
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            
            //check references
            if (mainMenu == null)
            {
                mainMenu = GameObject.FindGameObjectWithTag("mainMenu").GetComponent<Canvas>();
            }
            if (creditsScreen == null)
            {
                selectScreen = GameObject.FindGameObjectWithTag("creditsScreen").GetComponent<Canvas>();
            }
            if (selectScreen == null)
            {
                selectScreen = GameObject.FindGameObjectWithTag("selectScreen").GetComponent<Canvas>();
            }

            menuStateUpdate();
        }

        GameStateUpdate();
    }

    void UItimerUpdate()
    {
        if (timerCanvas != null)
        {
            //tick the current timer counting up
            currentTimer += Time.deltaTime;

            //the time of the game counting down
            gameCountDownTimer = ((roundTime * 60) - currentTimer);

            //find the string value of the time in minutes
            string minutes = Mathf.Floor(gameCountDownTimer / 60).ToString("0");

            //find the string value of the time in seconds
            string seconds = (gameCountDownTimer % 60).ToString("00");

            //if the seconds is 60 make it 0 and make sure the timer reads x:00 instade of x:60
            if (seconds == "60")
            {
                seconds = "00";
                minutes = (int.Parse(minutes) + 1).ToString();
            }

            //make sure the timer doesnt go into negitive
            if (float.Parse(minutes) <= 0.0f && float.Parse(seconds) <= 0.0f)
            {
                timerCanvas.transform.GetChild(0).GetComponent<Text>().text = "0:00";
            }

            //if the time is not negitive show it
            else
            {
                timerCanvas.transform.GetChild(0).GetComponent<Text>().text = minutes.ToString() + ":" + seconds.ToString();
            }
        }
    }

    void PauseCheck()
    {
        //Pause menu
        //if anyone presses start
        if (XCI.GetButtonDown(XboxButton.Start, XboxController.All))
        {
            //if the game is paused, unpause (or the other way round)
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseScreen.enabled = true;
                Time.timeScale = 0.0f;
                CurrentGameState = GameState.Pause;
            }
            else
            {
                Time.timeScale = 1.0f;
                pauseScreen.enabled = false;
                CurrentGameState = GameState.GameScene;
            }
        }
    }

    void menuStateUpdate()
    {
        //if the current gamestate is main menu
        if (CurrentGameState == GameState.MainMenu)
        {
            if (mainScreenMesh.activeInHierarchy == false)
            {
                mainScreenMesh.SetActive(true);
            }
            //if up or down is pressed switch current selected UI
            if ((Input.GetKeyDown(KeyCode.DownArrow) || XCI.GetButtonDown(XboxButton.DPadDown, XboxController.First) || XCI.GetAxisRaw(XboxAxis.LeftStickY, XboxController.First) > 0 || XCI.GetAxisRaw(XboxAxis.LeftStickY, XboxController.First) < 0 || Input.GetKeyDown(KeyCode.UpArrow) || XCI.GetButtonDown(XboxButton.DPadUp, XboxController.First)) && axisInUse == false)
            {
                axisInUse = true;
                if (currentControllerUISelection == ControllerUISelection.play)
                {
                    currentControllerUISelection = ControllerUISelection.exit;
                    UICrowm.transform.position += new Vector3(0, -2.5f, 0);
                }
                else if (currentControllerUISelection == ControllerUISelection.exit)
                {
                    UICrowm.transform.position += new Vector3(0, 2.5f, 0);
                    currentControllerUISelection = ControllerUISelection.play;
                }
                Debug.Log(axisInUse);
            }

            if (XCI.GetAxisRaw(XboxAxis.LeftStickY, XboxController.First) == 0)
            {
                axisInUse = false;
            }

            //current selected ui is highlighted
            if (currentControllerUISelection == ControllerUISelection.play)
            {
                mainMenu.transform.GetChild(1).GetComponent<Button>().Select();
            }
            if (currentControllerUISelection == ControllerUISelection.exit)
            {
                mainMenu.transform.GetChild(2).GetComponent<Button>().Select();
            }

            //if enter or a is pressed select current highlighted ui
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || XCI.GetButtonDown(XboxButton.A, XboxController.First))
            {
                if (currentControllerUISelection == ControllerUISelection.play)
                {
                    mainStartButton();
                }
                if (currentControllerUISelection == ControllerUISelection.exit)
                {
                    mainQuitButton();
                }
            }
        }

        //if current game state is playerselect and enter or a is pressed and and there is more then one player
        if (CurrentGameState == GameState.PlayerSelect)
        {
            if (mainScreenMesh.activeInHierarchy == true)
            {
                mainScreenMesh.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter) || XCI.GetButtonDown(XboxButton.Start, XboxController.First))
            {
                if (gsm.controllers.Count > 1)
                {
                    //start the game
                    selectStartButton();
                }
            }
        }
    }

    void GameStateUpdate()
    {
        //if the current game state is gameover 
        if (CurrentGameState == GameState.GameOver)
        {
            //if a is hit restart the game
            if (XCI.GetButtonDown(XboxButton.A, XboxController.First))
            {
                RestartGame();
                Time.timeScale = 1f;
                CurrentGameState = GameState.GameScene;
            }
            //if b is pressed return to the menu
            else if (XCI.GetButtonDown(XboxButton.B, XboxController.First))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(0);
                Destroy(gameObject);
                CurrentGameState = GameState.MainMenu;
            }
        }

        //if the current GameState is on the pause menu
        if (CurrentGameState == GameState.Pause)
        {
            //if b is pressed return to the menu
            if (XCI.GetButton(XboxButton.B, XboxController.First))
            {
                Time.timeScale = 1.0f;
                pauseScreen.enabled = false;
                SceneManager.LoadScene(0);
                Destroy(gameObject);
                CurrentGameState = GameState.MainMenu;
            }
        }
    }

    IEnumerator GameTimer(float time)
    {
        //wait to run this code till the timer runs out
        yield return new WaitForSeconds(time * 60);

        //find the gameobject with the highest score
        GameObject highestGO = null;
        float highestPoints = float.MinValue;
        bool winner = true;

        //go though each player and find who has the highest score
        foreach (GameObject x in gsm.Players)
        {
            float currentValue = x.GetComponent<PlayerUI>().score;
            if (currentValue > highestPoints)
            {
                highestPoints = currentValue;
                highestGO = x;
            }
        }

        //check to see if it isnt a draw
        foreach (GameObject x in gsm.Players)
        {
            float currentValue = x.GetComponent<PlayerUI>().score;

            if (currentValue == highestPoints && x != highestGO)
            {
                winner = false;
                break;
            }
        }

        //if there was a winner destroy all players/slimes and select the winner
        if (winner == true)
        {
            foreach (GameObject x in gsm.Players)
            {
                Destroy(x.GetComponent<PlayerController>().slimes[0]);
                Destroy(x);
            }

            //play the victory sound
            AudioManager.PlaySound("VictorySound");
            //mute the game music
            GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>().mute = true;
            gsm.Players.Clear();
            gsm.Players.Add(highestGO);
            selectWinner();
        }
        else
        {
            //show the draw screen
            drawScreen.enabled = true;
        }


        Destroy(gsm.Players[0]);
        gsm.Players.Clear();
        CurrentGameState = GameState.GameOver;

    }

    public void RestartGame()
    {
        //restarts the game 

        //stop the old coroutine
        //StopCoroutine(gameCoroutineCountdown);

        //start a new coroutine
        //gameCoroutineCountdown = StartCoroutine(GameTimer(roundTime));

        //spawn new players
        gsm.spawnPlayers = true;
        currentTimer = 0;
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>().mute = false;
        firstRun = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //===============================================
    // Button Functions
    //===============================================

    // Button function for the Main Menu 'Start' button
    public void mainStartButton()
    {
        CurrentGameState = GameState.PlayerSelect;
        mainMenu.enabled = false;
        selectScreen.enabled = true;
    }

    // Button function for the Main Menu 'Quit' button
    public void mainQuitButton()
    {
        Application.Quit();
    }

    // Button function for the Player Select 'Start' button
    public void selectStartButton()
    {
        if (currentAmountofPlayers > 1)
        {
            CurrentGameState = GameState.GameScene;
            SceneManager.LoadScene(1);
        }
    }

    public void selectWinner()
    {
        //check the last player aginst all the players tags
        if (gsm.Players[0].tag == "PlayerRed")
        {
            victoryScreen.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = redSlime;
        }
        if (gsm.Players[0].tag == "PlayerBlue")
        {
            victoryScreen.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = blueSlime;
        }
        if (gsm.Players[0].tag == "PlayerYellow")
        {
            victoryScreen.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = yellowSlime;
        }
        if (gsm.Players[0].tag == "PlayerPurple")
        {
            victoryScreen.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = purpleSlime;
        }

        CurrentGameState = GameState.GameOver;
        victoryScreen.enabled = true;
        Destroy(gsm.Players[0].GetComponent<PlayerController>().slimes[0]);
        Destroy(gsm.Players[0]);
        GameObject.FindGameObjectWithTag("Crown").transform.position = new Vector3(0, -10, 0);
        gsm.Players.Clear();


    }
    public void AddPlayer()
    {
        currentAmountofPlayers++;

        if (currentAmountofPlayers == 1)
        {
            if (selectScreen.transform.GetChild(0).GetComponent<Image>().sprite != redSlime)
            {
                selectScreen.transform.GetChild(0).GetComponent<Image>().sprite = redSlime;
                selectScreen.transform.GetChild(0).GetChild(1).GetComponent<Image>().enabled = false;
            }
        }
        if (currentAmountofPlayers == 2)
        {
            if (selectScreen.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlime)
            {
                selectScreen.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlime;
                selectScreen.transform.GetChild(1).GetChild(1).GetComponent<Image>().enabled = false;
            }
        }
        if (currentAmountofPlayers == 3)
        {
            if (selectScreen.transform.GetChild(2).GetComponent<Image>().sprite != blueSlime)
            {
                selectScreen.transform.GetChild(2).GetComponent<Image>().sprite = blueSlime;
                selectScreen.transform.GetChild(2).GetChild(1).GetComponent<Image>().enabled = false;
            }
        }
        if (currentAmountofPlayers == 4)
        {
            if (selectScreen.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlime)
            {
                selectScreen.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlime;
                selectScreen.transform.GetChild(3).GetChild(1).GetComponent<Image>().enabled = false;
            }
        }
    }

    public void RemovePlayer()
    {
        if (currentAmountofPlayers == 4)
        {
            if (selectScreen.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlimebw)
            {
                selectScreen.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlimebw;
                selectScreen.transform.GetChild(3).GetChild(1).GetComponent<Image>().enabled = true;
            }
        }
        if (currentAmountofPlayers == 3)
        {
            if (selectScreen.transform.GetChild(2).GetComponent<Image>().sprite != blueSlimebw)
            {
                selectScreen.transform.GetChild(2).GetComponent<Image>().sprite = blueSlimebw;
                selectScreen.transform.GetChild(2).GetChild(1).GetComponent<Image>().enabled = true;
            }
        }
        if (currentAmountofPlayers == 2)
        {
            if (selectScreen.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlimebw)
            {
                selectScreen.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlimebw;
                selectScreen.transform.GetChild(1).GetChild(1).GetComponent<Image>().enabled = false;
            }
        }
        if (currentAmountofPlayers == 1)
        {
            if (selectScreen.transform.GetChild(0).GetComponent<Image>().sprite != redSlimebw)
            {
                selectScreen.transform.GetChild(0).GetComponent<Image>().sprite = redSlimebw;
                selectScreen.transform.GetChild(0).GetChild(1).GetComponent<Image>().enabled = true;
            }
        }

        currentAmountofPlayers--;
    }
}
