/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class PlayerRadiationLevel : MonoBehaviour {

    private const float PLAYERDEFAULT = 0;
    public float playerRadiation = 0;
    public float radiationTimer = 0;
    public float radiationTimerMax = 500;
    private float radiationDamage = 1;
    public float playerRadiationLevel;
    private float iodine = 100;
    public bool filterOn;
    private PlayerFilterLevel pfl;
    private GeigerPlayer geigerPlayer;

    public bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
        pfl = GameObject.FindObjectOfType(typeof(PlayerFilterLevel)) as PlayerFilterLevel;
        geigerPlayer = GameObject.FindObjectOfType(typeof(GeigerPlayer)) as GeigerPlayer;
        radiationTimerMax = 500;
        playerRadiationLevel = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        playerRadiationLevel = geigerPlayer.GeigerLevel;
        filterOn = pfl.FilterOn;
        if (!paused)
        {
            if (pfl.FilterOn == true)
            {
                if (radiationTimer >= radiationTimerMax)
                {
                    if (geigerPlayer.GeigerMeter == 0)
                    {
                        playerRadiation += radiationDamage / 2;
                    }
                    else if (geigerPlayer.GeigerMeter == 1)
                    {
                        playerRadiation += (radiationDamage * 1.5f) / 2;
                    }
                    else
                    {
                        playerRadiation += (radiationDamage * 2) / 2;
                    }

                    radiationTimer = 0;
                }
            }
            else
            {
                if (radiationTimer >= radiationTimerMax)
                {
                    if (geigerPlayer.GeigerMeter == 0)
                    {
                        playerRadiation += radiationDamage;
                    }
                    else if (geigerPlayer.GeigerMeter == 1)
                    {
                        playerRadiation += (radiationDamage * 1.5f);
                    }
                    else
                    {
                        playerRadiation += (radiationDamage * 2);
                    }

                    radiationTimer = 0;
                }
            }

            if (playerRadiationLevel == 0)
            {
                radiationTimer += 1.0f;
            }
            else if (playerRadiationLevel == 1)
            {
                radiationTimer += 10.0f;
            }
            else
            {
                radiationTimer += 30.0f;
            }

            if (playerRadiation >= 500.0f)
            {
                playerRadiation = 500;
                //add code to do player death.
                //add gameover switch here
            }

            if (playerRadiation <= 0)
            {
                playerRadiation = 0;
            }

            if (playerRadiation >= 100)
            {
                playerRadiation = 100;
            }
        }
	}

    public void IodineReduction()
    {
        playerRadiation -= iodine;
    }
}
