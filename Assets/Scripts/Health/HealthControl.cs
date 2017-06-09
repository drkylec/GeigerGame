/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthControl : MonoBehaviour {

    public Image healthbar;
    public Image filterGreen;
    public Image filterYellow;
    public Image filterRed;
    public Image batteryBar;
    public Image keyImage;
    public float health;
    public float filter;
    public float battery;
    public PlayerRadiationLevel prl;
    public PlayerFilterLevel pfl;
    public Flashlight batteries;
    public Image image;
    private float alphaOut;

    public Text radiationOutput;

    public bool alphaIn;
    public bool keyOnOff;

    private float fakeTimer;
    private float FakeTimerMax;

    public float waitASec;
    private float waitASecMax;

    // Use this for initialization
    void Start () {
        
        prl = GameObject.FindObjectOfType(typeof(PlayerRadiationLevel)) as PlayerRadiationLevel;
        pfl = GameObject.FindObjectOfType(typeof(PlayerFilterLevel)) as PlayerFilterLevel;
        batteries = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;

        image = GameObject.Find("FadeScreen").GetComponent<Image>();

        radiationOutput = GameObject.Find("RadiationOutput").GetComponent<Text>();

        //keyImage = GameObject.Find("Key").GetComponent<Image>();

        filterGreen = GameObject.Find("FilterGreen").GetComponent<Image>();
        filterYellow = GameObject.Find("FilterYellow").GetComponent<Image>();
        filterRed = GameObject.Find("FilterRed").GetComponent<Image>();

        batteryBar = GameObject.Find("Battery").GetComponent<Image>();

        keyOnOff = false;
        keyImage.enabled = false;

        filterRed.enabled = false;
        filterYellow.enabled = false;
        filterGreen.enabled = true;

        battery = batteries.flashlightBattery;

        health = prl.playerRadiation;
        image.color = new Color(0, 0, 0, 1);
        alphaOut = 1.5f;
        alphaIn = false;
        fakeTimer = 0;
        FakeTimerMax = 1;
        waitASec = 0;
        waitASecMax = 1;
    }

    //void Awake()
    //{
    //    image.color = new Color(1, 1, 1, 1);
    //}
	
	// Update is called once per frame
	void Update () {
        if (!alphaIn)
        {
            alphaOut -= Time.deltaTime;
        }

        health = prl.playerRadiation;
        filter = pfl.filterLevel;
        battery = batteries.flashlightBattery;
        CheckHealth();
        CheckFilter();
        CheckBattery();
        CheckRadiationLevel();

        image.color = new Color(0, 0, 0, alphaOut);

        if(alphaIn)
        {
            alphaOut += Time.deltaTime;

            if((alphaIn)&&(alphaOut >= 1))
            {
                //SceneManager.LoadScene("WinScene");
                SceneManager.LoadScene("CreditsScreen");
            }
        }

        if (alphaOut < 0)
        {
            alphaOut = 0;
        }

        //if(keyOnOff)
        //{
        //    keyImage.enabled = true;
        //}
        //if (!keyOnOff)
        //{
        //    keyImage.enabled = false;
        //}
        
    }

    public void KeyOnOff(bool isOn)
    {
        //isOn = !isOn;
        keyOnOff = isOn;
    }

    void CheckRadiationLevel()
    {
        waitASec += Time.deltaTime;
        if (prl.playerRadiationLevel == 0)
        {
            if (waitASec >= waitASecMax)
            {
                radiationOutput.text = "Radiation " + Random.Range(1, 11).ToString() + "%";
                waitASec = 0;
            }
        }
        else if(prl.playerRadiationLevel == 1)
        {
            if (waitASec >= waitASecMax)
            {
                radiationOutput.text = "Radiation " + Random.Range(26, 50).ToString() + "%";
                waitASec = 0;
            }
        }
        else
        {
            if (waitASec >= waitASecMax)
            {
                radiationOutput.text = "Radiation " + Random.Range(75, 100).ToString() + "%";
                waitASec = 0;
            }
        }
    }

    void CheckHealth()
    {
        //healthbar.rectTransform.localScale = new Vector3(health / 100, healthbar.rectTransform.localScale.y, healthbar.rectTransform.localScale.z);
        healthbar.rectTransform.localScale = new Vector3(health / 100, health / 100, health / 100);

        if(health>=100.0f)
        {
            health = 100.0f;
            SceneManager.LoadScene("LoseScene");
        }
    }

    void CheckBattery()
    {
        
        batteryBar.rectTransform.localScale = new Vector3(battery / 35, batteryBar.rectTransform.localScale.y, batteryBar.rectTransform.localScale.z);

        if(battery <= 20)
        {
            fakeTimer += Time.deltaTime;

            if (fakeTimer >= FakeTimerMax)
            {
                batteryBar.enabled = false;

                if (fakeTimer >= FakeTimerMax * 2)
                {
                    batteryBar.enabled = true;
                    fakeTimer = 0;
                }
            }
            //StartCoroutine(Flicker());
        }
        else
        {
            batteryBar.enabled = true;
        }

    }

    //IEnumerator Flicker()
    //{
    //    batteryBar.enabled = false;
    //    yield return new WaitForSeconds(3.0f);
    //    batteryBar.enabled = true;
    //    yield return new WaitForSeconds(3.0f);
    //}

    void CheckFilter()
    {
        if (filter <= 0)
        {
            filter = 0;
        }

        //filterbar.rectTransform.localScale = new Vector3(filter / 100, filterbar.rectTransform.localScale.y, filterbar.rectTransform.localScale.z);

        if(filter >= 55)
        {
            filterGreen.enabled = true;
            filterYellow.enabled = false;
            filterRed.enabled = false;
        }
        else if((filter <= 54) && (filter >= 26))
        {
            filterGreen.enabled = false;
            filterYellow.enabled = true;
            filterRed.enabled = false;
        }
        else if((filter <= 25) && (filter >=1))
        {
            filterGreen.enabled = false;
            filterYellow.enabled = false;
            filterRed.enabled = true;
        }
        else
        {
            filterGreen.enabled = false;
            filterYellow.enabled = false;
            filterRed.enabled = false;
        }

        if(filter <= 0)
        {
            filter = 0;
        }
    }

    public bool AlphaIn
    {
        get { return alphaIn; }
        set { alphaIn = value; }
    }
}
