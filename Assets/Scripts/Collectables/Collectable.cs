/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class Collectable : MonoBehaviour {
    //public GameObject paper1;
    //public GameObject paper2;
    public Image[] paper;
    public AudioClip[] audio;
    public Text[] text;
    public Text[] texta;
    public int index = 0;
    public Camera colCam;

    public Text textKC;

    public GameObject playerObject;
    public CameraScript cameraScript;
    public WalkingScript walkingScript;
    public Flashlight flashlight;

    public Transform cameraa;
    public Vector3 camPos = Vector3.zero;

    enum AudioFile { empty, a1, a2, a3 };
    AudioFile af = AudioFile.empty;

    public int s;
    private int a;

    public bool collected = false;

    void Start()
    {
        collected = false;
        AudioSource audioSource = GetComponent<AudioSource>();
        Renderer render = GetComponent<Renderer>();
        cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        text[0] = GameObject.Find("Audio0").GetComponent<Text>();
        text[1] = GameObject.Find("Audio1").GetComponent<Text>();
        text[2] = GameObject.Find("Audio2").GetComponent<Text>();
        texta[0] = GameObject.Find("Audio0a").GetComponent<Text>();
        texta[1] = GameObject.Find("Audio1a").GetComponent<Text>();
        texta[2] = GameObject.Find("Audio2a").GetComponent<Text>();

        paper[0] = GameObject.Find("Document0").GetComponent<Image>();
        paper[1] = GameObject.Find("Document1").GetComponent<Image>();
        paper[2] = GameObject.Find("Document2").GetComponent<Image>();

        textKC = GameObject.Find("PressQorA").GetComponent<Text>();

        a = 0;

        text[0].enabled = false;
        text[1].enabled = false;
        text[2].enabled = false;
        texta[0].enabled = false;
        texta[1].enabled = false;
        texta[2].enabled = false;

        paper[0].enabled = false;
        paper[1].enabled = false;
        paper[2].enabled = false;

        textKC.enabled = false;

    }

    void Update()
    {
        s = a;
        AudioSource audioSource = GetComponent<AudioSource>();
        switch (af)
        {
            case AudioFile.empty:
                break;

            case AudioFile.a1:
                if (audioSource.isPlaying) return;
                if (s == 1)
                {
                    
                    audioSource.clip = audio[index];
                    audioSource.PlayOneShot(audio[index]);
                    transform.position = new Vector3(-999, -999, -999);

                    a = 2;
                }
                if (!audioSource.isPlaying)
                {
                    text[index].enabled = false;
                    texta[index].enabled = false;
                    Destroy(this.gameObject);
                }
                    break;
            
            case AudioFile.a2:
                if (audioSource.isPlaying) return;
                if (s == 1)
                {

                    audioSource.clip = audio[index];
                    audioSource.PlayOneShot(audio[index]);
                    transform.position = new Vector3(-999, -999, -999);

                    a = 2;
                }
                if (!audioSource.isPlaying)
                {
                    text[index].enabled = false;
                    texta[index].enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case AudioFile.a3:
                if (audioSource.isPlaying) return;
                if (s == 1)
                {

                    audioSource.clip = audio[index];
                    audioSource.PlayOneShot(audio[index]);
                    transform.position = new Vector3(-999, -999, -999);

                    a = 2;
                }
                if (!audioSource.isPlaying)
                {
                    text[index].enabled = false;
                    texta[index].enabled = false;
                    Destroy(this.gameObject);
                }
                break;
        }
    }

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
            //Debug.Log("test");
            if (this.gameObject.tag == "Document"+index.ToString())
            {
                collected = true;
                AudioSource audioSource = GetComponent<AudioSource>();
                Renderer render = GetComponent<Renderer>();

                //Debug.Log("You got it");
                cameraScript.canMove = false;
                walkingScript.canMove = false;
                flashlight.isON = false;
                //playerObject.SetActive(false);

                //instantiate the camera for collection
                //colCam = (Camera)Instantiate(colCam, new Vector3(100, 100, 95), transform.rotation);
                camPos = new Vector3(-3.727305f, 14.35f, 216.87f);
                //instantiates the gameobject at camera
                //paper[index] = (GameObject)Instantiate(paper[index], camPos, transform.rotation);
                textKC.enabled = true;
                paper[index].enabled = true;

                audioSource.clip = audio[0];
                audioSource.PlayOneShot(audio[0]);
                transform.position = new Vector3(-999, -999, -999);

                Destroy(this.gameObject, audioSource.clip.length);
            }
            else if (this.gameObject.tag == "Audio" + index.ToString())
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                Renderer render = GetComponent<Renderer>();
                //Debug.Log("You got it");
                //cameraScript.CanMove = false;
                //walkingScript.CanMove = false;
                //flashlight.IsON = false;
                //playerObject.SetActive(false);

                //instantiate the camera for collection
                //colCam = (Camera)Instantiate(colCam, new Vector3(100, 100, 95), transform.rotation);
                //camPos = new Vector3(100, 100, 100);
                //instantiates the gameobject at camera
                //paper[1] = (GameObject)Instantiate(paper[1], camPos, transform.rotation);

                if (index == 0)
                {
                    a = 1;
                    text[index].enabled = true;
                    texta[index].enabled = true;
                    af = AudioFile.a1;
                }

                if (index == 1)
                {
                    a = 1;
                    text[index].enabled = true;
                    texta[index].enabled = true;
                    af = AudioFile.a2;
                }

                if (index == 2)
                {
                    a = 1;
                    text[index].enabled = true;
                    texta[index].enabled = true;
                    af = AudioFile.a3;
                }

                //if (audioSource.isPlaying) return;
                //text[index].enabled = true;
                //audioSource.clip = audio[index];
                //audioSource.PlayOneShot(audio[index]);
                //transform.position = new Vector3(-999,-999,-999);


                //if (!audioSource.isPlaying)
                //{
                //    text[index].enabled = false;
                //    Destroy(this.gameObject, audioSource.clip.length);
                //}
            }
        }
    }
}
