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

    bool isPaused = false;

    bool firstRun;

    private ControllerUISelection currentControllerUISelection;

    float countDown = 0.0f;

    Coroutine co;

    public GameState CurrentGameState;

    public enum ControllerUISelection
    {
        play,
        exit,
    }

    public enum GameState
    {
        MainMenu,
        PlayerSelect,
        GameScene,
        GameOver,
        Pause

    };



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
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            if (firstRun == true)
            {
                co = StartCoroutine(GameTimer(roundTime));
                firstRun = false;
            }

            

            // Game Canvas Detections
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

            if (timerCanvas != null)
            {
                currentTimer += Time.deltaTime;
                countDown = ((roundTime * 60) - currentTimer);
                string minutes = Mathf.Floor(countDown / 60).ToString("0");
                string seconds = (countDown % 60).ToString("00");
                if (seconds == "60")
                {
                    seconds = "00";
                    minutes = (int.Parse(minutes) + 1).ToString();
                }
                if (float.Parse(minutes) <= 0.0f && float.Parse(seconds) <= 0.0f)
                {
                    timerCanvas.transform.GetChild(0).GetComponent<Text>().text = "0:00";
                }
                else
                {
                    timerCanvas.transform.GetChild(0).GetComponent<Text>().text = minutes.ToString() + ":" + seconds.ToString();
                }
            }

            //Pause menu
            if (XCI.GetButtonDown(XboxButton.Start, XboxController.All))
            {
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

        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            if(mainMenu == null)
            {
                mainMenu = GameObject.FindGameObjectWithTag("mainMenu").GetComponent<Canvas>();
            }

            if(selectScreen == null)
            {
                selectScreen = GameObject.FindGameObjectWithTag("selectScreen").GetComponent<Canvas>();
            }

            if (CurrentGameState == GameState.MainMenu)
            {

                //                if (Input.GetKeyDown(KeyCode.DownArrow) || XCI.GetButtonDown(XboxButton.DPadDown, XboxController.All) || XCI.GetAxis(XboxAxis.LeftStickY, XboxController.All) < -0.5f || Input.GetKeyDown(KeyCode.UpArrow) || XCI.GetButtonDown(XboxButton.DPadUp, XboxController.All) || XCI.GetAxis(XboxAxis.LeftStickY, XboxController.All) > 0.5f)
                if (Input.GetKeyDown(KeyCode.DownArrow) || XCI.GetButtonDown(XboxButton.DPadDown, XboxController.All) || Input.GetKeyDown(KeyCode.UpArrow) || XCI.GetButtonDown(XboxButton.DPadUp, XboxController.All))
                {
                    if (currentControllerUISelection == ControllerUISelection.play)
                    {
                        currentControllerUISelection = ControllerUISelection.exit;
                    }
                    else if (currentControllerUISelection == ControllerUISelection.exit)
                    {
                        currentControllerUISelection = ControllerUISelection.play;
                    }
                }


                if (currentControllerUISelection == ControllerUISelection.play)
                {
                    mainMenu.transform.GetChild(1).GetComponent<Button>().Select();
                }
                if (currentControllerUISelection == ControllerUISelection.exit)
                {
                    mainMenu.transform.GetChild(2).GetComponent<Button>().Select();
                }

                if (Input.GetKeyDown(KeyCode.KeypadEnter) || XCI.GetButtonDown(XboxButton.A, XboxController.All))
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
            if (CurrentGameState == GameState.PlayerSelect)
            {
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || XCI.GetButtonDown(XboxButton.Start, XboxController.All))
                {
                    if (gsm.controllers.Count > 1)
                    {
                        selectStartButton();
                    }
                }
            }
        }

        if (CurrentGameState == GameState.GameOver)
        {
            if (XCI.GetButton(XboxButton.A, XboxController.All))
            {
                RestartGame();
                Time.timeScale = 1f;
                CurrentGameState = GameState.GameScene;
            }
            else if(XCI.GetButton(XboxButton.B, XboxController.All))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(0);
                Destroy(gameObject);
                CurrentGameState = GameState.MainMenu;
            }
        }

        if(CurrentGameState == GameState.Pause)
        {
            if (XCI.GetButton(XboxButton.B, XboxController.All))
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
        yield return new WaitForSeconds(time * 60);
        GameObject highestGO = null;
        float highestPoints = float.MinValue;
        bool winner = true;

        foreach (GameObject x in gsm.Players)
        {
            float currentValue = x.GetComponent<PlayerUI>().score;
            if (currentValue > highestPoints)
            {
                highestPoints = currentValue;
                highestGO = x;
            }
        }

        foreach (GameObject x in gsm.Players)
        {
            float currentValue = x.GetComponent<PlayerUI>().score;

            if (currentValue == highestPoints && x != highestGO)
            {
                winner = false;
                break;
            }
        }

        if (winner == true)
        {
            foreach (GameObject x in gsm.Players)
            {
                Destroy(x.GetComponent<PlayerController>().slimes[0]);
                Destroy(x);
            }
            AudioManager.PlaySound("VictorySound");
            GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>().mute = true;
            gsm.Players.Clear();
            gsm.Players.Add(highestGO);
            selectWinner();
        }
        else
        {
            drawScreen.enabled = true;
        }


        Destroy(gsm.Players[0]);
        gsm.Players.Clear();
        CurrentGameState = GameState.GameOver;

    }

    public void RestartGame()
    {
        // Start function restartGame as a coroutine
        StopCoroutine(co);
        co = StartCoroutine(GameTimer(roundTime));
        gsm.spawnPlayers = true;
        currentTimer = 0;
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
            gsm.SpawnPlayers();
        }
    }


    private void selectWinner()
    {
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
        victoryScreen.enabled = true;
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
