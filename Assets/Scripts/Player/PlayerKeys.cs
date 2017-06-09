/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/

using UnityEngine;
using System.Collections;

public class PlayerKeys : MonoBehaviour {

    public bool[] key;
    public int index = 0;

    //public bool key1 = false;
    //public bool key2 = false;
    //private bool key3 = false;
    //private bool key4 = false;
    //private bool key5 = false;
    //private bool key6 = false;
    //private bool key7 = false;
    //private bool key8 = false;
    //private bool key9 = false;
    //private bool key10 = false;

    // Use this for initialization
    void Start () {
        //key1 = false;
        //key2 = false;
        //key3 = false;
        //key4 = false;
        //key5 = false;
        //key6 = false;
        //key7 = false;
        //key8 = false;
        //key9 = false;
        //key10 = false;

        for (int i = 0; i<key.Length; i++)
        {
            key[index] = false;
        }
}

    #region Getters and Setter

    public bool Key
    {
        get { return key[index]; }
        set { key[index] = value; }
    }

    //public bool Key1
    //{
    //    get { return key1; }
    //    set { key1 = value; }
    //}

    //public bool Key2
    //{
    //    get { return key2; }
    //    set { key2 = value; }
    //}

    //public bool Key3
    //{
    //    get { return key3; }
    //    set { key3 = value; }
    //}

    //public bool Key4
    //{
    //    get { return key4; }
    //    set { key4 = value; }
    //}

    //public bool Key5
    //{
    //    get { return key5; }
    //    set { key5 = value; }
    //}

    //public bool Key6
    //{
    //    get { return key6; }
    //    set { key6 = value; }
    //}

    //public bool Key7
    //{
    //    get { return key7; }
    //    set { key7 = value; }
    //}

    //public bool Key8
    //{
    //    get { return key8; }
    //    set { key8 = value; }
    //}

    //public bool Key9
    //{
    //    get { return key9; }
    //    set { key9 = value; }
    //}

    //public bool Key10
    //{
    //    get { return key10; }
    //    set { key10 = value; }
    //}

    #endregion
}
