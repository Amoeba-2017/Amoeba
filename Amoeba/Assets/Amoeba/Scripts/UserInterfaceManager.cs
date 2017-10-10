using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        if (currentCanvas == CanvasCount.playerSelect)
        {
            for (int i = 0; i < gsm.playerCount - 1; i++)
            {
                if (i == 0)
                {
                    if (playerSelect.transform.GetChild(0).GetComponent<Image>().sprite != redSlime)
                    {
                        playerSelect.transform.GetChild(0).GetComponent<Image>().sprite = redSlime;
                    }
                }

                if (i == 1)
                {
                    if (playerSelect.transform.GetChild(1).GetComponent<Image>().sprite != yellowSlime)
                    {
                        playerSelect.transform.GetChild(1).GetComponent<Image>().sprite = yellowSlime;
                    }
                }

                if (i == 2)
                {
                    if (playerSelect.transform.GetChild(2).GetComponent<Image>().sprite != blueSlime)
                    {
                        playerSelect.transform.GetChild(2).GetComponent<Image>().sprite = blueSlime;
                    }
                }

                if (i == 3)
                {
                    if (playerSelect.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlime)
                    {
                        playerSelect.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlime;
                    }
                }
            }
            int amountOfNotPlayers = gsm.playerCount - 4;



            for (int i = 0; i < amountOfNotPlayers; i++)
            {
                if (i == 0)
                {
                    if (playerSelect.transform.GetChild(3).GetComponent<Image>().sprite != purpleSlimebw)
                    {
                        playerSelect.transform.GetChild(3).GetComponent<Image>().sprite = purpleSlimebw;
                    }
                }

                if (i == 1)
                {
                    if (playerSelect.transform.GetChild(1).GetComponent<Image>().sprite != blueSlimebw)
                    {
                        playerSelect.transform.GetChild(1).GetComponent<Image>().sprite = blueSlimebw;
                    }
                }

                if (i == 2)
                {
                    if (playerSelect.transform.GetChild(2).GetComponent<Image>().sprite != yellowSlimebw)
                    {
                        playerSelect.transform.GetChild(2).GetComponent<Image>().sprite = yellowSlimebw;
                    }
                }

                if (i == 3)
                {
                    if (playerSelect.transform.GetChild(3).GetComponent<Image>().sprite != redSlimebw)
                    {
                        playerSelect.transform.GetChild(3).GetComponent<Image>().sprite = redSlimebw;
                    }
                }
            }
        }
    }

    //called when the play button is pressed on the main menu
    public void PlayButton()
    {
        currentCanvas = CanvasCount.playerSelect;
        mainMenu.enabled = false;
        playerSelect.enabled = true;
    }


}
