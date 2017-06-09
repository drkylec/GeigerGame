/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerZone : MonoBehaviour {

    #region Variables
    //event identifier
    public int index;
    public Flashlight flashlight;
    public HealthControl hc;
    public LockedDoor lockedDoor;

    //public GameObject key = null;

    public int i;
    public int x;

    public float temp;
    public float temp2;

    private bool triggerOneActive;
    //private bool jason1 = false;
    //private bool erin1 = false;

    enum TalkingPart { Empty, Jason1, Jason2, Jason3, Jason4, Jason5, Jason6, Jason7, Jason8, Jason9, Jason10, Erin1, Erin2, Erin3, Erin4, Erin5, Erin6, /*Erin7,*/ Erin8, Erin9, Erin10, Erin11 };
    TalkingPart talking = TalkingPart.Empty;

    AudioSource audiosource;

    //Jason and Erin lines
    public Text Jason_1;
    public Text Jason_2;
    public Text Jason_3;
    public Text Jason_4;
    public Text Jason_5;
    public Text Jason_6;
    public Text Jason_7;
    public Text Jason_8;
    public Text Jason_9;
    public Text Jason_10;
    public Text Erin_1;
    public Text Erin_2;
    public Text Erin_3;
    public Text Erin_4;
    public Text Erin_5;
    public Text Erin_6;
    //public Text Erin_7;
    public Text Erin_8;
    public Text Erin_9;
    public Text Erin_10;
    public Text Erin_11;

    //Jason and Erin back text
    public Text Jason_1a;
    public Text Jason_2a;
    public Text Jason_3a;
    public Text Jason_4a;
    public Text Jason_5a;
    public Text Jason_6a;
    public Text Jason_7a;
    public Text Jason_8a;
    public Text Jason_9a;
    public Text Jason_10a;
    public Text Erin_1a;
    public Text Erin_2a;
    public Text Erin_3a;
    public Text Erin_4a;
    public Text Erin_5a;
    public Text Erin_6a;
    //public Text Erin_7a;
    public Text Erin_8a;
    public Text Erin_9a;
    public Text Erin_10a;
    public Text Erin_11a;

    public AudioClip j1;
    public AudioClip j2;
    public AudioClip j3;
    public AudioClip j4;
    public AudioClip j5;
    public AudioClip j6;
    public AudioClip j7;
    public AudioClip j8;
    public AudioClip j9;
    public AudioClip j10;

    public AudioClip a1;
    public AudioClip a2;
    public AudioClip a3;
    public AudioClip a4;
    public AudioClip a5;
    public AudioClip a6;
    public AudioClip a7;
    public AudioClip a8;
    public AudioClip a9;
    public AudioClip a10;
    #endregion

    static bool isTalking;
    static bool beenTouched;

    // Use this for initialization
    void Start () {
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        hc = GameObject.FindObjectOfType(typeof(HealthControl)) as HealthControl;
        lockedDoor = GameObject.FindObjectOfType(typeof(LockedDoor)) as LockedDoor;

        //key.SetActive(true);

        i = 0;
        x = 0;

        temp = 0;
        temp2 = 100;

        isTalking = false;
        beenTouched = false;

        #region talkingScirpts
        //finds the text files and places them for use.
        Jason_1 = GameObject.Find("Jason_1").GetComponent<Text>();
        Jason_2 = GameObject.Find("Jason_2").GetComponent<Text>();
        Jason_3 = GameObject.Find("Jason_3").GetComponent<Text>();
        Jason_4 = GameObject.Find("Jason_4").GetComponent<Text>();
        Jason_5 = GameObject.Find("Jason_5").GetComponent<Text>();
        Jason_6 = GameObject.Find("Jason_6").GetComponent<Text>();
        Jason_7 = GameObject.Find("Jason_7").GetComponent<Text>();
        Jason_8 = GameObject.Find("Jason_8").GetComponent<Text>();
        Jason_9 = GameObject.Find("Jason_9").GetComponent<Text>();
        Jason_10 = GameObject.Find("Jason_10").GetComponent<Text>();

        Erin_1 = GameObject.Find("Erin_1").GetComponent<Text>();
        Erin_2 = GameObject.Find("Erin_2").GetComponent<Text>();
        Erin_3 = GameObject.Find("Erin_3").GetComponent<Text>();
        Erin_4 = GameObject.Find("Erin_4").GetComponent<Text>();
        Erin_5 = GameObject.Find("Erin_5").GetComponent<Text>();
        Erin_6 = GameObject.Find("Erin_6").GetComponent<Text>();
        //Erin_7 = GameObject.Find("Erin_7").GetComponent<Text>();
        Erin_8 = GameObject.Find("Erin_8").GetComponent<Text>();
        Erin_9 = GameObject.Find("Erin_9").GetComponent<Text>();
        Erin_10 = GameObject.Find("Erin_10").GetComponent<Text>();
        Erin_11 = GameObject.Find("Erin_11").GetComponent<Text>();

        Jason_1a = GameObject.Find("Jason_1a").GetComponent<Text>();
        Jason_2a = GameObject.Find("Jason_2a").GetComponent<Text>();
        Jason_3a = GameObject.Find("Jason_3a").GetComponent<Text>();
        Jason_4a = GameObject.Find("Jason_4a").GetComponent<Text>();
        Jason_5a = GameObject.Find("Jason_5a").GetComponent<Text>();
        Jason_6a = GameObject.Find("Jason_6a").GetComponent<Text>();
        Jason_7a = GameObject.Find("Jason_7a").GetComponent<Text>();
        Jason_8a = GameObject.Find("Jason_8a").GetComponent<Text>();
        Jason_9a = GameObject.Find("Jason_9a").GetComponent<Text>();
        Jason_10a = GameObject.Find("Jason_10a").GetComponent<Text>();

        Erin_1a = GameObject.Find("Erin_1a").GetComponent<Text>();
        Erin_2a = GameObject.Find("Erin_2a").GetComponent<Text>();
        Erin_3a = GameObject.Find("Erin_3a").GetComponent<Text>();
        Erin_4a = GameObject.Find("Erin_4a").GetComponent<Text>();
        Erin_5a = GameObject.Find("Erin_5a").GetComponent<Text>();
        Erin_6a = GameObject.Find("Erin_6a").GetComponent<Text>();
        //Erin_7a = GameObject.Find("Erin_7a").GetComponent<Text>();
        Erin_8a = GameObject.Find("Erin_8a").GetComponent<Text>();
        Erin_9a = GameObject.Find("Erin_9a").GetComponent<Text>();
        Erin_10a = GameObject.Find("Erin_10a").GetComponent<Text>();
        Erin_11a = GameObject.Find("Erin_11a").GetComponent<Text>();

        audiosource = GetComponent<AudioSource>();

        //Jason lines
        Jason_1.enabled = false;
        Jason_2.enabled = false;
        Jason_3.enabled = false;
        Jason_4.enabled = false;
        Jason_5.enabled = false;
        Jason_6.enabled = false;
        Jason_7.enabled = false;
        Jason_8.enabled = false;
        Jason_9.enabled = false;
        Jason_10.enabled = false;

        Jason_1a.enabled = false;
        Jason_2a.enabled = false;
        Jason_3a.enabled = false;
        Jason_4a.enabled = false;
        Jason_5a.enabled = false;
        Jason_6a.enabled = false;
        Jason_7a.enabled = false;
        Jason_8a.enabled = false;
        Jason_9a.enabled = false;
        Jason_10a.enabled = false;

        //Erin lines
        Erin_1.enabled = false;
        Erin_2.enabled = false;
        Erin_3.enabled = false;
        Erin_4.enabled = false;
        Erin_5.enabled = false;
        Erin_6.enabled = false;
        //Erin_7.enabled = false;
        Erin_8.enabled = false;
        Erin_9.enabled = false;
        Erin_10.enabled = false;
        Erin_11.enabled = false;

        Erin_1a.enabled = false;
        Erin_2a.enabled = false;
        Erin_3a.enabled = false;
        Erin_4a.enabled = false;
        Erin_5a.enabled = false;
        Erin_6a.enabled = false;
        //Erin_7a.enabled = false;
        Erin_8a.enabled = false;
        Erin_9a.enabled = false;
        Erin_10a.enabled = false;
        Erin_11a.enabled = false;
        #endregion
    }

    void Update()
    {
        i = x;
        switch(talking)
        {
            case TalkingPart.Empty:
                break;

            case TalkingPart.Jason1:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j1;
                    audiosource.PlayOneShot(j1);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_1.enabled = true;
                Jason_1a.enabled = true;
                temp += Time.deltaTime;
                //if(temp>=temp2)
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Erin1;
                }
                break;

            case TalkingPart.Jason2:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j2;
                    audiosource.PlayOneShot(j2);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_1.enabled = false;
                Erin_1a.enabled = false;
                Jason_2.enabled = true;
                Jason_2a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    temp = 0;
                    x = 1;
                    talking = TalkingPart.Erin2;
                }
                break;

            case TalkingPart.Jason3:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j3;
                    audiosource.PlayOneShot(j3);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_2.enabled = false;
                Erin_2a.enabled = false;
                Jason_3.enabled = true;
                Jason_3a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Erin3;
                }
                break;

            case TalkingPart.Jason4:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j4;
                    audiosource.PlayOneShot(j4);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_3.enabled = false;
                Erin_3a.enabled = false;
                Jason_4.enabled = true;
                Jason_4a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    if (beenTouched)
                    {
                        beenTouched = false;
                        isTalking = false;
                        x = 1;
                        temp = 0;
                        i = x;
                        Jason_4.enabled = false;
                        Jason_4a.enabled = false;
                        talking = TalkingPart.Erin4;
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        //key.SetActive(true);
                        //LockedDoor.canOpen = true;
                        x = 1;
                        Jason_4.enabled = false;
                        Jason_4a.enabled = false;
                        Destroy(this.gameObject);
                    }
                }
                break;

            case TalkingPart.Jason5:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j5;
                    audiosource.PlayOneShot(j5);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_5.enabled = true;
                Jason_5a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Erin5;
                }
                break;

            case TalkingPart.Jason6:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j6;
                    audiosource.PlayOneShot(j6);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_6.enabled = true;
                Jason_6a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Erin6;
                }
                break;

            case TalkingPart.Jason7:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j7;
                    audiosource.PlayOneShot(j7);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_7.enabled = true;
                Jason_7a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Jason_7.enabled = false;
                    Jason_7a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case TalkingPart.Jason8:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j8;
                    audiosource.PlayOneShot(j8);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_8.enabled = true;
                Jason_8a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Erin8;
                }
                break;

            case TalkingPart.Jason9:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j9;
                    audiosource.PlayOneShot(j9);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_9.enabled = false;
                Erin_9a.enabled = false;
                Jason_9.enabled = true;
                Jason_9a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Jason_9.enabled = false;
                    Jason_9a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case TalkingPart.Jason10:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = j10;
                    audiosource.PlayOneShot(j10);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_10.enabled = true;
                Jason_10a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Erin10;
                }
                break;

            case TalkingPart.Erin1:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a1;
                    audiosource.PlayOneShot(a1);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }
                Jason_1.enabled = false;
                Jason_1a.enabled = false;
                Erin_1.enabled = true;
                Erin_1a.enabled = true;
                temp++;
                //if (temp >= temp2)
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Jason2;
                }
                break;

            case TalkingPart.Erin2:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a2;
                    audiosource.PlayOneShot(a2);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_2.enabled = false;
                Jason_2a.enabled = false;
                Erin_2.enabled = true;
                Erin_2a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    flashlight.EventPower();
                    temp = 0;
                    talking = TalkingPart.Jason3;
                }
                break;

            case TalkingPart.Erin3:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a3;
                    audiosource.PlayOneShot(a3);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_3.enabled = false;
                Jason_3a.enabled = false;
                Erin_3.enabled = true;
                Erin_3a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Jason4;
                }
                break;

            case TalkingPart.Erin4:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a4;
                    audiosource.PlayOneShot(a4);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_4.enabled = true;
                Erin_4a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Erin_4.enabled = false;
                    Erin_4a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case TalkingPart.Erin5:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a5;
                    audiosource.PlayOneShot(a5);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_5.enabled = false;
                Jason_5a.enabled = false;
                Erin_5.enabled = true;
                Erin_5a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Erin_5.enabled = false;
                    Erin_5a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case TalkingPart.Erin6:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a6;
                    audiosource.PlayOneShot(a6);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_6.enabled = false;
                Jason_6a.enabled = false;
                Erin_6.enabled = true;
                Erin_6a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Erin_6.enabled = false;
                    Erin_6a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            //case TalkingPart.Erin7:
            //    Jason_7.enabled = false;
            //    Jason_7a.enabled = false;
            //    Erin_7.enabled = true;
            //    Erin_7a.enabled = true;
            //    temp++;
            //    if (temp >= temp2)
            //    {
            //        Erin_7.enabled = false;
            //        Erin_7a.enabled = false;
            //        Destroy(this.gameObject);
            //    }
            //    break;

            case TalkingPart.Erin8:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a7;
                    audiosource.PlayOneShot(a7);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_8.enabled = false;
                Jason_8a.enabled = false;
                Erin_8.enabled = true;
                Erin_8a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Erin_8.enabled = false;
                    Erin_8a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case TalkingPart.Erin9:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a8;
                    audiosource.PlayOneShot(a8);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_9.enabled = true;
                Erin_9a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    temp = 0;
                    talking = TalkingPart.Jason9;
                }
                break;

            case TalkingPart.Erin10:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a9;
                    audiosource.PlayOneShot(a9);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Jason_10.enabled = false;
                Jason_10a.enabled = false;
                Erin_10.enabled = true;
                Erin_10a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Erin_10.enabled = false;
                    Erin_10a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;

            case TalkingPart.Erin11:
                if (audiosource.isPlaying) return;
                if (i == 1)
                {
                    audiosource.clip = a10;
                    audiosource.PlayOneShot(a10);
                    temp2 = audiosource.clip.length;
                    x = 2;
                }

                Erin_11.enabled = true;
                Erin_11a.enabled = true;
                temp++;
                if (!audiosource.isPlaying)
                {
                    x = 1;
                    Erin_11.enabled = false;
                    Erin_11a.enabled = false;
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    void OnTriggerStay(Collider col)
    {
        //add code for events
        if(index == 0)
        {
            LockedDoor.canOpen = true;
            //add code for first event at start of game...
            if (i == 0)
            {
                isTalking = true;
                triggerOneActive = true;
                x = 1;
                temp = 0;
                talking = TalkingPart.Jason1;   
            }
            //Destroy(this.gameObject);
        }
        if(index == 1)
        {
            beenTouched = true;
            //add code for event at hallway of game...
            if (i == 0 && !isTalking)
            {
                temp = 0;
                talking = TalkingPart.Erin4;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if(index == 2)
        {
            //add code for event at living quarters of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Jason5;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 3)
        {
            //add code for event at messhall of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Jason6;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 4)
        {
            //add code for event at storage amunition of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Jason7;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 5)
        {
            //add code for event at offices of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Jason8;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 6)
        {
            //add code for event at comand center of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Erin9;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 7)
        {
            //add code for event at generator room of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Jason10;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 8)
        {
            //add code for event at water treatment of game...
            if (i == 0)
            {
                temp = 0;
                talking = TalkingPart.Erin11;
                x = 1;
            }
            //Destroy(this.gameObject);
        }
        if (index == 9)
        {
            //add code for event at comand center of game...
            hc.AlphaIn = true;
            //Destroy(this.gameObject);
        }
        if (index == 10)
        {
            //add code for extra event in the game...
            //Destroy(this.gameObject);
        }
    }
}
