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

    private GameStateManager gsm;


    // Use this for initialization
    void Start()
    {
        gsm = gameObject.GetComponent<GameStateManager>();
        roundlimit = gsm.maxRounds;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(roundlimit != gsm.maxRounds)
        {
            roundlimit = gsm.maxRounds;
        }
        if(redScore >= roundlimit || yellowScore >= roundlimit || blueScore >= roundlimit || purpleScore >= roundlimit)
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

        //if(gsm.Players != null && gsm.Players.Count > 1)
        //{
        //    foreach(GameObject x in gsm.Players)
        //}



    }



    public void AddOneToScore(string tag)
    {
        if(tag == "PlayerBlue")
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
