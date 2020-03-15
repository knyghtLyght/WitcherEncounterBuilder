using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace XML
{
    [XmlRoot]
    public class WEBRoot
    {
        [XmlElement("Monster")] public List<Monster> monsters;
    }

    public class Monster
    {
        [XmlAttribute("ID")] public Guid id;
        [XmlAttribute("Name")] public string name;
        [XmlAttribute("Bounty")] public int bounty;
        [XmlElement("Threat")] public Threat threat;
    }

    public class Threat
    {
        [XmlAttribute("Difficulty")] public string difficulty;
        [XmlAttribute("Complexity")] public string complexity;
    }
}

public class DatabaseMinipulator : MonoBehaviour
{
    public string filename = "MonsterDb.xml";

    void Start()
    {
        // Build Root object TODO load not build
        var objToSerialize = new XML.WEBRoot();
        objToSerialize.monsters = new List<XML.Monster>(3);
        for (int i = 0; i != objToSerialize.monsters.Capacity; i++)
        {
            var monster = new XML.Monster();
            monster.id = Guid.NewGuid();
            monster.name = "test" + i + 1;
            monster.bounty = (i + 2) * 2;
            monster.threat = new XML.Threat();
            monster.threat.difficulty = "Easy";
            monster.threat.complexity = "simple";
            objToSerialize.monsters.Add(monster);
        }

        // serialize / save to disk
        using (var xmlStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read))
        {
            var serializer = new XmlSerializer(typeof(XML.WEBRoot));
            serializer.Serialize(xmlStream, objToSerialize);
        }

        // deserialize / load from disk
        XML.WEBRoot deserializedObject;
        using (var xmlStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            var serializer = new XmlSerializer(typeof(XML.WEBRoot));
            deserializedObject = (XML.WEBRoot)serializer.Deserialize(xmlStream);
        }
        for (int i = 0; i != deserializedObject.monsters.Count; i++)
        {
            Debug.Log(deserializedObject.monsters[i].id);
            Debug.Log(deserializedObject.monsters[i].name);
            Debug.Log(deserializedObject.monsters[i].bounty);
            Debug.Log(deserializedObject.monsters[i].threat.difficulty);
            Debug.Log(deserializedObject.monsters[i].threat.complexity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
