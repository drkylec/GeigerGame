/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("PlayerScript")]
public class PlayerContainer{

    [XmlArray("Players")]
    [XmlArrayItem("Player")]
    public List<Player> player = new List<Player>();

    public static PlayerContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(PlayerContainer));

        StringReader reader = new StringReader(_xml.text);

        PlayerContainer pc = serializer.Deserialize(reader) as PlayerContainer;

        reader.Close();

        return pc;
    }
}
