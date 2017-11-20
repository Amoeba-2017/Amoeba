using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    private ScoreManager sm;

    
    public float score;

    private Image pointsSlider;

    private PlayerController playerC;

    [SerializeField][Tooltip("0.5 is 2 seconds per tick")]
    private float timeMulitpler;

    float points;

    // Use this for initialization
    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        pointsSlider = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        playerC = gameObject.GetComponent<PlayerController>();
    }


    void Update()
    {
    }

    public void addScore()
    {
        sm.AddOneToScore(tag);
    }

    public void addPoints()
    {
        points += (Time.deltaTime * timeMulitpler) / 100;
        pointsSlider.fillAmount = points;
        score = pointsSlider.fillAmount;
    }

}
