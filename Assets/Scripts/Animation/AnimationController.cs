/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    Animator animator;
    private bool walkBool;
    private bool turnLeftBool;
    private bool turnRightBool;
    private bool walkBackwardsBool;
    private bool turnBackwardsLeftBool;
    private bool turnBackwardsRightBool;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        walkBool = false;
        turnLeftBool = false;
        turnRightBool = false;
        walkBackwardsBool = false;
        turnBackwardsLeftBool = false;
        turnBackwardsRightBool = false;
    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
    }

    void GetInput()
    {
        //forward
        if (Input.GetKey(KeyCode.W))
        {
            walkBool = true;
            animator.SetBool("Walk", walkBool);
            //    animator.SetFloat("Forward", 1.0f);
        }
        else
        {
            walkBool = false;
            animator.SetBool("Walk", walkBool);
        }

        //left
        if(Input.GetKey(KeyCode.A))
        {
            turnLeftBool = true;
            animator.SetBool("TurnLeft",turnLeftBool);
        }
        else
        {
            turnLeftBool = false;
            animator.SetBool("TurnLeft", turnLeftBool);
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            turnRightBool = true;
            animator.SetBool("TurnRight",turnRightBool);
        }
        else
        {
            turnRightBool = false;
            animator.SetBool("TurnRight", turnRightBool);
        }

        //backwards
        if (Input.GetKey(KeyCode.S))
        {
            walkBackwardsBool = true;
            animator.SetBool("WalkBackwards",walkBackwardsBool);
        }
        else
        {
            walkBackwardsBool = false;
            animator.SetBool("WalkBackwards", walkBackwardsBool);
        }
    }
}
