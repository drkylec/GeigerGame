/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    #region Variables
    public bool isON = true;

    //set up the flashlight
    public float flashlightBatteryFull = 100.0f;
    public float flashlightBattery = 40.0f;
    public Light light;
    public Light lightOuterCone;
    public Light lightInnerCone;

    //default values for the flashlight
    private const float DEFAULTRANGE = 10;
    private const float DEFAULTSPOTANGLE = 130;
    private const float DEFAULTINTENSITY = 1.7f;
    private const float DEFAULTBOUNCEINTENSITY = 0.0f;

    //outer cone
    private const float DEFAULTRANGECONE = 10;
    private const float DEFAULTSPOTANGLECONE = 103.7f;
    private const float DEFAULTINTENSITYCONE = 1.7f;
    private const float DEFAULTBOUNCEINTENSITYCONE = 0.0f;

    //inner cone
    private const float DEFAULTRANGECONEINNER = 10;
    private const float DEFAULTSPOTANGLECONEINNER = 5f;
    private const float DEFAULTINTENSITYCONEINNER = 2.5f;
    private const float DEFAULTBOUNCEINTENSITYCONEINNER = 0.0f;

    //changeing values for flashlight
    private float newRange = 10;
    private float newSpotAngle = 130;
    private float newIntensity = 1.7f;
    private float newBounceIntensity = 0.0f;

    private const float LOWRANGE = 10.0f;
    private const float LOWSPOTANGLE = 65;
    private const float LOWINTENSITY = 1.0f;
    private const float LOWBOUNCEINTENSITY = 0.0f;

    //chaneg the battery level
    private float maxTime;
    private float powerReduction;
    public float time = 1.0f;
    private int minPower;
    private int maxPower;

    //flicker
    public float minFlickerSpeed;
    public float maxFlickerSpeed;

    //timer for button
    private float timer = 0;
    private float timerMax = 0.5f;

    private float flickerTimer;
    private float flickerTimerMax;

    private bool flicker;

    public float lowFlicker;
    public float heighFlicker;

    #endregion

    // Use this for initialization
    void Start() {
        //light = GetComponent<Light>();
        flashlightBattery = 40.0f;
        light.enabled = true;
        lightOuterCone.enabled = true;
        light.range = DEFAULTRANGE;
        light.spotAngle = DEFAULTSPOTANGLE;
        light.intensity = DEFAULTINTENSITY;
        light.bounceIntensity = DEFAULTBOUNCEINTENSITY;

        //lights outer cone
        lightOuterCone.range = DEFAULTRANGECONE;
        lightOuterCone.spotAngle = DEFAULTSPOTANGLECONE;
        lightOuterCone.intensity = DEFAULTINTENSITYCONE;
        lightOuterCone.bounceIntensity = DEFAULTBOUNCEINTENSITYCONE;

        //inner cone light
        lightInnerCone.range =  DEFAULTRANGECONEINNER;
        lightInnerCone.spotAngle = DEFAULTSPOTANGLECONEINNER;
        lightInnerCone.intensity = DEFAULTINTENSITYCONEINNER;
        lightInnerCone.bounceIntensity = DEFAULTBOUNCEINTENSITYCONEINNER;

        lowFlicker = 0.1f;
        heighFlicker = 1.0f;

        flickerTimerMax = Random.Range(lowFlicker, heighFlicker);

        flicker = false;

    }

    #region Update
    // Update is called once per frame
    void Update() {
        if (isON)
        {
            if (time > maxTime)
            {
                flashlightBattery -= powerReduction;
                time = 1.0f;
            }

            if (flashlightBattery > 100.0f)
            {
                light.enabled = true;
                lightOuterCone.enabled = true;
                lightInnerCone.enabled = true;
                flashlightBattery = 100.0f;

                flicker = false;
                StopCoroutine(Flicker());
            }

            if (flashlightBattery >= flashlightBatteryFull)
            {
                light.enabled = true;
                lightOuterCone.enabled = true;
                lightInnerCone.enabled = true;
                light.range = DEFAULTRANGE;
                light.spotAngle = DEFAULTSPOTANGLE;
                light.intensity = DEFAULTINTENSITY;
                light.bounceIntensity = DEFAULTBOUNCEINTENSITY;

                flicker = false;
                StopCoroutine(Flicker());
            }
            else if ((flashlightBattery <= 80.0f) && (flashlightBattery > 50.0f))
            {
                //calculate the values
                //newRange = 9.2f;
                newSpotAngle = 119.6f;
                newIntensity = 1.5f;
                newBounceIntensity = 0.0f;

                //apply the new values
                light.enabled = true;
                lightOuterCone.enabled = true;
                lightInnerCone.enabled = true;
                light.range = newRange;
                light.spotAngle = newSpotAngle;
                light.intensity = newIntensity;
                light.bounceIntensity = newBounceIntensity;

                flicker = false;
                StopCoroutine(Flicker());
            }
            else if ((flashlightBattery <= 50.0f) && (flashlightBattery > 20.0f))
            {
                //calculate the values
                //newRange = 5.0f;
                newSpotAngle = 65.0f;
                newIntensity = 1.0f;
                newBounceIntensity = 0.0f;

                //apply the new values
                light.enabled = true;
                lightOuterCone.enabled = true;
                lightInnerCone.enabled = true;
                light.range = newRange;
                light.spotAngle = newSpotAngle;
                light.intensity = newIntensity;
                light.bounceIntensity = newBounceIntensity;

                flicker = false;
                StopCoroutine(Flicker());
            }
            else if (flashlightBattery <= 20.0f)
            {
                flashlightBattery = 20.0f;
                light.range = LOWRANGE;
                light.spotAngle = LOWSPOTANGLE;
                light.intensity = LOWINTENSITY;
                light.bounceIntensity = LOWBOUNCEINTENSITY;

                flicker = true;
                //StartCoroutine(Flicker());
                FlickerEffect();
            }
            else
            {
                light.enabled = true;
                lightOuterCone.enabled = true;
                lightInnerCone.enabled = true;
                light.range = DEFAULTRANGE;
                light.spotAngle = DEFAULTSPOTANGLE;
                light.intensity = DEFAULTINTENSITY;
                light.bounceIntensity = DEFAULTBOUNCEINTENSITY;

                flicker = false;
                StopCoroutine(Flicker());
            }

            time += Time.deltaTime;
        }
        else
        {
            light.enabled = false;
            lightOuterCone.enabled = false;
            lightInnerCone.enabled = false;
        }

        if (timer >= timerMax)
        {
            if ((Input.GetKey(KeyCode.F)) || (Input.GetButtonDown("Y")))
            {
                isON = !IsON;
                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }
    #endregion

    public void AddPower()
    {
        float power;
        power = Random.Range(minPower, maxPower);
        flashlightBattery += power;
    }

    public void EventPower()
    {
        flashlightBattery = 20.0f;
    }

    IEnumerator Flicker()
    {
        while (flicker)
        {
            light.enabled = true;
            lightOuterCone.enabled = true;
            lightInnerCone.enabled = true;
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            light.enabled = false;
            lightOuterCone.enabled = false;
            lightInnerCone.enabled = false;
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
    }

    void FlickerEffect()
    {
        //yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        if (flickerTimer >= flickerTimerMax)
        { 
            light.enabled = false;
            lightOuterCone.enabled = false;
            lightInnerCone.enabled = false;
            if (flickerTimer >= flickerTimerMax + 0.5f)
            {
                flickerTimerMax = Random.Range(lowFlicker, heighFlicker);
                flickerTimer = 0;
            }
            //yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
        else
        {
            light.enabled = true;
            lightOuterCone.enabled = true;
            lightInnerCone.enabled = true;
        }
        flickerTimer += Time.deltaTime;
    }

    #region Getters and Setters
    public float CheckPower
    {
        get { return flashlightBattery; }
    }

    public bool IsON
    {
        get { return isON; }
        set { isON = value; }
    }

    public float PowerTimer
    {
        get { return maxTime; }
        set { maxTime = value; }
    }

    public float PowerReduction
    {
        get { return powerReduction; }
        set { powerReduction = value; }
    }

    public int MinPower
    {
        get { return minPower; }
        set { minPower = value; }
    }

    public int MaxPower
    {
        get { return maxPower; }
        set { maxPower = value; }
    }

    public float MinFlicker
    {
        get { return minFlickerSpeed; }
        set { minFlickerSpeed = value; }
    }

    public float MaxFlicker
    {
        get { return maxFlickerSpeed; }
        set { maxFlickerSpeed = value; }
    }
    #endregion
}
