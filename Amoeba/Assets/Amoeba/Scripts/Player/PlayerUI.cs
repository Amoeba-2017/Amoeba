﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private ScoreManager sm;

    [HideInInspector]
    public float score;

    // Use this for initialization
    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = sm.GetScore(tag).ToString();
    }


    public void addScore()
    {
        sm.AddOneToScore(tag);
    }

}
