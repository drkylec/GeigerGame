/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyCollect : MonoBehaviour {

    //int to determine what key it is
    public int keyNumber = 0;
    public PlayerKeys playerKeys;

    public AudioClip audio;
    AudioSource audiosource;
    public CameraScript cs;

    public Text getItem;
    public string itemText;

    private bool showText;
    private float timer = 0.0f;
    private float timerMax = 5.0f;

    public HealthControl hc;

    //private Text buttonPress0;
    //private Text buttonPress14;
    //private Text buttonPress13;
    //private Text buttonPress12;
    //private Text buttonPress11;
    //private Text buttonPress9;
    //private Text buttonPress5;
    //private Text buttonPress3;
    //private Text buttonPress2;

    public LockedDoor ld;

    // Use this for initialization
    void Start () {
        playerKeys = GameObject.FindObjectOfType(typeof(PlayerKeys)) as PlayerKeys;
        hc = GameObject.FindObjectOfType(typeof(HealthControl)) as HealthControl;
        ld = GameObject.FindObjectOfType(typeof(LockedDoor)) as LockedDoor;
        cs = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        audiosource = GetComponent<AudioSource>();

        getItem = GameObject.Find("ItemGetKey").GetComponent<Text>();

        //buttonPress0 = GameObject.Find("KeyPress0").GetComponent<Text>();
        //buttonPress14 = GameObject.Find("KeyPress14").GetComponent<Text>();
        //buttonPress13 = GameObject.Find("KeyPress13").GetComponent<Text>();
        //buttonPress12 = GameObject.Find("KeyPress12").GetComponent<Text>();
        //buttonPress11 = GameObject.Find("KeyPress11").GetComponent<Text>();
        //buttonPress9 = GameObject.Find("KeyPress9").GetComponent<Text>();
        //buttonPress5 = GameObject.Find("KeyPress5").GetComponent<Text>();
        //buttonPress2 = GameObject.Find("KeyPress2").GetComponent<Text>();
        //buttonPress3 = GameObject.Find("KeyPress3").GetComponent<Text>();

        getItem.enabled = false;

        //buttonPress0.enabled = false;
        //buttonPress14.enabled = false;
        //buttonPress13.enabled = false;
        //buttonPress12.enabled = false;
        //buttonPress11.enabled = false;
        //buttonPress9.enabled = false;
        //buttonPress5.enabled = false;
        //buttonPress3.enabled = false;
        //buttonPress2.enabled = false;

        itemText = "Picked Up Key";
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

    void OnTriggerStay(Collider col)
    {
        //buttonPress0.enabled = true;
        //buttonPress14.enabled = true;
        //buttonPress13.enabled = true;
        //buttonPress12.enabled = true;
        //buttonPress11.enabled = true;
        //buttonPress9.enabled = true;
        //buttonPress5.enabled = true;
        //buttonPress3.enabled = true;
        //buttonPress2.enabled = true;

        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButtonDown("X")))
        {
            if(keyNumber == 0)
            {
                itemText = "Picked up Reception Key";
                hc.keyImage.enabled = true;
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                showText = true;
                PlaySound();
            }
            if (keyNumber == 1)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 2)
            {
                itemText = "Picked up Storage Room Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 3)
            {
                itemText = "Picked up Office Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 4)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 5)
            {
                itemText = "Picked up Storage Room Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 6)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 7)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 8)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 9)
            {
                itemText = "Picked up Food Storage Room Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 10)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 11)
            {
                itemText = "Picked up Mess Hall Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 12)
            {
                ld.obj[5].enabled = true;
                ld.objStrike[5].enabled = true;
                cs.firstText.enabled = true;
                cs.textTimer = 0;

                itemText = "Opened up Control Room Door";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 13)
            {
                itemText = "Picked up Water Pump Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);
                showText = true;
                //Destroy(this.gameObject, audiosource.clip.length);
            }
            if (keyNumber == 14)
            {
                itemText = "Picked up Generator Key";
                getItem.text = itemText;
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                PlaySound();
                showText = true;
            }
            if (keyNumber == 15)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                PlaySound();
            }
            if (keyNumber == 16)
            {
                playerKeys.key[keyNumber] = true;
                hc.keyImage.enabled = true;
                PlaySound();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        //buttonPress0.enabled = false;
        //buttonPress14.enabled = false;
    }

    void PlaySound()
    {
        if (audiosource.isPlaying) return;
        audiosource.clip = audio;
        audiosource.PlayOneShot(audio);
        transform.position = new Vector3(-999, -999, -999);

        //Destroy(this.gameObject, audiosource.clip.length);
    }
}
