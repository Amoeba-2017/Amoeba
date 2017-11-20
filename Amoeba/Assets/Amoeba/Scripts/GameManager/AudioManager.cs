using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // List of Sound Clips
    public static AudioClip ShootSound, DeathSound, WallCollisionSound, GettingHitSound, CollectMassSound, VictorySound, DefeatSound;
    // Audion Source
    static AudioSource am;

    // Sound Clips
    // Variables that appear in the Unity Editor, for quick and easy replacement
    [SerializeField]
    [Tooltip("Audio clip for Shooting")]
    public AudioClip Shoot_SFX;
    [SerializeField]
    [Tooltip("Audio clip for Death")]
    public AudioClip Death_SFX;
    [SerializeField]
    [Tooltip("Audio clip for Wall Collision")]
    public AudioClip WallCollision_SFX;
    [SerializeField]
    [Tooltip("Audio clip for Getting Hit")]
    public AudioClip GettingHit_SFX;
    [SerializeField]
    [Tooltip("Audio clip for Collecting Mass")]
    public AudioClip CollectMass_SFX;
    [SerializeField]
    [Tooltip("Audio clip for Victory")]
    public AudioClip Victory_SFX;
    [SerializeField]
    [Tooltip("Audio clip for Defeat")]
    public AudioClip Defeat_SFX;

    // Initialization
    void Start ()
    {
        //ShootSound = Resources.Load<AudioClip>("ShootSound_Placeholder");
        ShootSound = Shoot_SFX;
        DeathSound = Death_SFX;
        WallCollisionSound = WallCollision_SFX;
        GettingHitSound = GettingHit_SFX;
        CollectMassSound = CollectMass_SFX;
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
            // Slime Wall Collision sound
            case "WallCollisionSound": am.PlayOneShot(WallCollisionSound, 1f);
                break;
            // Slime Getting Hit sound
            case "GettingHitSound": am.PlayOneShot(GettingHitSound, 1f);
                break;
            // Slime Collecting Mass sound
            case "CollectMassSound": am.PlayOneShot(CollectMassSound, 1f);
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
