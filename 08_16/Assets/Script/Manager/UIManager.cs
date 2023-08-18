using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text HP_UI, Speed_UI, Damage_UI, Score_UI, Gold_UI, HPLvl_UI, SpeedLvl_UI, AttackLvl_UI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        setText();
    }

    public void setText()
    {
        HP_UI.text = "HP : " + Player.instance.hp.ToString();
        Speed_UI.text = "Speed : " + Player.instance.speed.ToString();
        Damage_UI.text = "Attack : " + Player.instance.dmg.ToString();
        Score_UI.text = "Score : " + PlayerPrefs.GetInt("Score");
        Gold_UI.text = "Gold : " + PlayerPrefs.GetInt("Gold");
        HPLvl_UI.text = "Lvl : " + PlayerPrefs.GetInt("HP_Level");
        SpeedLvl_UI.text = "Lvl : " + PlayerPrefs.GetInt("SpeedLvl_UI");
        AttackLvl_UI.text = "Lvl : " + PlayerPrefs.GetInt("Attack_Level");
    }
}
