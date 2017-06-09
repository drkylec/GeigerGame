/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;

public class MaterialSwitcher : MonoBehaviour {

    #region Variables
    public Material[] material;
    public Renderer rend;
    public float duration = 2.0F;

    public int index = 0;

    public Flashlight flashlight;
    #endregion

    #region Start Update
    // Use this for initialization
    void Start () {
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        index = index % material.Length;
        rend.sharedMaterial = material[index];
    }
	
	// Update is called once per frame
	void Update () {
        rend.sharedMaterial = material[index];
        //rend.material = material[0];
        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //rend.material.Lerp(material[0], material[1],duration);
    }
    #endregion

    #region Trigger
    void OnTriggerEnter(Collider col)
    {
        index = 1;
        rend.sharedMaterial = material[index];
    }

    void OnTriggerStay(Collider col)
    {
        index = 1;
        rend.sharedMaterial = material[index];
    }

    void OnTriggerExit(Collider col)
    {
        index = 0;
        rend.sharedMaterial = material[index];
    }
    #endregion
}
