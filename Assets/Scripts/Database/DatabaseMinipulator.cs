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
        [XmlAttribute("Armor")] public int armor;
        [XmlElement("Threat")] public Threat threat;
        [XmlElement("Statistics")] public Threat statistics;
        [XmlElement("Skills")] public Skills skills;
        [XmlElement("Abilities")] public List<Abilities> abilities;
        [XmlElement("Vulnerabilities")] public List<Vulnerabilities> vulnerabilities;
        [XmlElement("MutagenRecoverySection")] public MutagenRecoverySection mutagenRecoverySection;
        [XmlElement("Lore")] public Lore lore;
        [XmlElement("Loot")] public List<Loot> loot;
        [XmlElement("Weapons")] public List<Weapon> weapons;
    }

    public class Threat
    {
        [XmlAttribute("Difficulty")] public string difficulty;
        [XmlAttribute("Complexity")] public string complexity;
    }

    public class Lore
    {
        [XmlAttribute("WitcherKnowledge")] public string witcherKnowledge;
        [XmlAttribute("WitcherTrainingDC")] public int witcherTrainingDC;
        [XmlAttribute("CommonerSuperstition")] public string commonerSuperstition;
        [XmlAttribute("EducationDC")] public int educationDC;
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

    // Loot Section
    #region
    public abstract class Loot
    {
        [XmlAttribute("Name")] public string name;
        [XmlAttribute("AmountDie")] public int amountDie;
        [XmlAttribute("RangeValue")] public int rangeValue;
    }

    public class VampireTeeth : Loot
    {
        public VampireTeeth()
        {
            name = "Vampire Teeth";
            amountDie = 10;
            rangeValue = 1;
        }
    }

    #endregion

    // Weapon Objects
    #region
    public class Weapons
    {
        [XmlElement("Weapons")] public List<Weapon> weapons;
    }

    public abstract class Weapon
    {
        [XmlAttribute("Name")] public string name;
        [XmlAttribute("DamageDie")] public int damageDie;
        [XmlAttribute("NumberOfDamageDie")] public int numberOfDamageDie;
        [XmlElement("WeaponEffects")] public List<Abilities> weaponEffects;
        [XmlAttribute("RateOfFire")] public int rateOfFire;
    }

    public class Claws : Weapon
    {
        public Claws()
        {
            name = "Claws";
            damageDie = 6;
            numberOfDamageDie = 5;
            rateOfFire = 2;
        }
    }

    public class Bite : Weapon
    {
        public Bite()
        {
            name = "Bite";
            damageDie = 6;
            numberOfDamageDie = 2;
            rateOfFire = 1;
            weaponEffects = new List<Abilities>();
            weaponEffects.Add(new Bleed());
            weaponEffects.Add(new AnaestheticSalivaAbility());
        }
    }

    #endregion

    // Weapon Effects
    #region
    public abstract class WeaponEffect : Abilities
    {
        [XmlAttribute("Rate")] public int rate { get; set; }
    }

    public class Bleed : WeaponEffect
    {
        public Bleed()
        {
            name = "Bleed";
            rate = 100;
        }
    }
    #endregion

    // Mutegen Section
    #region
    public class MutagenRecoverySection
    {
        [XmlAttribute("Decoction")] public string decoction;
        [XmlAttribute("Description")] public string description;
        [XmlElement("DecoctionFormulae")] public DecoctionFormulae decoctionFormulae;
        [XmlElement("Mutagen")] public Mutagen mutagen;
    }

    public class DecoctionFormulae
    {
        [XmlAttribute("Name")] public string name;
        [XmlAttribute("CraftDC")] public int craftDC;
        [XmlAttribute("CraftTime")] public float craftTime;
        [XmlElement("Components")] public List<AlchemyComponents> components;
    }

    public class Mutagen
    {
        [XmlAttribute("Name")] public string name;
        [XmlAttribute("Effect")] public string effect;
        [XmlAttribute("AlchemyDC")] public int alchemyDC;
        [XmlAttribute("MinorMutation")] public string minorMutation;
    }

    #endregion

    // Skills Objects
    #region
    public class Skills
    {
        [XmlElement("IntelligenceSkills")] public IntelligenceSkills intelligenceSkills;
        [XmlElement("ReflexSkills")] public ReflexSkills reflexSkills;
        [XmlElement("DexteritySkills")] public DexteritySkills dexteritySkills;
        [XmlElement("BodySkills")] public BodySkills bodySkills;
        [XmlElement("EmpathySkills")] public EmpathySkills empathySkills;
        [XmlElement("CraftSkills")] public CraftSkills craftSkills;
        [XmlElement("WillSkills")] public WillSkills willSkills;
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
        [XmlAttribute("Performance")] public float performance;
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

    #endregion

    // Abilitie Objects
    #region
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

    public class FastCharge : Abilities
    {
        public FastCharge()
        {
            name = "Fast Charge";
            description = "Alps can use the charge special attack at no penalties and can split their movement before and after one if it moves in a straight line.";
        }
    }

    public class IllusionAbility : Abilities
    {
        public IllusionAbility()
        {
            name = "Illusion";
            description = "An alp is capable of instantly raising an illusion to make it look like a beautiful woman with features of its choosing, a wolf, or a cat. This illusion can be dispelled with a DC:15 Spell Casting roll.";
        }
    }

    public class InvisibleToMagicalScanningAbility : Abilities
    {
        public InvisibleToMagicalScanningAbility()
        {
            name = "Invisible to Magical Scanning";
            description = "Alps cannot be detected by witcher medallions. Mages must succeed at a Magic Training roll against the alp’s Resist Magic roll to sense them.";
        }
    }

    public class NightVision : Abilities
    {
        public NightVision()
        {
            name = "Night Vision";
            description = "Alps operate in areas of dim light with no penalties.";
        }
    }

    public class AnaestheticSalivaAbility : Abilities
    {
        public AnaestheticSalivaAbility()
        {
            name = "Anaesthetic Saliva";
            description = "If the saliva of an alp touches a target’s skin they must make a Stun save at -2 or be rendered unconscious next round. Golden Oriole renders the drinker immune to this.";
        }
    }

    public class SonicScreechAbility : Abilities
    {
        public SonicScreechAbility()
        {
            name = "Sonic Screech";
            description = "An alp can take its turn to let out a screech which forces anyone within 10m to make a Stun save at -1. It also has a 25% to knock targets prone.";
        }
    }

    #endregion

    // Vulnerabilitie Objects
    #region
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

    public class BlackBloodPotion : Vulnerabilities
    {
        public BlackBloodPotion()
        {
            name = "Black Blood Potion";
        }
    }

    public class BloodTransference : Vulnerabilities
    {
        public BloodTransference()
        {
            name = "Blood Transference";
            description = "Alps are affected by any substances in the blood they drink.";
        }
    }

    public class TouchOfSilver : Vulnerabilities
    {
        public TouchOfSilver()
        {
            name = "Touch of Silver";
            description = "Alps cannot stand the mere touch of silver. Any damage with silver weapons is doubled and contact with it causes damage as fire.";
        }
    }

    public class MoondustBomb : Vulnerabilities
    {
        public MoondustBomb()
        {
            name = "Moondust Bomb";
            description = "An alp caught in the area of a Moondust Bomb is staggered, takes 3d6 damage and has a 25% chance to be set on fire.";
        }
    }
    #endregion

    // Enums
    #region

    public enum AlchemyComponents
    {
        Vitriol,
        Rebis,
        Aether,
        Quebrith,
        Hydragenum,
        Vermilion,
        Sol,
        Caelum,
        Fulgur
    }

    #endregion
    }

public class DatabaseMinipulator : MonoBehaviour
{
    public string filename = "MonsterDb.xml";

    [HideInInspector]
    public XML.WEBRoot deserializedObject;

    void Awake()
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

        objToSerialize.monsters.Add(MonsterAdd("Alp"));

        // serialize / save to disk
        using (var xmlStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read))
        {
            // Get all derived classes
            var knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
                t => typeof(XML.Abilities).IsAssignableFrom(t) ||
                typeof(XML.Weapon).IsAssignableFrom(t) ||
                typeof(XML.WeaponEffect).IsAssignableFrom(t) ||
                typeof(XML.Loot).IsAssignableFrom(t) ||
                typeof(XML.Vulnerabilities).IsAssignableFrom(t)).ToArray();
            // serialize
            var serializer = new XmlSerializer(typeof(XML.WEBRoot), knownTypes);
            serializer.Serialize(xmlStream, objToSerialize);
        }

        // deserialize / load from disk
        using (var xmlStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            // Get all derived classes
            var knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
                t => typeof(XML.Abilities).IsAssignableFrom(t) ||
                typeof(XML.Weapon).IsAssignableFrom(t) ||
                typeof(XML.WeaponEffect).IsAssignableFrom(t) ||
                typeof(XML.Loot).IsAssignableFrom(t) ||
                typeof(XML.Vulnerabilities).IsAssignableFrom(t)).ToArray();
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Test Monster
    XML.Monster MonsterAdd(string name)
    {
        var monster = new XML.Monster();
        monster.id = Guid.NewGuid();
        monster.name = name;
        monster.bounty = 1000;
        monster.armor = 0;
        monster.threat = new XML.Threat();
        monster.threat.difficulty = "Hard";
        monster.threat.complexity = "Difficult";
        monster.skills = new XML.Skills();
        monster.skills.intelligenceSkills = new XML.IntelligenceSkills();
        monster.skills.intelligenceSkills.awareness = 8f;
        monster.skills.intelligenceSkills.business = 0;
        monster.skills.intelligenceSkills.deduction = 0;
        monster.skills.intelligenceSkills.education = 0;
        monster.skills.intelligenceSkills.commonSpeech = 0;
        monster.skills.intelligenceSkills.elderSpeech = 0;
        monster.skills.intelligenceSkills.dwarven = 0;
        monster.skills.intelligenceSkills.monsterLore = 0;
        monster.skills.intelligenceSkills.socialEtiquette = 0;
        monster.skills.intelligenceSkills.streetwise = 0;
        monster.skills.intelligenceSkills.tactics = 0;
        monster.skills.intelligenceSkills.teaching = 0;
        monster.skills.intelligenceSkills.wildernessSurvival = 0;
        monster.skills.reflexSkills = new XML.ReflexSkills();
        monster.skills.reflexSkills.brawling = 8f;
        monster.skills.reflexSkills.dodge = 10f;
        monster.skills.reflexSkills.melee = 7f;
        monster.skills.reflexSkills.riding = 0;
        monster.skills.reflexSkills.sailing = 0;
        monster.skills.reflexSkills.smallBlades = 0;
        monster.skills.reflexSkills.staffSpear = 0;
        monster.skills.reflexSkills.swordsmanship = 0;
        monster.skills.dexteritySkills = new XML.DexteritySkills();
        monster.skills.dexteritySkills.archery = 0;
        monster.skills.dexteritySkills.athletics = 10f;
        monster.skills.dexteritySkills.crossbow = 0;
        monster.skills.dexteritySkills.slightOfHand = 0;
        monster.skills.dexteritySkills.stealth = 9f;
        monster.skills.bodySkills = new XML.BodySkills();
        monster.skills.bodySkills.physique = 0;
        monster.skills.bodySkills.endurance = 0;
        monster.skills.empathySkills = new XML.EmpathySkills();
        monster.skills.empathySkills.charisma = 9f;
        monster.skills.empathySkills.deceit = 10f;
        monster.skills.empathySkills.fineArts = 0;
        monster.skills.empathySkills.gambling = 0;
        monster.skills.empathySkills.style = 0;
        monster.skills.empathySkills.humanPerception = 8f;
        monster.skills.empathySkills.leadership = 0;
        monster.skills.empathySkills.performance = 0;
        monster.skills.empathySkills.persuasion = 0;
        monster.skills.empathySkills.seduction = 10f;
        monster.skills.craftSkills = new XML.CraftSkills();
        monster.skills.craftSkills.alchemy = 0;
        monster.skills.craftSkills.crafting = 0;
        monster.skills.craftSkills.disguise = 0;
        monster.skills.craftSkills.firstAid = 0;
        monster.skills.craftSkills.forgery = 0;
        monster.skills.craftSkills.pickLock = 0;
        monster.skills.craftSkills.trap = 0;
        monster.skills.willSkills = new XML.WillSkills();
        monster.skills.willSkills.courage = 6f;
        monster.skills.willSkills.hex = 0;
        monster.skills.willSkills.intimidation = 4f;
        monster.skills.willSkills.casting = 0;
        monster.skills.willSkills.resistCoercion = 8f;
        monster.skills.willSkills.resistMagic = 9f;
        monster.skills.willSkills.ritualCrafting = 0;
        monster.abilities = new List<XML.Abilities>();
        monster.abilities.Add(new XML.AnaestheticSalivaAbility());
        monster.abilities.Add(new XML.FastCharge());
        monster.abilities.Add(new XML.IllusionAbility());
        monster.abilities.Add(new XML.InvisibleToMagicalScanningAbility());
        monster.abilities.Add(new XML.NightVision());
        monster.abilities.Add(new XML.Regeneration());
        monster.abilities.Add(new XML.SonicScreechAbility());
        monster.vulnerabilities = new List<XML.Vulnerabilities>();
        monster.vulnerabilities.Add(new XML.BlackBloodPotion());
        monster.vulnerabilities.Add(new XML.BloodTransference());
        monster.vulnerabilities.Add(new XML.MoondustBomb());
        monster.vulnerabilities.Add(new XML.TouchOfSilver());
        monster.vulnerabilities.Add(new XML.VampireOil());
        monster.weapons = new List<XML.Weapon>();
        monster.weapons.Add(new XML.Claws());
        monster.weapons.Add(new XML.Bite());
        monster.mutagenRecoverySection = new XML.MutagenRecoverySection();
        monster.mutagenRecoverySection.decoction = "Alp Decoction";
        monster.mutagenRecoverySection.description = "Grants +2 to Critical Wound Chance rolls.";
        monster.mutagenRecoverySection.decoctionFormulae = new XML.DecoctionFormulae();
        monster.mutagenRecoverySection.decoctionFormulae.name = "Alp Decoction Formulae";
        monster.mutagenRecoverySection.decoctionFormulae.craftDC = 18;
        monster.mutagenRecoverySection.decoctionFormulae.craftTime = .5f;
        monster.mutagenRecoverySection.decoctionFormulae.components = new List<XML.AlchemyComponents>();
        monster.mutagenRecoverySection.decoctionFormulae.components.Add(XML.AlchemyComponents.Rebis);
        monster.mutagenRecoverySection.decoctionFormulae.components.Add(XML.AlchemyComponents.Rebis);
        monster.mutagenRecoverySection.decoctionFormulae.components.Add(XML.AlchemyComponents.Quebrith);
        monster.mutagenRecoverySection.decoctionFormulae.components.Add(XML.AlchemyComponents.Aether);
        monster.mutagenRecoverySection.decoctionFormulae.components.Add(XML.AlchemyComponents.Fulgur);
        monster.mutagenRecoverySection.mutagen = new XML.Mutagen();
        monster.mutagenRecoverySection.mutagen.name = "Alp Mutagen";
        monster.mutagenRecoverySection.mutagen.alchemyDC = 20;
        monster.mutagenRecoverySection.mutagen.effect = "+1 Dodge/Escape";
        monster.mutagenRecoverySection.mutagen.minorMutation = "Visibly swollen veins";
        monster.loot = new List<XML.Loot>();
        monster.loot.Add(new XML.VampireTeeth());
        
        return monster;
    }
}
