/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour {

    PlayerKeys playerKeys;
    public int index = 0;
    //public AnimationClip clip;
    public Animator animator;

    public AudioClip[] audio;

    public HealthControl healthControl;
    public CameraScript cs;

    public Text[] obj;
    public Image[] objStrike;

    //single doors
    private bool open;
    private bool open0;
    private bool open1;
    //double doors
    private bool opendouble0;
    private bool opendouble01;

    private bool opendouble1;
    private bool opendouble12;

    private bool opendouble2;
    private bool opendouble22;

    private bool opendouble3;
    private bool opendouble32;

    private bool opendouble4;
    private bool opendouble42;

    private bool opendouble5;
    private bool opendouble52;

    private bool opendouble6;
    private bool opendouble62;

    private bool opendouble7;
    private bool opendouble72;

    private bool opendouble8;
    private bool opendouble82;

    private bool opendouble9;
    private bool opendouble92;

    private bool opendouble10;
    private bool opendouble102;

    private bool opendouble11;
    private bool opendouble112;

    private int wait = 0;
    private int waitTimer = 100;

    public Text door;
    public Text doorShadow;
    public Text doorOther;
    public Text doorOtherShadow;

    public Text update;

    public static bool canOpen;

    // Use this for initialization
    void Start () {
        playerKeys = GameObject.FindObjectOfType(typeof(PlayerKeys)) as PlayerKeys;
        healthControl = GameObject.FindObjectOfType(typeof(HealthControl)) as HealthControl;
        cs = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        //GetComponent<Animation>().IsPlaying("DoorOpen");
        animator = GetComponent<Animator>();

        //singles
        open = false;
        CanOpen(false);
        //open0 = false;

        //open1 = false;

        ////doubles
        //opendouble0 = false;
        //opendouble01 = false;

        //opendouble1 = false;
        //opendouble12 = false;

        //opendouble2 = false;
        //opendouble22 = false;

        //opendouble3 = false;
        //opendouble32 = false;

        //opendouble4 = false;
        //opendouble42 = false;

        //opendouble5 = false;
        //opendouble52 = false;

        //opendouble6 = false;
        //opendouble62 = false;

        //opendouble7 = false;
        //opendouble72 = false;

        //opendouble8 = false;
        //opendouble82 = false;

        //opendouble9 = false;
        //opendouble92 = false;

        //opendouble10 = false;
        //opendouble102 = false;

        //opendouble11 = false;
        //opendouble112 = false;

        // Wrap the clip in a playable
        //var clipPlayable = new AnimationClipPlayable(clip);

        //default text for every door
        door.text = "Locked";
        doorShadow.text = "Locked";
        doorOtherShadow.text = "Locked";
        doorOther.text = "Locked";
        //disabled at start of the game
        door.enabled = false;
        doorShadow.enabled = false;
        doorOther.enabled = false;
        doorOtherShadow.enabled = false;

        //ghets the text for the objectives
        obj[0] = GameObject.Find("obj2").GetComponent<Text>();
        obj[1] = GameObject.Find("obj3").GetComponent<Text>();
        obj[2] = GameObject.Find("obj4").GetComponent<Text>();
        obj[3] = GameObject.Find("obj5").GetComponent<Text>();
        obj[4] = GameObject.Find("obj6").GetComponent<Text>();
        obj[5] = GameObject.Find("obj7").GetComponent<Text>();
        //obj[6] = GameObject.Find("obj8").GetComponent<Text>();

        for(int x = 0; x<obj.Length; x++)
        {
            obj[x].enabled = false;
        }

        //ghets the image for the objectives strikethrough
        objStrike[0] = GameObject.Find("Strikethrough").GetComponent<Image>();
        objStrike[1] = GameObject.Find("Strikethrough1").GetComponent<Image>();
        objStrike[2] = GameObject.Find("Strikethrough2").GetComponent<Image>();
        objStrike[3] = GameObject.Find("Strikethrough3").GetComponent<Image>();
        objStrike[4] = GameObject.Find("Strikethrough4").GetComponent<Image>();
        objStrike[5] = GameObject.Find("Strikethrough5").GetComponent<Image>();
        //objStrike[6] = GameObject.Find("Strikethrough6").GetComponent<Image>();
        //objStrike[7] = GameObject.Find("Strikethrough7").GetComponent<Image>();

        for (int x = 0; x < obj.Length; x++)
        {
            objStrike[x].enabled = false;
        }

        update = GameObject.Find("ObjectiveUpdate").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update() {
        //single doors
        this.animator.SetBool("opener", open);

        //animator.SetBool("Open0", open0);

        //animator.SetBool("Open1", open1);

        ////double doors
        //animator.SetBool("OpenDouble0", opendouble0);
        //animator.SetBool("OpenDouble01", opendouble01);
        
        //animator.SetBool("OpenDouble1", opendouble1);
        //animator.SetBool("OpenDouble12", opendouble12);

        //animator.SetBool("OpenDouble2", opendouble2);
        //animator.SetBool("OpenDouble22", opendouble22);

        //animator.SetBool("OpenDouble3", opendouble3);
        //animator.SetBool("OpenDouble32", opendouble32);

        //animator.SetBool("OpenDouble4", opendouble4);
        //animator.SetBool("OpenDouble42", opendouble42);

        //animator.SetBool("OpenDouble5", opendouble5);
        //animator.SetBool("OpenDouble52", opendouble52);

        //animator.SetBool("OpenDouble6", opendouble6);
        //animator.SetBool("OpenDouble62", opendouble62);

        //animator.SetBool("OpenDouble7", opendouble7);
        //animator.SetBool("OpenDouble72", opendouble72);

        //animator.SetBool("OpenDouble8", opendouble8);
        //animator.SetBool("OpenDouble82", opendouble82);

        //animator.SetBool("OpenDouble9", opendouble9);
        //animator.SetBool("OpenDouble92", opendouble92);

        //animator.SetBool("OpenDouble10", opendouble10);
        //animator.SetBool("OpenDouble102", opendouble102);

        //animator.SetBool("OpenDouble11", opendouble11);
        //animator.SetBool("OpenDouble112", opendouble112);

    }

    //disable trigger so the door open sound only plays once
    void DisableTrigger()
    {
        (this.gameObject.GetComponent(typeof(Collider)) as Collider).enabled = false;
    }

    #region Trigger
    //check for key and open if have it else do not open door
    void OnTriggerStay(Collider col)
    {
        if (!canOpen)
        {
            DoorEnabler();
            DoorTextWait();
            //return;
        }
        else
        {
            playerKeys = GameObject.FindObjectOfType(typeof(PlayerKeys)) as PlayerKeys;
            if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Fire1")) || (Input.GetButton("X")))
            {
                if (playerKeys.key[index] == true)
                {
                    //Debug.Log("Door Opened");
                    if (index == 0)
                    {
                        //enable the next objective and set the timer to 0 again
                        //also enable the first strikethrough to cover the old text
                        //and also make the text visiable again for the screen update to tell the player
                        //to hit tab to see the objectives
                        objStrike[0].enabled = true;
                        obj[0].enabled = true;
                        cs.firstText.enabled = true;
                        cs.textTimer = 0;

                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                        DoorDisabler();
                    }
                    if (index == 1)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 2)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 3)
                    {
                        objStrike[3].enabled = true;
                        obj[3].enabled = true;
                        cs.firstText.enabled = true;
                        cs.textTimer = 0;

                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 4)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 5)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 6)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 7)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 8)
                    {
                        

                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 9)
                    {
                        objStrike[2].enabled = true;
                        obj[2].enabled = true;
                        cs.firstText.enabled = true;
                        cs.textTimer = 0;

                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 10)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 11)
                    {
                        objStrike[1].enabled = true;
                        obj[1].enabled = true;
                        cs.firstText.enabled = true;
                        cs.textTimer = 0;

                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 12)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 13)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    if (index == 14)
                    {
                        DoorDisabler();
                        healthControl.KeyOnOff(false);
                        healthControl.keyImage.enabled = false;
                        open = true;
                        DisableTrigger();
                        PlayDoorSound();
                    }
                    //DoorDisabler();
                }
                if (index == 15)
                {
                    //DoorDisabler();
                    //reserved for doors that do not need keys
                    healthControl.KeyOnOff(false);
                    healthControl.keyImage.enabled = false;
                    open = true;
                    DisableTrigger();
                    PlayDoorSound();
                    DoorDisabler();
                }
                else
                {
                    //DoorDisabler();
                    //Debug.Log("You need a key!");
                }
            }
            if (playerKeys.key[index] == true)
            {
                //Debug.Log("Door Opened");
                if (index == 0)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 1)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 2)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 3)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 4)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 5)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 6)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 7)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 8)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 9)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 10)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 11)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 12)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 13)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 14)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }
                if (index == 15)
                {
                    DoorEnabler();
                    DoorTextOpen();
                }

            }
            else
            {
                DoorEnabler();
                DoorTextLocked();
            }
        }
        
    }

    void OnTriggerExit()
    {
        door.enabled = false;
        doorShadow.enabled = false;
        doorOther.enabled = false;
        doorOtherShadow.enabled = false;
    }
    #endregion

    void DoorEnabler()
    {
        door.enabled = true;
        doorShadow.enabled = true;
        doorOther.enabled = true;
        doorOtherShadow.enabled = true;
    }

    void DoorDisabler()
    {
        door.enabled = false;
        doorShadow.enabled = false;
        doorOther.enabled = false;
        doorOtherShadow.enabled = false;
        Destroy(this.door);
        Destroy(this.doorShadow);
        Destroy(this.doorOther);
        Destroy(this.doorOtherShadow);
    }

    void DoorTextOpen()
    {
        door.text = "Open";
        doorOther.text = door.text;
        doorShadow.text = door.text;
        doorOtherShadow.text = door.text;
    }

    void DoorTextLocked()
    {
        door.text = "Locked";
        doorOther.text = door.text;
        doorShadow.text = door.text;
        doorOtherShadow.text = door.text;
    }

    void DoorTextWait()
    {
        door.text = "Wait";
        doorOther.text = door.text;
        doorShadow.text = door.text;
        doorOtherShadow.text = door.text;
    }

    public bool CanOpen(bool open)
    {
        canOpen = open;
        return open;
    }

    void PlayDoorSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        //audio
        //if (audioSource.isPlaying) return;
        audioSource.clip = audio[0];
        //audioSource.loop = true;
        audioSource.Play();
    }
}
