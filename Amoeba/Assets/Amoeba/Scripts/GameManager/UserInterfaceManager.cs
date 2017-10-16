using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenu;
    [SerializeField]
    private Canvas playerSelect;
    private Canvas victoryScreen;
    private Canvas pauseScreen;

    [SerializeField]
    private Sprite redSlime;
    [SerializeField]
    private Sprite yellowSlime;
    [SerializeField]
    private Sprite blueSlime;
    [SerializeField]
    private Sprite purpleSlime;

    private Sprite redSlimebw;
    private Sprite yellowSlimebw;
    private Sprite blueSlimebw;
    private Sprite purpleSlimebw;

    private GameStateManager gsm;

    private int currentAmountofPlayers;

    private List<Image> sprites = new List<Image>();

    public Text maxRoundText;

    bool isPaused = false;

    public enum CanvasCount
    {
        mainMenu,
        playerSelect,
        none
    };


    public CanvasCount currentCanvas;


    void Start()
    {
        maxRoundText = playerSelect.transform.GetChild(5).gameObject.GetComponent<Text>();
        currentCanvas = CanvasCount.mainMenu;
        gsm = gameObject.GetComponent<GameStateManager>();
        redSlimebw = (playerSelect.transform.GetChild(0).GetComponent<Image>().sprite);
        yellowSlimebw = (playerSelect.transform.GetChild(1).GetComponent<Image>().sprite);
        blueSlimebw = (playerSelect.transform.GetChild(2).GetComponent<Image>().sprite);
        purpleSlimebw = (playerSelect.transform.GetChild(3).GetComponent<Image>().sprite);
    }


    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (victoryScreen == null)
            {
                victoryScreen = GameObject.FindGameObjectWithTag("VictoryScreen").transform.GetComponent<Canvas>();
            }

            if (pauseScreen == null)
            {
                pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen").transform.GetComponent<Canvas>();
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

                gsm.Players[0].GetComponent<PlayerUI>().addScore();
                Destroy(gsm.Players[0]);
                gsm.Players.Clear();
            }
        }
    }


    IEnumerator restartGame()
    {
        // Start function restartGame as a coroutine
        yield return new WaitForSeconds(5.0f);
        Debug.Log("loading new Scene");
        gsm.spawnPlayers = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //called when the play button is pressed on the main menu
    public void PlayButton()
    {
        currentCanvas = CanvasCount.playerSelect;
        mainMenu.enabled = false;
        playerSelect.enabled = true;
    }


    public void StartGameButtom()
    {
        if (currentAmountofPlayers > 0)
        {
            currentCanvas = CanvasCount.none;
            SceneManager.LoadScene(1);
            gsm.SpawnPlayers();
        }
    }

    public void Exit()
    {
        
    }


    public void AddPlayer()
    {
        currentAmountofPlayers++;

        if (currentAmountofPlayers == 1)
        {
            if (playerSelect.transform.GetChild(0).GetComponent<Image>().sprite != redSlime)
            {
                playerSelect.transform.GetChild(0).GetComponent<Image>().sprite = redSlime;
            }
        }

        if (currentAmountofPlayers == 2)
        {
            if (playerSelect.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlime)
            {
                playerSelect.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlime;
            }
        }

        if (currentAmountofPlayers == 3)
        {
            if (playerSelect.transform.GetChild(2).GetComponent<Image>().sprite != blueSlime)
            {
                playerSelect.transform.GetChild(2).GetComponent<Image>().sprite = blueSlime;
            }
        }

        if (currentAmountofPlayers == 4)
        {
            if (playerSelect.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlime)
            {
                playerSelect.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlime;
            }
        }
    }

    public void RemovePlayer()
    {


        if (currentAmountofPlayers == 4)
        {
            if (playerSelect.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlimebw)
            {
                playerSelect.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlimebw;
            }
        }

        if (currentAmountofPlayers == 3)
        {
            if (playerSelect.transform.GetChild(2).GetComponent<Image>().sprite != blueSlimebw)
            {
                playerSelect.transform.GetChild(2).GetComponent<Image>().sprite = blueSlimebw;
            }
        }

        if (currentAmountofPlayers == 2)
        {
            if (playerSelect.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlimebw)
            {
                playerSelect.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlimebw;
            }
        }

        if (currentAmountofPlayers == 1)
        {
            if (playerSelect.transform.GetChild(0).GetComponent<Image>().sprite != redSlimebw)
            {
                playerSelect.transform.GetChild(0).GetComponent<Image>().sprite = redSlimebw;
            }
        }

        currentAmountofPlayers--;

    }



}
