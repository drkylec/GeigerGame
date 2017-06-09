/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class LightsOn : MonoBehaviour {

    public Light lightbulb = null;
    bool lightsOn = false;

	// Use this for initialization
    //sets the light to off
	void Start () {
        lightbulb.range = 0;
        lightbulb.intensity = 0;
        lightbulb.bounceIntensity = 0;
        //lightbulb.spotAngle = 0;
        lightsOn = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(lightsOn)
        {
            lightbulb.range = 8;
            lightbulb.intensity = 2;
            lightbulb.bounceIntensity = 1;
            //lightbulb.spotAngle = 40;
        }
        else
        {
            lightbulb.range = 0;
            lightbulb.intensity = 0;
            lightbulb.bounceIntensity = 0;
            //lightbulb.spotAngle = 0;
        }
	
	}

    public bool LightsON
    {
        get { return lightsOn; }
    }

    //void OnTriggerStay(Collider col)
    //{
    //    if(Input.GetKeyDown(KeyCode.F))
    //    {
    //        LightsTurnedOn();
    //    }
    //}

    public void LightsTurnedOn()
    {
        lightsOn = true;
    }
}
