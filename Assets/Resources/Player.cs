﻿/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Player{

    #region Camera Helper
    //camera rotation speed
    [XmlElement("rotSpeed")]
    public float rotSpeed;

    [XmlElement("rayLength")]
    public float rayLength;

    [XmlElement("collisionOffset")]
    public float collisionOffset;

    [XmlElement("offsetx")]
    public float offsetx;

    [XmlElement("offsety")]
    public float offsety;

    [XmlElement("offsetz")]
    public float offsetz;
    #endregion

    #region Walkiong Helper
    [XmlElement("gravity")]
    public float gravity;

    [XmlElement("speed")]
    public float speed;
    #endregion

    #region Flashlight Helper
    //flashlight timer before battery power goes down
    [XmlElement("flashlightTimer")]
    public float flashlightPower;

    //flashlight power reduction amount
    [XmlElement("flashlightPowerReduction")]
    public float flashlightPowerReduction;

    //flashlight batteries min and max powers
    [XmlElement("flashlightMinPower")]
    public int flashlightMinPower;

    [XmlElement("flashlightMaxPower")]
    public int flashlightMaxPower;

    //flashlight flicker speeds
    [XmlElement("flashlightMinFlicker")]
    public float flashlightMinFlicker;

    [XmlElement("flashlightMaxFlicker")]
    public float flashlightMaxFlicker;
    #endregion

    #region Geiger
    [XmlElement("lowGeigerA")]
    public float lowGeigerA;

    [XmlElement("lowGeigerB")]
    public float lowGeigerB;

    [XmlElement("medGeigerA")]
    public float medGeigerA;

    [XmlElement("medGeigerB")]
    public float medGeigerB;

    [XmlElement("highGeigerA")]
    public float highGeigerA;

    [XmlElement("highGeigerB")]
    public float highGeigerB;
    #endregion
}