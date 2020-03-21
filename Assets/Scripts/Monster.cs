using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public DatabaseMinipulator dbObject;
    public Text monsterNameLable;

    [Header("Armor group")]
    public Text headArmorLabel;

    [Header("Stat group")]
    public Text intLable;
    public Text refLable;
    public Text dexLable;
    public Text bodyLable;
    public Text spdLable;
    public Text empLable;
    public Text craLable;
    public Text willLable;
    public Text luckLable;

    [Header("Derived group")]
    public Text stunLable;
    public Text runLable;
    public Text leapLable;
    public Text staLable;
    public Text encLable;
    public Text recLable;
    public Text hpLable;
    public Text vigorLable;


    string monsterName;
    XML.Monster monsterObj;


    private void Start()
    {
        monsterName = "Alp";
        for (int i = 0; i != dbObject.deserializedObject.monsters.Count; i++)
        {
            if (dbObject.deserializedObject.monsters[i].name == monsterName)
            {
                monsterObj = dbObject.deserializedObject.monsters[i];
            }
        }


        MonsterInit(monsterObj);
    }

    public void MonsterInit(XML.Monster monsterObj)
    {
        monsterNameLable.text = monsterObj.name;

    }
}
