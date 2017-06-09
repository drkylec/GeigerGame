/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class WalkingScript : MonoBehaviour {

    public bool canMove = true;
    //movement
    public float speed;
    //public float jumpSpeed = 8.0F;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    public float rotSpeed; // rotate speed in degrees/second
    public AudioClip[] audio;

    //private bool walkFloat;

    //public AnimationClip clip;
    //Animator animator;

    public float waitSeconds = 1.5f;

    public float waitTime = 15;
    public float waitTimer = 0;

    public Transform playerSpawn;

    void Start()
    {
        //GetComponent<Animation>().IsPlaying("HumanoidWalk");
        //animator = GetComponent<Animator>();
        //walkFloat = false;
        waitTimer = waitTime - 1;

        this.transform.position = playerSpawn.position;
        this.transform.rotation = playerSpawn.rotation;
    }

    void Update()
    {
        //this.transform.position = playerSpawn.position;
        //this.transform.rotation = playerSpawn.rotation;
        if (canMove)
        {

            CharacterController controller = GetComponent<CharacterController>();
            //Camera camera = GetComponent<Camera>();
            if (controller.isGrounded)
            {
                float rot = (Input.GetAxis("Horizontal") * Input.GetAxis("LeftJoystickX")) * rotSpeed * Time.deltaTime;

                //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                transform.Rotate(Vector3.up, rot);
                //transform.Rotate = Quaternion.AngleAxis(rot, Vector3.up);
                //transform.Rotate(rot);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                //if (Input.GetButton("Jump"))
                //  moveDirection.y = jumpSpeed;
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
            {
                waitTimer++;
                if (waitTimer >= waitTime)
                {
                    WalkSounds();
                    waitTimer = 0;
                }
                //StartCoroutine(WaitForStep());
            }
            else
            {
                waitTimer = waitTime - 1;
            }

            //if(Input.GetKey(KeyCode.W))
            {
                //walkFloat = true;
                //animator.SetBool("Walk", walkFloat);
            //    animator.SetFloat("Forward", 1.0f);
            }
            //else
            //{
            //    animator.SetFloat("Forward", 0.0f);
            //    walkFloat = false;
            //}
        }
        else
        {

        }
    }

    IEnumerator WaitForStep()
    {
        //print(Time.time);
        yield return new WaitForSeconds(waitSeconds);
        //print(Time.time);
    }

    #region Walking Sounds
    //plays a sound from an array at random
    void WalkSounds()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource.isPlaying) return;
        audioSource.clip = audio[Random.Range(0, audio.Length)];
        audioSource.Play();
        //StartCoroutine(WaitForStep());
    }
    #endregion

    #region Getters and Setters
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public float RotSpeed
    {
        get { return rotSpeed; }
        set { rotSpeed = value; }
    }

    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }

    public float MoveSpeed
    {
        get { return speed; }
        set { speed = value; }
    }
    #endregion
}
