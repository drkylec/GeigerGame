/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FilterCollect : MonoBehaviour {

    PlayerFilterLevel pfl;

    public AudioClip audio;
    AudioSource audiosource;

    public Text getItem;
    public string itemText;

    private bool showText;
    private float timer = 0.0f;
    private float timerMax = 5.0f;

    // Use this for initialization
    void Start () {
        pfl = GameObject.FindObjectOfType(typeof(PlayerFilterLevel)) as PlayerFilterLevel;
        audiosource = GetComponent<AudioSource>();

        getItem = GameObject.Find("ItemGetFilter").GetComponent<Text>();
        getItem.enabled = false;
        itemText = "Picked Up Filter";
        getItem.text = itemText;
        showText = false;
    }

    void Update()
    {
        if (showText)
        {
            TextShowHide();
        }
    }

    void TextShowHide()
    {
        timer += 1 * Time.deltaTime;
        getItem.enabled = true;
        if (timer >= timerMax)
        {
            getItem.enabled = false;
            timer = 0.0f;
            showText = false;
            Destroy(this.gameObject);
        }
    }

    //adds the filter level back to 100%
    void OnTriggerStay(Collider col)
    {
        if (pfl.filterLevel < 99.0f)
        {
            if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButtonDown("X")))
            {
                transform.position = new Vector3(-9999, -9999, -9999);
                pfl.RefillFilter();
                showText = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                

                //Destroy(this.gameObject, audiosource.clip.length);
            }
        }
    }
}
