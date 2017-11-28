using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeActions : MonoBehaviour
{
    // GameObject-type variable for the projectile
    [SerializeField]
    private GameObject projectileShot;

    // The speed of the projectile
    [SerializeField]
    private float projectileShotSpeed;

    // The time that, when reached, will cause the projectile to be destroyed
    [SerializeField]
    private float bulletDestroyTimer;

    [SerializeField]
    private GameObject slime;

    private SlimeMovement slimeMovement;

    private PlayerController playerController;

    [SerializeField]
    private GameObject ShootSplat;

    [SerializeField]
    private float massShot;

    private SlimeHealth slimeHealth;

    // Use this for initialization
    void Start()
    {
        slimeMovement = gameObject.GetComponent<SlimeMovement>();
        slimeHealth = gameObject.GetComponent<SlimeHealth>();
    }

    public void Shoot(Vector3 rot, float mass)
    {
            gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("IsShooting");

            // Create a Bullet object
            GameObject Bullet;
            
            Bullet = Instantiate(projectileShot, transform.position + (rot * 2), Quaternion.LookRotation(rot, Vector3.up));

            if (playerController == null)
            {
                playerController = slimeMovement.player.GetComponent<PlayerController>();
            }

            playerController.mass -= massShot;

            Bullet.GetComponent<SlimeBullet>().SetMyMass(massShot);

            // Get the object (Bullet) and add the force to it
            Bullet.GetComponent<Rigidbody>().AddForce(rot * projectileShotSpeed, ForceMode.Impulse);

            // Play shooting sound
            AudioManager.PlaySound("ShootSound");

            //Instantiate(ShootSplat, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);

            // Destroy the Bullet when the DestroyTimer has been reached
            Destroy(Bullet, bulletDestroyTimer);
    }

    //public void Split(float amount)
    //{
    //    if (playerController == null)
    //    {
    //        if (slimeMovement.player.GetComponent<PlayerController>() != null)
    //        {
    //            playerController = slimeMovement.player.GetComponent<PlayerController>();
    //        }
    //    }
    //    playerController.slimes.Remove(gameObject);

    //    if (amount == 0)
    //    {
    //        playerController.speed = 15.5f;

    //        newSlime(0.75f, 1);
    //        newSlime(0.75f, 1);
    //    }
    //    else if (amount == 1)
    //    {

    //        playerController.speed = 15.7f;

    //        newSlime(.6f, 2);
    //        newSlime(.6f, 2);
    //        newSlime(.6f, 2);
    //    }

    //    else if (amount == 2)
    //    {
    //        playerController.speed = 16;

    //        newSlime(0.4f, 3);
    //        newSlime(0.4f, 3);
    //        newSlime(0.4f, 3);
    //        newSlime(0.4f, 3);
    //    }
    //    else if (amount == 3)
    //    {
    //        slimeMovement.currentSlimeState = SlimeMovement.SlimeState.flying;
    //    }
    //    playerController.newKingSlime();

    //}

    //void newSlime(float size, float amount)
    //{
    //    GameObject tempSlime = Instantiate(slime, transform.position, transform.rotation);
    //    playerController.slimes.Add(tempSlime);
    //    tempSlime.GetComponent<SlimeMovement>().parent = slimeMovement.parent;
    //    tempSlime.GetComponent<SlimeHealth>().amountOfSplits = amount;
    //    tempSlime.transform.localScale = new Vector3(size, size, size);
    //}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "ProtectiveShield")
        {
            Debug.Log("shield");
            slimeMovement.player.gameObject.GetComponent<PlayerPowerUpController>().Shield();
            Destroy(hit.gameObject);
        }
    }
}