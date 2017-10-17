using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioClip ShootSound, DeathSound, VictorySound;
    static AudioSource am;

    // Use this for initialization
    void Start ()
    {
        ShootSound = Resources.Load<AudioClip>("ShootSound_Placeholder");

        am = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            // Slime Shooting sound
            case "ShootSound_Placeholder": am.PlayOneShot(ShootSound, 1f);
                break;
        }
    }
}
