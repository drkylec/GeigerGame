/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;

public class PlayerLoader : MonoBehaviour {

    public const string path = "PlayerScript";

    //load in scripts
    CameraScript cameraScript;
    Flashlight flashlight;
    WalkingScript walkingScript;
    //Collectable collectable;
    //ButtonStuff button;
    //MaterialSwitcher materialSwitcher;
    Geiger geiger;

    // Use this for initialization
    void Start()
    {
        //loads and sets variables
        PlayerContainer pc = PlayerContainer.Load(path);

        cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        //button = GameObject.FindObjectOfType(typeof(ButtonStuff)) as ButtonStuff;
        //collectable = GameObject.FindObjectOfType(typeof(Collectable)) as Collectable;
        //materialSwitcher = GameObject.FindObjectOfType(typeof(MaterialSwitcher)) as MaterialSwitcher;
        geiger = GameObject.FindObjectOfType(typeof(Geiger)) as Geiger;

        foreach (Player player in pc.player)
        {
            //print(player.rayLength);

            cameraScript.RotSpeed = player.rotSpeed;
            cameraScript.RayLength = player.rayLength;
            cameraScript.CollisionOffset = player.collisionOffset;
            cameraScript.OffsetX = player.offsetx;
            cameraScript.OffsetY = player.offsety;
            cameraScript.OffsetZ = player.offsetz;

            walkingScript.RotSpeed = player.rotSpeed;
            walkingScript.MoveSpeed = player.speed;
            walkingScript.Gravity = player.gravity;

            flashlight.PowerTimer = player.flashlightPower;
            flashlight.PowerReduction = player.flashlightPowerReduction;
            flashlight.MinPower = player.flashlightMinPower;
            flashlight.MaxPower = player.flashlightMaxPower;
            flashlight.MinFlicker = player.flashlightMinFlicker;
            flashlight.MaxFlicker = player.flashlightMaxFlicker;

            geiger.LowGeigerA = player.lowGeigerA;
            geiger.LowGeigerB = player.lowGeigerB;
            geiger.MedGeigerA = player.medGeigerA;
            geiger.MedGeigerB = player.medGeigerB;
            geiger.HighGeigerA = player.highGeigerA;
            geiger.HighGeigerB = player.highGeigerB;
        }
    }

    void Update()
    {
        //loads and sets variables
        PlayerContainer pc = PlayerContainer.Load(path);

        cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        //button = GameObject.FindObjectOfType(typeof(ButtonStuff)) as ButtonStuff;
        //collectable = GameObject.FindObjectOfType(typeof(Collectable)) as Collectable;
        //materialSwitcher = GameObject.FindObjectOfType(typeof(MaterialSwitcher)) as MaterialSwitcher;
        geiger = GameObject.FindObjectOfType(typeof(Geiger)) as Geiger;

        foreach (Player player in pc.player)
        {
            geiger.LowGeigerA = player.lowGeigerA;
            geiger.LowGeigerB = player.lowGeigerB;
            geiger.MedGeigerA = player.medGeigerA;
            geiger.MedGeigerB = player.medGeigerB;
            geiger.HighGeigerA = player.highGeigerA;
            geiger.HighGeigerB = player.highGeigerB;
        }
    }
}
