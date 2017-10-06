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


    [HideInInspector]
    public float amountOfSplits = 0;


    private SlimeActions slimeAction;

    // Use this for initialization
    void Start ()
    {
        HeathPoints = 1f;
        IsShielded = false;
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

        if (HeathPoints <= 0)
        {
            Death();
        }
	}

    void Death ()
    {
        slimeAction.Split(amountOfSplits);
        Destroy(gameObject);
    }

}
