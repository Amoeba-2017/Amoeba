﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    private Vector3 centerPoint = new Vector3();
    private List<GameObject> players;
    private GameStateManager gsm;

    private bool smooth = true;
    [SerializeField]
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0, 0, -6.5f);

    [SerializeField]
    private float zOffset;
    [SerializeField]
    private float yOffset;

    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float minDistance;

    // Use this for initialization
    void Start ()
    {
        gsm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        players = gsm.Players;

    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        players = gsm.Players;

        players.TrimExcess();



        if (players.Count > 1)
        {
            centerPoint = Vector3.zero;

            foreach (GameObject x in players)
            {
                centerPoint += x.transform.position;
            }

            centerPoint /= players.Count;

            //transform.position = centerPoint;
            Vector3 vecBetween = Vector3.zero;
            float distance = 0;

            foreach (GameObject x in players)
            {
                vecBetween = centerPoint - x.transform.position;
                if (vecBetween.magnitude > distance)
                {
                    distance = vecBetween.magnitude;
                }
            }

            if(distance > maxDistance)
            {
                distance = maxDistance;
            }

            if(distance < minDistance)
            {
                distance = minDistance;
            }
            centerPoint = new Vector3(centerPoint.x, centerPoint.y + (distance * yOffset), centerPoint.z - (distance * zOffset));

            if (smooth)
            {
                transform.position = Vector3.Lerp(transform.position, centerPoint, smoothSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = centerPoint;
            }
        }
    }

}
