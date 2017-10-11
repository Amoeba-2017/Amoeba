using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenu;
    [SerializeField]
    private Canvas playerSelect;
    private Canvas victoryScreen;

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

    public enum CanvasCount
    {
        mainMenu,
        playerSelect
    };


    public CanvasCount currentCanvas;


    void Start()
    {
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

            if (gsm.Players.Count == 1)
            {
                StartCoroutine(waitForCheck());
            }
        }
    }
    IEnumerator waitForCheck()
    {
        // Start function WaitAndPrint as a coroutine
        yield return new WaitForSeconds(0.5f);
        Debug.Log("ended the game");
        Time.timeScale = 0;
        victoryScreen.enabled = true;
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
            SceneManager.LoadScene(1);
            gsm.SpawnPlayers();
        }
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
