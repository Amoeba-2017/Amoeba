using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private GameObject BulletWallSplat;

    [SerializeField]
    private GameObject BulletSlimeSplat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Rock")
        {
            Instantiate(BulletWallSplat, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }

        if (col.gameObject.tag == "RedSlime" || col.gameObject.tag == "BlueSlime" || col.gameObject.tag == "YellowSlime" || col.gameObject.tag == "PurpleSlime")
        {
            Instantiate(BulletSlimeSplat, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
