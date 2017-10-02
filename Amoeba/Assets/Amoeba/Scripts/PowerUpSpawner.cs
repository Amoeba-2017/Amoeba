using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    //Allows the GameObject to be seen in the inspector
    [SerializeField]
    private GameObject[] powerUps;

    [SerializeField]
    private float spawnCoolDown;

    [SerializeField]
    private GameObject[] spawnPointPrefab;

    private float powerUpSpawnTimer;

    private GameObject currentPowerUp;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        //Creates a timer that counts up
        powerUpSpawnTimer += Time.deltaTime;

        if (powerUpSpawnTimer > spawnCoolDown)
        {
            powerUpSpawnTimer = 0.0f;

            //For Each GameObject in the spawnPointPrefab
            foreach (GameObject i in spawnPointPrefab)
            {
                if (i.transform.GetChild(0) == null)
                {
                    //Creates a new randomised Power Up gameObject and sets it to a random SpawnPoint
                    currentPowerUp = Instantiate(powerUps[(int)Random.Range(0, powerUps.Length - 1)], i.transform.position + (transform.up * 2), Quaternion.identity);
                    currentPowerUp.transform.SetParent(i.transform);
                }
            }
        }
	}
}
