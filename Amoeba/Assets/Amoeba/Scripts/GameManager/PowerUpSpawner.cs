using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PowerUpSpawner : MonoBehaviour
{

    //Allows the GameObject to be seen in the inspector
    [SerializeField]
    private GameObject[] powerUps;

    [SerializeField]
    private float spawnCoolDown;     //Spawn Cool Down

    private GameObject[] spawnPointPrefab;

    private float powerUpSpawnTimer; //Spawn Timer

    private GameObject currentPowerUp;


    // Use this for initialization
    void Start()
    {
        powerUpSpawnTimer = spawnCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {

            if (spawnPointPrefab == null)
            {
                spawnPointPrefab = GameObject.FindGameObjectsWithTag("PowerUpSpawner");
            }

            if (powerUpSpawnTimer <= 0.0f)
            {
                //foreach statement iterates through each GameObject inside the array
                for (int i = 0; i < spawnPointPrefab.Length; i++)
                {

                    {
                        //Creates new randomised Power-Up at a random SpawnPoint location and passes its position and rotation
                        currentPowerUp = Instantiate(powerUps[0], spawnPointPrefab[i].transform.position + (transform.up * 1.5f), Quaternion.identity);
                        //Sets the currentPowerUps parent to the SpawnPoint it is set at
                        currentPowerUp.transform.SetParent(spawnPointPrefab[i].transform);
                    }
                }

                powerUpSpawnTimer = spawnCoolDown;

            }
            else
            {
                //Creates a timer that counts down
                powerUpSpawnTimer -= Time.deltaTime;

            }
        }
    }

}