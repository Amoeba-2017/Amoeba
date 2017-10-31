using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{

    // Health stat of the Slimes
    //[SerializeField]
    //private float HeathPoints;

    // Is the Slime shielded?
    [HideInInspector]
    public bool IsShielded;

    // Damage a Slime takes from bullets
    [SerializeField] 
    private float BulletDamagePercent = 5;

    // Amount of times a Slime has split
    //[HideInInspector]
    //public float amountOfSplits = 0;

    [SerializeField]
    private float invincibilityFramesTime;

    private SlimeActions slimeAction;

    private bool firstColor;

    private Color color;

    private float colorTimer;

    [SerializeField]
    private float powerUpLength;

    [SerializeField]
    private float colorChangeSpeed;

    private Renderer renderer;
    Color LerpColor;

    public bool isInvincible;

    private PlayerController playerC;

    private SlimeMovement slimeMovement;

    // Use this for initialization
    void Start()
    {
        renderer = gameObject.transform.GetChild(0).GetComponent<Renderer>();
   //     HeathPoints = 1f;
        IsShielded = false;
        firstColor = true;
        slimeAction = gameObject.GetComponent<SlimeActions>();
        isInvincible = true;
        StartCoroutine(InvincibleFrames());
        slimeMovement = gameObject.GetComponent<SlimeMovement>();
        playerC = GameObject.FindGameObjectWithTag(slimeMovement.parent).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Backspace))
        //{
        //   // HeathPoints = 0;
        //    Debug.Log("split");
        //}
        Debug.Log(playerC.mass);
        gameObject.transform.localScale = new Vector3(playerC.mass / 100, playerC.mass / 100, playerC.mass / 100);

        if (IsShielded == true)
        {
            colorTimer += Time.deltaTime;
            if (firstColor == true)
            {
                firstColor = false;
            }

            LerpColor = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time * colorChangeSpeed, 1));

            Debug.Log("shielded");
            renderer.material.SetColor("_EmissionColor", LerpColor);

            if (colorTimer > powerUpLength)
            {
                renderer.material.SetColor("_EmissionColor", Color.black);

                IsShielded = false;
                firstColor = true;
                colorTimer = 0;
            }
        }

    }




    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (IsShielded == false)
            {
                if (isInvincible == false)
                {
                    //gameObject.GetComponent<SlimeMovement>().flyingVel = col.rigidbody.velocity;
                    print("Colliding");
                    Debug.Log(playerC.mass * (BulletDamagePercent / 100));
                    col.gameObject.GetComponent<SlimeBullet>().SetHitMass(playerC.mass * (BulletDamagePercent / 100));
                    playerC.mass -= (playerC.mass * (BulletDamagePercent / 100));
                }
            }
        }
    }

    public IEnumerator InvincibleFrames()
    {
        yield return new WaitForSeconds(invincibilityFramesTime);
        isInvincible = false;
    }


}

