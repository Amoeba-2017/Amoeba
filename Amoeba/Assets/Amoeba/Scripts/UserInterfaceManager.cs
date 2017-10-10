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


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

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
        if (currentCanvas == CanvasCount.playerSelect)
        {
            int amountOfNotPlayers = 4 - gsm.playerCount;
        }
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
        SceneManager.LoadScene(1);
        gsm.SpawnPlayers();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene == SceneManager.GetSceneAt(1))
        {
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

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
