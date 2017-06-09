/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class Geiger : MonoBehaviour
{

    //Geiger Numbers
    public float geigerMeter;
    private float lowGeigerA;
    private float lowGeigerB;
    private float medGeigerA;
    private float medGeigerB;
    private float highGeigerA;
    private float highGeigerB;

    public float radioActive = 0;

    public GeigerPlayer geigerPlayer;
    public PlayerFilterLevel pfl;

    // Use this for initialization
    void Start()
    {
        geigerPlayer = GameObject.FindObjectOfType(typeof(GeigerPlayer)) as GeigerPlayer;
        pfl = GameObject.FindObjectOfType(typeof(PlayerFilterLevel)) as PlayerFilterLevel;
    }

    #region Triggers

    //if the item is 1 then medium radiation
    //if the item is 1 then high radiation
    void OnTriggerStay(Collider col)
    {
        if (radioActive == 0)
        {
            geigerPlayer.GeigerLevel = 1;
            pfl.FiltrationNumber = 1;

            geigerPlayer.GeigerLevelMeter(1);
        }

        else if(radioActive == 1)
        {
            geigerPlayer.GeigerLevel = 2;
            pfl.FiltrationNumber = 2;

            geigerPlayer.GeigerLevelMeter(2);
        }
    }

    //on exit of trigger set it back to low radiation
    void OnTriggerExit(Collider col)
    {
        geigerPlayer.GeigerLevel = 0;
        pfl.FiltrationNumber = 0;

        geigerPlayer.GeigerLevelMeter(0);
    }
    #endregion

    #region getteres and setters
    public float GeigerMeter
    {
        get { return geigerMeter; }
        set { geigerMeter = value; }
    }

    public float LowGeigerA
    {
        get { return lowGeigerA; }
        set { lowGeigerA = value; }
    }

    public float LowGeigerB
    {
        get { return lowGeigerB; }
        set { lowGeigerB = value; }
    }

    public float MedGeigerA
    {
        get { return medGeigerA; }
        set { medGeigerA = value; }
    }

    public float MedGeigerB
    {
        get { return medGeigerB; }
        set { medGeigerB = value; }
    }

    public float HighGeigerA
    {
        get { return highGeigerA; }
        set { highGeigerA = value; }
    }

    public float HighGeigerB
    {
        get { return highGeigerB; }
        set { highGeigerB = value; }
    }
    #endregion
}
