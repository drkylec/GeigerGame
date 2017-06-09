/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;

public class ItemLoader : MonoBehaviour {

    public const string path = "WalkingScript";

    //load in scripts
    CameraScript cameraScript;
    Flashlight flashlight;
    WalkingScript walkingScript;
    Collectable collectable;
    ButtonStuff button;
    MaterialSwitcher materialSwitcher;
    Geiger geiger;

	// Use this for initialization
	void Start () {
        //loads and sets variables
        ItemContainer ic = ItemContainer.Load(path);
        //cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        //flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        //walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        //button = GameObject.FindObjectOfType(typeof(ButtonStuff)) as ButtonStuff;
        //collectable = GameObject.FindObjectOfType(typeof(Collectable)) as Collectable;
        //materialSwitcher = GameObject.FindObjectOfType(typeof(MaterialSwitcher)) as MaterialSwitcher;
        //geiger = GameObject.FindObjectOfType(typeof(Geiger)) as Geiger;

        foreach (Item item in ic.item)
        {
            //print(item.test);

            ////cameraScript.RotSpeed = item.rotSpeed;

            ////walkingScript.RotSpeed = item.rotSpeed;
            ////walkingScript.MoveSpeed = item.speed;
            ////walkingScript.Gravity = item.gravity;

            ////flashlight.PowerTimer = item.flashlightPower;
            ////flashlight.PowerReduction = item.flashlightPowerReduction;
            ////flashlight.MinPower = item.flashlightMinPower;
            ////flashlight.MaxPower = item.flashlightMaxPower;
            ////flashlight.MinFlicker = item.flashlightMinFlicker;
            ////flashlight.MaxFlicker = item.flashlightMaxFlicker;

            ////geiger.LowGeigerA = item.lowGeigerA;
            ////geiger.LowGeigerB = item.lowGeigerB;
            ////geiger.MedGeigerA = item.medGeigerA;
            ////geiger.MedGeigerB = item.medGeigerB;
            ////geiger.HighGeigerA = item.highGeigerA;
            ////geiger.HighGeigerB = item.highGeigerB;
        }
	}
}
