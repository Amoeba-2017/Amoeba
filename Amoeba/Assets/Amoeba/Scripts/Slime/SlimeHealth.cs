using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour {

    // Health stat of the Slimes
    [SerializeField]
    private float HeathPoints;

    // Is the Slime shielded?
    [HideInInspector]
    public bool IsShielded;

    // Damage a Slime takes from bullets
    [SerializeField]
    private float BulletDamage;

    // Amount of times a Slime has split
    [HideInInspector]
    public float amountOfSplits = 0;


    private SlimeActions slimeAction;

    private bool firstColor;

    private Color color;

    private float colorTimer;

    [SerializeField]
    private float powerUpLength;

    [SerializeField]
    private float colorChangeSpeed;

    private Renderer renderer;

    // Use this for initialization
    void Start ()
    {
        renderer = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        HeathPoints = 1f;
        IsShielded = false;
        firstColor = true;
        slimeAction = gameObject.GetComponent<SlimeActions>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            HeathPoints = 0;
            Debug.Log("split");
        }

        if(IsShielded == true)
        {
            colorTimer += Time.deltaTime; 
            if (firstColor == true)
            {
                firstColor = false;
                color = renderer.material.color;
            }

            Debug.Log("shielded");
            renderer.material.SetColor("_EmissionColor", Color.Lerp(color, Color.white, Mathf.PingPong(Time.time * colorChangeSpeed, 1)));

            if (colorTimer > powerUpLength)
            {
                renderer.material.color = color;
                IsShielded = false;
                firstColor = true;
            }
        }



        if (HeathPoints <= 0)
        {
            Death();
        }
	}


   

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (IsShielded == false)
            {
                gameObject.GetComponent<SlimeMovement>().flyingVel = col.rigidbody.velocity;
                print("Colliding");
                HeathPoints = -BulletDamage;
            }
            Destroy(col.gameObject);
        }
    }

    void Death ()
    {
        slimeAction.Split(amountOfSplits);
        if(amountOfSplits <= 3)
        Destroy(gameObject);
    }

}

