using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

// Database objects
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
        [XmlElement("Statistics")] public Threat statistics;
        [XmlElement("Skills")] public Skills skills;
        [XmlElement("Abilities")] public List<Abilities> abilities;
        [XmlElement("Vulnerabilities")] public List<Vulnerabilities> vulnerabilities;
    }

    public class Threat
    {
        [XmlAttribute("Difficulty")] public string difficulty;
        [XmlAttribute("Complexity")] public string complexity;
    }

    public class Statistics
    {
        [XmlAttribute("Intel")] public int intel;
        [XmlAttribute("Reflex")] public int reflex;
        [XmlAttribute("Dex")] public int dex;
        [XmlAttribute("Body")] public int body;
        [XmlAttribute("Speed")] public int speed;
        [XmlAttribute("Emp")] public int emp;
        [XmlAttribute("Craft")] public int craft;
        [XmlAttribute("Will")] public int will;
        [XmlAttribute("Luck")] public int luck;
    }

    public class Skills
    {
        [XmlElement("IntelligenceSkills")] public IntelligenceSkills intelligenceSkills;
        [XmlElement("ReflexSkills")] public ReflexSkills reflex;
        [XmlElement("DexteritySkills")] public DexteritySkills dexterity;
        [XmlElement("BodySkills")] public BodySkills body;
        [XmlElement("EmpathySkills")] public EmpathySkills empathy;
        [XmlElement("CraftSkills")] public CraftSkills craft;
        [XmlElement("WillSkills")] public WillSkills will;
    }

    public class IntelligenceSkills
    {
        [XmlAttribute("Awareness")] public float awareness;
        [XmlAttribute("Business")] public float business;
        [XmlAttribute("Deduction")] public float deduction;
        [XmlAttribute("Education")] public float education;
        [XmlAttribute("CommonSpeech")] public float commonSpeech;
        [XmlAttribute("ElderSpeech")] public float elderSpeech;
        [XmlAttribute("Dwarven")] public float dwarven;
        [XmlAttribute("MonsterLore")] public float monsterLore;
        [XmlAttribute("SocialEtiquette")] public float socialEtiquette;
        [XmlAttribute("Streetwise")] public float streetwise;
        [XmlAttribute("Tactics")] public float tactics;
        [XmlAttribute("Teaching")] public float teaching;
        [XmlAttribute("WildernessSurvival")] public float wildernessSurvival;
    }

    public class ReflexSkills
    {
        [XmlAttribute("Brawling")] public float brawling;
        [XmlAttribute("DodgeEscape")] public float dodge;
        [XmlAttribute("Melee")] public float melee;
        [XmlAttribute("Riding")] public float riding;
        [XmlAttribute("Sailing")] public float sailing;
        [XmlAttribute("SmallBlades")] public float smallBlades;
        [XmlAttribute("StaffSpear")] public float staffSpear;
        [XmlAttribute("Swordsmanship")] public float swordsmanship;
    }

    public class DexteritySkills
    {
        [XmlAttribute("Archery")] public float archery;
        [XmlAttribute("Athletics")] public float athletics;
        [XmlAttribute("Crossbow")] public float crossbow;
        [XmlAttribute("SlightOfHand")] public float slightOfHand;
        [XmlAttribute("Stealth")] public float stealth;
    }

    public class BodySkills
    {
        [XmlAttribute("Physique")] public float physique;
        [XmlAttribute("Endurance")] public float endurance;
    }

    public class EmpathySkills
    {
        [XmlAttribute("Charisma")] public float charisma;
        [XmlAttribute("Deceit")] public float deceit;
        [XmlAttribute("FineArts")] public float fineArts;
        [XmlAttribute("Gambling")] public float gambling;
        [XmlAttribute("Style")] public float style;
        [XmlAttribute("HumanPerception")] public float humanPerception;
        [XmlAttribute("Leadership")] public float leadership;
        [XmlAttribute("Persuasion")] public float persuasion;
        [XmlAttribute("Seduction")] public float seduction;
    }

    public class CraftSkills
    {
        [XmlAttribute("Alchemy")] public float alchemy;
        [XmlAttribute("Crafting")] public float crafting;
        [XmlAttribute("Disguise")] public float disguise;
        [XmlAttribute("FirstAid")] public float firstAid;
        [XmlAttribute("Forgery")] public float forgery;
        [XmlAttribute("PickLock")] public float pickLock;
        [XmlAttribute("TrapCrafting")] public float trap;
    }

    public class WillSkills
    {
        [XmlAttribute("Courage")] public float courage;
        [XmlAttribute("HexWeaving")] public float hex;
        [XmlAttribute("Intimidation")] public float intimidation;
        [XmlAttribute("SpellCasting")] public float casting;
        [XmlAttribute("ResistMagic")] public float resistMagic;
        [XmlAttribute("ResistCoercion")] public float resistCoercion;
        [XmlAttribute("RitualCrafting")] public float ritualCrafting;
    }

    public abstract class Abilities
    {
        [XmlAttribute("Name")] public string name { get; set; }
        [XmlAttribute("Description")] public string description { get; set; }
    }

    public class Regeneration : Abilities
    {
        public Regeneration()
        {
            this.name = "Regeneration";
            this.description = "Regenerate 5 points per round";
        }
    }

    public abstract class Vulnerabilities
    {
        [XmlAttribute("Name")] public string name { get; set; }
        [XmlAttribute("Description")] public string description { get; set; }
    }

    public class VampireOil : Vulnerabilities
    {
        public VampireOil()
        {
            this.name = "Vampire Oil";
        }
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
            monster.skills = new XML.Skills();
            monster.skills.intelligenceSkills = new XML.IntelligenceSkills();
            monster.skills.intelligenceSkills.commonSpeech = 5f;
            monster.abilities = new List<XML.Abilities>();
            monster.abilities.Add(new XML.Regeneration());
            monster.vulnerabilities = new List<XML.Vulnerabilities>();
            monster.vulnerabilities.Add(new XML.VampireOil());
            objToSerialize.monsters.Add(monster);
        }

        // serialize / save to disk
        using (var xmlStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read))
        {
            // Get all derived classes
            var knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
                t => typeof(XML.Abilities).IsAssignableFrom(t)).ToArray();
            // serialize
            var serializer = new XmlSerializer(typeof(XML.WEBRoot), knownTypes);
            serializer.Serialize(xmlStream, objToSerialize);
        }

        // deserialize / load from disk
        XML.WEBRoot deserializedObject;
        using (var xmlStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            // Get all derived classes
            var knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
                t => typeof(XML.Abilities).IsAssignableFrom(t)).ToArray();
            // deserialize
            var serializer = new XmlSerializer(typeof(XML.WEBRoot), knownTypes);
            deserializedObject = (XML.WEBRoot)serializer.Deserialize(xmlStream);
        }
        for (int i = 0; i != deserializedObject.monsters.Count; i++)
        {
            Debug.Log(deserializedObject.monsters[i].id);
            Debug.Log(deserializedObject.monsters[i].name);
            Debug.Log(deserializedObject.monsters[i].bounty);
            Debug.Log(deserializedObject.monsters[i].threat.difficulty);
            Debug.Log(deserializedObject.monsters[i].threat.complexity);
            Debug.Log(deserializedObject.monsters[i].skills.intelligenceSkills.commonSpeech);
            Debug.Log(deserializedObject.monsters[i].abilities[0].name);
            Debug.Log(deserializedObject.monsters[i].abilities[0].description);
            Debug.Log(deserializedObject.monsters[i].vulnerabilities[0].name);
            Debug.Log(deserializedObject.monsters[i].vulnerabilities[0].description);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
