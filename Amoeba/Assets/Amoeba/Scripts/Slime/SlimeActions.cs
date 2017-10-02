using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeActions : MonoBehaviour {

    // GameObject-type variable for the projectile
    [SerializeField]
    private GameObject ProjectileShot;

    // The speed of the projectile
    [SerializeField]
    private float ProjectileShotSpeed;

    // The time that, when reached, will cause the projectile to be destroyed
    [SerializeField]
    private float DestroyTimer;

    // Use this for initialization
    void Start ()
    {
		
	}


    public void Shoot(Vector3 rot)
    {
        Debug.Log(rot);

        // Create a Bullet object
        GameObject Bullet;

        Bullet = Instantiate(ProjectileShot, transform.position + (rot * 2), Quaternion.identity);

        // Get the object (Bullet) and add the force to it
        Bullet.GetComponent<Rigidbody>().AddForce(rot * ProjectileShotSpeed, ForceMode.Impulse);

        // Destroy the Bullet when the DestroyTimer has been reached
        Destroy(Bullet, DestroyTimer);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
