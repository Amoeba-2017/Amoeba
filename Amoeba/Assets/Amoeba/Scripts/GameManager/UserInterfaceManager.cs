using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;

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

    public Text maxRoundText;

    bool isPaused = false;

    bool firstRun;

    private ControllerUISelection currentControllerUISelection;

    public enum ControllerUISelection
    {
        play,
        exit,
    }

    public enum CanvasCount
    {
        mainMenu,
        playerSelect,
        none
    };

    public CanvasCount currentCanvas;

    // Initialization
    void Start()
    {
        firstRun = true;
        currentControllerUISelection = ControllerUISelection.play;
        maxRoundText = selectScreen.transform.GetChild(5).gameObject.GetComponent<Text>();
        currentCanvas = CanvasCount.mainMenu;
        gsm = gameObject.GetComponent<GameStateManager>();
        redSlimebw = (selectScreen.transform.GetChild(0).GetComponent<Image>().sprite);
        yellowSlimebw = (selectScreen.transform.GetChild(1).GetComponent<Image>().sprite);
        blueSlimebw = (selectScreen.transform.GetChild(2).GetComponent<Image>().sprite);
        purpleSlimebw = (selectScreen.transform.GetChild(3).GetComponent<Image>().sprite);
    }

    // Update (Per Frame)
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if(firstRun == true)
            {
                StartCoroutine(GameTimer());
                Debug.Log("startedGametimer");
                firstRun = false;
            }

            currentTimer += Time.deltaTime;

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

            if(timerCanvas != null)
            {
                float countDown = ((roundTime * 60) - currentTimer);
                string minutes = Mathf.Floor(countDown / 60).ToString("0");
                string seconds = (countDown % 60).ToString("00");
                if (float.Parse(minutes) <= 0.0f && float.Parse(seconds) <= 0.0f)
                {
                    timerCanvas.transform.GetChild(0).GetComponent<Text>().text = "0:00";
                }
                else
                {
                    timerCanvas.transform.GetChild(0).GetComponent<Text>().text = minutes.ToString() + ":" + seconds.ToString();
                }
            }

            foreach (InputDevice x in gsm.inputDevices)
            {
                if (x.MenuWasPressed)
                {
                    isPaused = !isPaused;
                    if (isPaused)
                    {
                        pauseScreen.enabled = true;
                        Time.timeScale = 0.0f;
                    }
                    else
                    {
                        Time.timeScale = 1.0f;
                        pauseScreen.enabled = false;
                    }
                }
            }

            if (gsm.Players.Count == 1)
            {
                Debug.Log("ended the game");
                StartCoroutine(restartGame());
                victoryScreen.enabled = true;

                // Winner Icon
                // If statements that trigger depending on which tag the last object left standing has,
                // they then change the sprite to match the corresponding tag.
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

                // Play Victory sound
                AudioManager.PlaySound("VictorySound");

                gsm.Players[0].GetComponent<PlayerUI>().addScore();
                Destroy(gsm.Players[0]);
                gsm.Players.Clear();
            }
        }

        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            if(currentCanvas == CanvasCount.mainMenu)
            {

                if(Input.GetKeyDown(KeyCode.DownArrow) || InputManager.ActiveDevice.DPadDown.WasPressed || InputManager.ActiveDevice.LeftStick.Down.WasPressed || Input.GetKeyDown(KeyCode.UpArrow) || InputManager.ActiveDevice.DPadUp.WasPressed || InputManager.ActiveDevice.LeftStick.Up.WasPressed)
                {
                    if(currentControllerUISelection == ControllerUISelection.play)
                    {
                        Debug.Log("exit");
                        currentControllerUISelection = ControllerUISelection.exit;
                    }
                    else if (currentControllerUISelection == ControllerUISelection.exit)
                    {
                        currentControllerUISelection = ControllerUISelection.play;
                    }
                }

                if(currentControllerUISelection == ControllerUISelection.play)
                {
                    mainMenu.transform.GetChild(1).GetComponent<Button>().Select();
                }
                if(currentControllerUISelection == ControllerUISelection.exit)
                {
                    mainMenu.transform.GetChild(2).GetComponent<Button>().Select();
                }

                if(Input.GetKeyDown(KeyCode.KeypadEnter) || InputManager.ActiveDevice.Action1.WasPressed)
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
            if (currentCanvas == CanvasCount.playerSelect)
            {
                if(Input.GetKeyDown(KeyCode.KeypadEnter) || InputManager.ActiveDevice.MenuWasPressed)
                {
                   if(gsm.inputDevices.Count > 1)
                    {
                        selectStartButton();
                    }
                }
            }
        }
    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(roundTime * 60);
        drawScreen.enabled = true;
        foreach(GameObject x in gsm.Players)
        {
            Destroy(x);
        }
        gsm.Players.Clear();
        StartCoroutine(restartGame());
    }

    IEnumerator restartGame()
    {
        // Start function restartGame as a coroutine
        yield return new WaitForSeconds(5.0f);
        Debug.Log("loading new Scene");
        gsm.spawnPlayers = true;
        currentTimer = roundTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //===============================================
    // Button Functions
    //===============================================

    // Button function for the Main Menu 'Start' button
    public void mainStartButton()
    {
        currentCanvas = CanvasCount.playerSelect;
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
        if (currentAmountofPlayers > 0)
        {
            currentCanvas = CanvasCount.none;
            SceneManager.LoadScene(1);
            gsm.SpawnPlayers();
        }
    }

    public void AddPlayer()
    {
        currentAmountofPlayers++;

        if (currentAmountofPlayers == 1)
        {
            if (selectScreen.transform.GetChild(0).GetComponent<Image>().sprite != redSlime)
            {
                selectScreen.transform.GetChild(0).GetComponent<Image>().sprite = redSlime;
            }
        }
        if (currentAmountofPlayers == 2)
        {
            if (selectScreen.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlime)
            {
                selectScreen.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlime;
            }
        }
        if (currentAmountofPlayers == 3)
        {
            if (selectScreen.transform.GetChild(2).GetComponent<Image>().sprite != blueSlime)
            {
                selectScreen.transform.GetChild(2).GetComponent<Image>().sprite = blueSlime;
            }
        }
        if (currentAmountofPlayers == 4)
        {
            if (selectScreen.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlime)
            {
                selectScreen.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlime;
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
            }
        }
        if (currentAmountofPlayers == 3)
        {
            if (selectScreen.transform.GetChild(2).GetComponent<Image>().sprite != blueSlimebw)
            {
                selectScreen.transform.GetChild(2).GetComponent<Image>().sprite = blueSlimebw;
            }
        }
        if (currentAmountofPlayers == 2)
        {
            if (selectScreen.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlimebw)
            {
                selectScreen.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlimebw;
            }
        }
        if (currentAmountofPlayers == 1)
        {
            if (selectScreen.transform.GetChild(0).GetComponent<Image>().sprite != redSlimebw)
            {
                selectScreen.transform.GetChild(0).GetComponent<Image>().sprite = redSlimebw;
            }
        }

        currentAmountofPlayers--;
    }
}
