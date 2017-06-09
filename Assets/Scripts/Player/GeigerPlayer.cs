/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class GeigerPlayer : MonoBehaviour {

    public float geigerMeter;
    Geiger geiger;

    public AudioClip[] audio;

    //public AudioMixer am;

    private int audioCut0 = 0;
    private int audioCut1 = 2;
    private int audioCut2 = 4;

    public int geigerLevel = 0;

    enum GeigerLevels { low, med, high };
    GeigerLevels geigerLevels = GeigerLevels.low;

    // Use this for initialization
    void Start () {
	    geiger = GameObject.FindObjectOfType(typeof(Geiger)) as Geiger;
        audioCut0 = 0;
        audioCut1 = 2;
        audioCut2 = 4;

        //am.SetFloat("Geiger", -30.0f);
    }
	
	// Update is called once per frame
    //changes geiger level to work with case switch
    //case then applies random numbers based on the values given to it by Geiger.cs
	void Update () {
        //geigerMeter -= geiger.GeigerMeter;

        AudioSource audioSource = GetComponent<AudioSource>();

        if (geigerLevel == 0)
        {
            geigerLevels = GeigerLevels.low;
        }
        else if (geigerLevel == 1)
        {
            geigerLevels = GeigerLevels.med;
        }
        else
        {
            geigerLevels = GeigerLevels.high;
        }

        switch (geigerLevels)
        {
            case GeigerLevels.low:
                //Debug.Log("Low");
                geigerMeter = Random.Range(geiger.LowGeigerA, geiger.LowGeigerB);

                if(audioCut0 == 0)
                {
                    audioSource.Stop();
                    audioCut0++;
                    audioCut1 = 2;
                    audioCut2 = 4;
                    //am.SetFloat("Geiger", -30.0f);
                }
                
                //audio
                if (audioSource.isPlaying) return;
                audioSource.clip = audio[0];
                audioSource.volume = 0.1f;
                //audioSource.loop = true;
                audioSource.Play();
                break;

            case GeigerLevels.med:
                geigerMeter = Random.Range(geiger.MedGeigerA, geiger.MedGeigerB);

                if (audioCut1 == 2)
                {
                    audioSource.Stop();
                    audioCut1++;
                    audioCut0 = 0;
                    audioCut2 = 4;
                    //am.SetFloat("Geiger", -10.0f);
                }

                //audio
                if (audioSource.isPlaying) return;
                audioSource.clip = audio[1];
                //audioSource.loop = true;
                audioSource.volume = 0.5f;
                audioSource.Play();
                break;

            case GeigerLevels.high:
                //Debug.Log("High");
                geigerMeter = Random.Range(geiger.HighGeigerA, geiger.HighGeigerB);

                if (audioCut2 == 4)
                {
                    audioSource.Stop();
                    audioCut2++;
                    audioCut1 = 2;
                    audioCut0 = 0;
                    //am.SetFloat("Geiger", 0.0f);
                }

                //audio
                if (audioSource.isPlaying) return;
                audioSource.clip = audio[2];
                audioSource.volume = 0.7f;
                //audioSource.loop = true;
                audioSource.Play();
                break;
        }
    }

    public void GeigerLevelMeter(int level)
    {
        if (level == 0)
        {
            geigerLevels = GeigerLevels.low;
        }
        if(level == 1)
        {
            geigerLevels = GeigerLevels.med;
        }
        if(level == 2)
        {
            geigerLevels = GeigerLevels.high;
        }
    }

    public float GeigerMeter
    {
        get { return geigerMeter; }
        set { geigerMeter = value; }
    }

    public int GeigerLevel
    {
        get { return geigerLevel; }
        set { geigerLevel = value; }
    }
}
