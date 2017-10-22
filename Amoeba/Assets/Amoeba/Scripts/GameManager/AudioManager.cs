using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // List of Sound Clips
    public static AudioClip ShootSound, DeathSound, VictorySound, DefeatSound;
    // Audion Source
    static AudioSource am;

    // Sound Clips
    // Variables that appear in the Unity Editor, for quick and easy replacement
    [SerializeField]
    public AudioClip Shoot_SFX;
    [SerializeField]
    public AudioClip Death_SFX;
    [SerializeField]
    public AudioClip Victory_SFX;
    [SerializeField]
    public AudioClip Defeat_SFX;

    // Initialization
    void Start ()
    {
        //ShootSound = Resources.Load<AudioClip>("ShootSound_Placeholder");
        ShootSound = Shoot_SFX;
        DeathSound = Death_SFX;
        VictorySound = Victory_SFX;
        DefeatSound = Defeat_SFX;

        am = GetComponent<AudioSource>();
	}
	
	// Update (Per Frame)
	void Update ()
    {

    }

    // Play Sound
    // Switch Statement to play a differing sound for each case
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            // Slime Shooting sound
            case "ShootSound": am.PlayOneShot(ShootSound, 1f);
                break;
            // Slime Death sound
            case "DeathSound": am.PlayOneShot(DeathSound, 1f);
                break;
            // Player Victory sound
            case "VictorySound": am.PlayOneShot(VictorySound, 1f);
                break;
            // Player Defeat sound
            case "DefeatSound": am.PlayOneShot(VictorySound, 1f);
                break;
        }
    }
}
