/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class PlayerFilterLevel : MonoBehaviour {

    //variables
    public float filterLevel;
    public float filtrationLevelDecayAmount;
    public float filtrationDecayLimit;
    public float filtrationDecay;
    public int filtrationNumber;
    private enum FiltrationDangerLevel {Level1, Level2, Level3 };
    FiltrationDangerLevel fdl = FiltrationDangerLevel.Level1;
    private GeigerPlayer geigerPLayer;
    private bool filterOn = true;

    public bool paused = false;
    


    // Use this for initialization
    void Start () {
        paused = false;
        geigerPLayer = GameObject.FindObjectOfType(typeof(GeigerPlayer)) as GeigerPlayer;
        filterLevel = 100.0f;
        filtrationDecayLimit = 500.0f;
        filtrationLevelDecayAmount = 1.0f;
        filtrationDecay = 0.0f;
        filtrationNumber = 0;
    }
	
	// Update is called once per frame
    //gets the case and then does the timer and applies the effect
	void Update () {
        if (!paused)
        {
            if (filtrationNumber == 0)
            {
                fdl = FiltrationDangerLevel.Level1;
                filtrationLevelDecayAmount = 1.0f;

            }
            else if (filtrationNumber == 1)
            {
                fdl = FiltrationDangerLevel.Level2;
                filtrationLevelDecayAmount = 10.0f;

            }
            else if (filtrationNumber == 2)
            {
                fdl = FiltrationDangerLevel.Level3;
                filtrationLevelDecayAmount = 30.0f;

            }
            else
            {
                fdl = FiltrationDangerLevel.Level1;
                filtrationLevelDecayAmount = 1.0f;

            }

            if (filterLevel <= 0.0f)
            {
                filterOn = false;
                filterLevel = 0.0f;
            }
            else
            {
                filterOn = true;
            }

            if (filtrationDecay >= filtrationDecayLimit)
            {
                switch (fdl)
                {
                    case FiltrationDangerLevel.Level1:
                        filterLevel -= 1.0f;
                        break;
                    case FiltrationDangerLevel.Level2:
                        filterLevel -= 2.0f;
                        break;
                    case FiltrationDangerLevel.Level3:
                        filterLevel -= 3.0f;
                        break;
                }
                filtrationDecay = 0.0f;
            }
            filtrationDecay += filtrationLevelDecayAmount;
        }
    }

    //refill player filter
    public void RefillFilter()
    {
        filterLevel = 100.0f;
    }

    #region Getters and Setters
    public int FiltrationNumber
    {
        get { return filtrationNumber; }
        set { filtrationNumber = value; }
    }

    public bool FilterOn
    {
        get { return filterOn; }
        set { filterOn = value; }
    }
    #endregion
}
