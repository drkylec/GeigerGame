/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Batteries : MonoBehaviour {

    //array to hold batteries
    public GameObject[] batteries;
    public Flashlight flashlight;

    public AudioClip audio;
    AudioSource audiosource;

    public Text getItem;
    public string itemText;

    private bool showText;
    private float timer = 0.0f;
    private float timerMax = 5.0f;

    // Use this for initialization
    void Start () {
        //gets and applies the component automatically
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        audiosource = GetComponent<AudioSource>();

        getItem = GameObject.Find("ItemGetBattery").GetComponent<Text>();
        getItem.enabled = false;
        itemText = "Picked Up Battery";
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

    #region Triggers
    //allows for checks on entering the trigger
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("You are in it");

    }

    //allows the object to be highlighted when implemented
    //allows the player to collect the item
    void OnTriggerStay(Collider col)
    {
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButtonDown("X")))
        {
            if (flashlight.CheckPower < 99.0f)
            {
                //Debug.Log("You got it");
                //TODO add battery effects here
                flashlight.AddPower();
                showText = true;
                if (audiosource.isPlaying) return;
                audiosource.clip = audio;
                audiosource.PlayOneShot(audio);
                transform.position = new Vector3(-999, -999, -999);

                //Destroy(this.gameObject, audiosource.clip.length);
            }
            else
            { }
        }
    }
    #endregion
}
