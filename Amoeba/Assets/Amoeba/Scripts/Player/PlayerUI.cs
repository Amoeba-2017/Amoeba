using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    private ScoreManager sm;

    [HideInInspector]
    public float score;

    private Slider healthSlider;

    private Slider pointsSlider;

    private PlayerController playerC;

    // Use this for initialization
    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();

        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = sm.GetScore(tag).ToString();
        pointsSlider = gameObject.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Slider>();
        healthSlider = gameObject.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Slider>();
        playerC = gameObject.GetComponent<PlayerController>();
    }


    void Update()
    {
        healthSlider.value = playerC.mass;
    }

    public void addScore()
    {
        sm.AddOneToScore(tag);
    }

    public void addPoints()
    {
        pointsSlider.value += Time.deltaTime;
    }

}
