using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    private ScoreManager sm;

    
    public float score;

    private Slider healthSlider;

    private Slider pointsSlider;

    private PlayerController playerC;

    [SerializeField][Tooltip("0.5 is 2 seconds per tick")]
    private float timeMulitpler;

    float points;

    // Use this for initialization
    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();

      //  gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = sm.GetScore(tag).ToString();
        pointsSlider = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Slider>();
        healthSlider = gameObject.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Slider>();
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
        points += (Time.deltaTime * timeMulitpler);
        pointsSlider.value = Mathf.Floor(points);
        score = pointsSlider.value;
    }

}
