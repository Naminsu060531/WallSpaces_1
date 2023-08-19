using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public enum upgradeType {NONE, HP, SPEED, ATTACK}
    public upgradeType upType;
    public Text[] Lvl_UI, Price_UI;
    public Text Gold_UI;
    public int[] price, lvl;
    public int upgrade_hp, upgrade_speed, upgrade_attack;

    private void Awake()
    {
        instance = this;
        //PlayerPrefs.SetInt("hasGold", 9999);
    }

    private void Start()
    {
        Price_Set();
    }

    public void CheckGold()
    {
        int gold = PlayerPrefs.GetInt("hasGold");
        Debug.Log("Gold : " + gold);

        switch (upType)
        {
            case upgradeType.HP:
                if (gold >= price[0])
                {
                    gold -= price[0];
                    PlayerPrefs.SetInt("hasGold", gold);
                    StartCoroutine(UpgradeCo());
                }
                else
                    return;
                break;
            case upgradeType.SPEED:
                if (gold >= price[1])
                {
                    gold -= price[1];
                    PlayerPrefs.SetInt("hasGold", gold);
                    StartCoroutine(UpgradeCo());
                }
                else
                    return;
                break;
            case upgradeType.ATTACK:
                if (gold >= price[2])
                {
                    gold -= price[2];
                    PlayerPrefs.SetInt("hasGold", gold);
                    StartCoroutine(UpgradeCo());
                }
                else
                    return;
                break;
        }
    }

    public IEnumerator UpgradeCo()
    {
        Price_Set();
        yield return new WaitForSeconds(0.5f);
        PlayerUpgrade();
        yield return new WaitForSeconds(1.5f);
        Upgrade_Set_NONE();
    }

    public void Upgrade_Set_HP()
    {
        upType = upgradeType.HP;
        Debug.Log("HPUP");
        CheckGold();
    }

    public void Upgrade_Set_SPEED()
    {
        upType = upgradeType.SPEED;
        Debug.Log("SPDUP");
        CheckGold();
    }

    public void Upgrade_Set_ATTACK()
    {
        upType = upgradeType.ATTACK;
        Debug.Log("ATKUP");
        CheckGold();
    }

    public void Upgrade_Set_NONE()
    {
        upType = upgradeType.NONE;
    }

    public void Price_Set()
    {
        Prefs_Get();

        Gold_UI.text = "Gold : " + PlayerPrefs.GetInt("hasGold");

        switch (upType)
        {
            case upgradeType.HP:
                price[0] += (lvl[0] * 100);
                lvl[0]++;
                upgrade_hp++;
                break;
            case upgradeType.SPEED:
                price[1] += (lvl[1] * 150);
                lvl[1]++;
                upgrade_speed++;
                break;
            case upgradeType.ATTACK:
                price[2] += (lvl[2] * 200);
                lvl[2]++;
                upgrade_attack++;
                break;
        }

        for (int i = 0; i < lvl.Length; i++)
        {
            Lvl_UI[i].text = "Level : " + lvl[i];
            Price_UI[i].text = "Price : " + price[i];
        }

        Prefs_Set();
    }

    public void Prefs_Set()
    {
        PlayerPrefs.SetInt("HP_Lvl", upgrade_hp);
        PlayerPrefs.SetInt("SPEED_Lvl", upgrade_speed);
        PlayerPrefs.SetInt("ATTACK_Lvl", upgrade_attack);
    }

    public void Prefs_Get()
    {
        upgrade_hp = PlayerPrefs.GetInt("HP_Lvl");
        upgrade_speed = PlayerPrefs.GetInt("SPEED_Lvl");
        upgrade_attack = PlayerPrefs.GetInt("ATTACK_Lvl");
    }

    public void PlayerUpgrade()
    {
        switch (upType)
        {
            case upgradeType.HP:
                PlayerPrefs.SetInt("HP_Lvl", upgrade_hp);
                break;
            case upgradeType.SPEED:
                PlayerPrefs.SetInt("SPEED_Lvl", upgrade_speed);
                break;
            case upgradeType.ATTACK:
                PlayerPrefs.SetInt("ATTACK_Lvl", upgrade_attack);
                break;
        }

    }
}
