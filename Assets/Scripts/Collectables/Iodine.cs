/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Iodine : MonoBehaviour {
    private PlayerRadiationLevel prl;

    public AudioClip audio;
    AudioSource audiosource;

    public Text getItem;
    public string itemText;

    private bool showText;
    private float timer = 0.0f;
    private float timerMax = 5.0f;

    // Use this for initialization
    void Start () {
        prl = GameObject.FindObjectOfType(typeof(PlayerRadiationLevel)) as PlayerRadiationLevel;
        audiosource = GetComponent<AudioSource>();

        getItem = GameObject.Find("ItemGetIodine").GetComponent<Text>();
        getItem.enabled = false;
        itemText = "Picked Up Iodine";
        getItem.text = itemText;
        showText = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(showText)
        {
            TextShowHide();
        }
	}

    void TextShowHide()
    {
        timer += 1 * Time.deltaTime;
        getItem.enabled = true;
        if(timer >= timerMax)
        {
            getItem.enabled = false;
            timer = 0.0f;
            showText = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButtonDown("X")))
        {
            //Debug.Log("You got it");
            //TODO add battery effects here
            prl.IodineReduction();
            showText = true;
            if (audiosource.isPlaying) return;
            audiosource.clip = audio;
            audiosource.PlayOneShot(audio);
            transform.position = new Vector3(-999, -999, -999);

            //Destroy(this.gameObject, audiosource.clip.length);
        }
    }
}
