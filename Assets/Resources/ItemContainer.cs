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

[XmlRoot("WalkingScript")]
public class ItemContainer {

    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public List<Item> item = new List<Item>();

    public static ItemContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        StringReader reader = new StringReader(_xml.text);

        ItemContainer items = serializer.Deserialize(reader) as ItemContainer;

        reader.Close();

        return items;
    }
}
