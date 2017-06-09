/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class WaterPump : MonoBehaviour {

    public GameObject water;
    public LightsOn lightsON;
    public AudioClip[] audio;
    public bool waterPumped = false;

    private float x;
    private float i;

    // Use this for initialization
    void Start () {
        water = GameObject.Find("Water");
        lightsON = GameObject.FindObjectOfType(typeof(LightsOn)) as LightsOn;
        waterPumped = false;
        x = 0;
        i = 500;
    }
	
	// Update is called once per frame
	void Update () {

        if(waterPumped)
        {
            WaterMoveThenDestory();
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource.isPlaying) return;
            audioSource.clip = audio[1];
            audioSource.loop = true;
            audioSource.Play();
        }
	
	}

    void OnTriggerStay(Collider col)
    {
        if (lightsON.LightsON)
        {
            if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButtonDown("X")))
            {
                waterPumped = true;
                
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource.isPlaying) return;
                audioSource.clip = audio[0];
                audioSource.Play();
                
            }
        }
    }

    void WaterMoveThenDestory()
    {
        float z = water.transform.position.x;
        float r = water.transform.position.y;
        float w = water.transform.position.z;
        r -= Time.deltaTime;
        water.transform.position = new Vector3(z, r, w);
        if (x >= i)
        {
            Destroy(water);
        }
        x += Time.deltaTime;
    }
}
