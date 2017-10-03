using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour {

    // Health stat of the Slimes
    [SerializeField]
    private float HeathPoints;

    // Is the Slime shielded?
    [SerializeField]
    private bool IsShielded;

    // Is the Slime dead?
    [SerializeField]
    private bool IsDead;

    // Use this for initialization
    void Start ()
    {
        HeathPoints = 100.0f;
        IsShielded = false;
        IsDead = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HeathPoints = 0;
        }

        if (HeathPoints <= 0 || Input.GetKeyDown(KeyCode.Alpha0))
        {
            Death();
        }
	}

    void Death ()
    {
        IsDead = true;
        Destroy(gameObject);
    }

    void Splitting ()
    {

    }
}
