using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector]
    public int redScore;

    [HideInInspector]
    public int yellowScore;

    [HideInInspector]
    public int blueScore;

    [HideInInspector]
    public int purpleScore;

    private int roundlimit;

    public int maxScore;

    [SerializeField]
    private GameObject crownPrefab;

    private GameObject crown;

    private GameStateManager gsm;

    private GameObject highestGO;

    private UserInterfaceManager uim;

    private PlayerUI[] playerUiElements;


    // Use this for initialization
    void Start()
    {
        gsm = gameObject.GetComponent<GameStateManager>();
        uim =  gameObject.GetComponent<UserInterfaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            if (GameObject.FindGameObjectWithTag("Crown") == null)
            {
                crown = Instantiate(crownPrefab, Vector3.zero, Quaternion.identity);

                //find all PlayerUI components in the scene, and store them in an array
                playerUiElements = FindObjectsOfType<PlayerUI>();

                UpdateScorePulsing(null);
            }


            if (gsm.Players != null && gsm.Players.Count > 1)
            {
                bool increaseScore = true;
                highestGO = null;
                float highestMass = float.MinValue;

                foreach (GameObject x in gsm.Players)
                {
                    float currentValue = x.GetComponent<PlayerController>().mass;
                    if (currentValue > highestMass)
                    {
                        highestMass = currentValue;
                        highestGO = x;
                    }
                }

                foreach (GameObject x in gsm.Players)
                {
                    float currentValue = x.GetComponent<PlayerController>().mass;

                    if (currentValue == highestMass && x != highestGO)
                    {
                        increaseScore = false;
                        break;
                    }
                }

                if (increaseScore == true)
                {
                    crown.transform.position = highestGO.transform.position + (highestGO.transform.up * 8);
                    //highestGO is the current winning player
                    UpdateScorePulsing(highestGO);

                    highestGO.GetComponent<PlayerUI>().addPoints();
                    if (highestGO.GetComponent<PlayerUI>().score >= maxScore)
                    {
                        DestroyLosers(highestGO);
                        uim.selectWinner();
                    }
                }
                else
                {
                    crown.transform.position = new Vector3(0, -10, 0);
                    UpdateScorePulsing(null);
                }
            }
        }
    }

    private void UpdateScorePulsing(GameObject winningPlayer)
    {
        //loop over all player
        foreach(GameObject p in gsm.Players)
        {
            //if player is not the winning player, turn off the pulsing
            if (p != winningPlayer)
            {
                p.transform.Find("UICanvas").GetComponent<Animator>().Play("Idle", 0, 0.0f);

            }
            else //turn on the pulsing
            {
                //if we're not already playing the UI state
                if (p.transform.Find("UICanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("UI") == false)
                {
                    p.transform.Find("UICanvas").GetComponent<Animator>().Play("UI", 0, 0.0f);
                }
            }
        }
    }


    void DestroyLosers(GameObject go)
    {
        foreach (GameObject slime in GameObject.FindGameObjectsWithTag("Slime"))
        {
            if (slime.GetComponent<SlimeMovement>().player != null)
            {
                if (slime.GetComponent<SlimeMovement>().player != go)
                {
                    Debug.Log("destroyLosers");
                    gsm.Players.Remove(slime.GetComponent<SlimeMovement>().player);
                    Destroy(slime.GetComponent<SlimeMovement>().player);
                    Destroy(slime);
                }
            }
        }

        gsm.Players.TrimExcess();
    }

    public void AddOneToScore(string tag)
    {
        if (tag == "PlayerBlue")
        {
            blueScore++;
        }
        if (tag == "PlayerRed")
        {
            redScore++;
        }
        if (tag == "PlayerPurple")
        {
            purpleScore++;
        }
        if (tag == "PlayerYellow")
        {
            yellowScore++;
        }
    }

    public int GetScore(string tag)
    {
        if (tag == "PlayerBlue")
        {
            return blueScore;
        }
        if (tag == "PlayerRed")
        {
            return redScore;
        }
        if (tag == "PlayerPurple")
        {
            return purpleScore;
        }
        if (tag == "PlayerYellow")
        {
            return yellowScore;
        }
        return -1;
    }
}
