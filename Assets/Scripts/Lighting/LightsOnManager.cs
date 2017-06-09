/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class LightsOnManager : MonoBehaviour {

    public LightsOn[] lightOn;
    public AudioClip[] audio;
    private bool lightsTurnedOn = false;
    public LockedDoor ld;
    public CameraScript cs;

    // Use this for initialization
    void Start () {
        //lightOn = GameObject.FindObjectOfType(typeof(LightsOn)) as LightsOn;
        lightsTurnedOn = false;
        lightOn = GameObject.FindObjectsOfType(typeof(LightsOn)) as LightsOn[];
        ld = GameObject.FindObjectOfType(typeof(LockedDoor)) as LockedDoor;
        cs = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
    }
	
	// Update is called once per frame
	void Update () {
        if (lightsTurnedOn)
        {
            foreach (LightsOn lights in lightOn)
            {
                lights.LightsTurnedOn();
            }

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource.isPlaying) return;
            audioSource.clip = audio[1];
            audioSource.loop = true;
            audioSource.Play();
            
        }
    }

    void OnTriggerStay(Collider col)
    {
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButtonDown("X")))
        {
            ld.obj[4].enabled = true;
            ld.objStrike[4].enabled = true;
            cs.firstText.enabled = true;
            cs.textTimer = 0;

            lightsTurnedOn = true;
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource.isPlaying) return;
            audioSource.clip = audio[0];
            audioSource.Play();
            //lightOn.LightsTurnedOn();
        }
    }
}
