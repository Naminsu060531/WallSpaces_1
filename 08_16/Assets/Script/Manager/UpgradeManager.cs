using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public int[] price;
    public int[] level;
    public Text[] price_UI, level_UI;

    private void Start()
    {
        TextSet();
    }

    public void upgradeLevel_HP()
    {
        int hasGold = PlayerPrefs.GetInt("Gold");

        if (hasGold < price[0])
        {
            Debug.Log("°ñµå ºÎÁ·");
            return;
        }

        hasGold -= price[0];

        PlayerPrefs.SetInt("Gold", hasGold);

        price[0] += 50;

        int a = PlayerPrefs.GetInt("HP_Level");
        PlayerPrefs.SetInt("HP_Level", a += 1);
        Debug.Log("HP Level : " + PlayerPrefs.GetInt("HP_Level"));
        TextSet();
    }

    public void upgradeLevel_Speed()
    {
        int hasGold = PlayerPrefs.GetInt("Gold");

        if (hasGold < price[0])
        {
            Debug.Log("°ñµå ºÎÁ·");
            return;
        }

        hasGold -= price[0];

        PlayerPrefs.SetInt("Gold", hasGold);

        price[0] += 50;

        int a = PlayerPrefs.GetInt("Speed_Level");
        PlayerPrefs.SetInt("Speed_Level", a += 1);
        Debug.Log("Speed_Level : " + PlayerPrefs.GetInt("Speed_Level"));
        TextSet();
    }

    public void upgradeLevel_Attack()
    {
        int hasGold = PlayerPrefs.GetInt("Gold");

        if (hasGold < price[0])
        {
            Debug.Log("°ñµå ºÎÁ·");
            return;
        }

        hasGold -= price[0];

        PlayerPrefs.SetInt("Gold", hasGold);

        price[0] += 50;

        int a = PlayerPrefs.GetInt("Attack_Level");
        PlayerPrefs.SetInt("Attack_Level", a += 1);
        Debug.Log("Attack_Level" + PlayerPrefs.GetInt("Attack_Level"));
        TextSet();
    }

    public void TextSet()
    {
        for (int i = 0; i < price.Length; i++)
        {
            price_UI[i].text = price[i].ToString();
            level_UI[i].text = "Level : " + level[i].ToString();
        }
    }
}
