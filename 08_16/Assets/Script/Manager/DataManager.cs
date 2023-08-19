using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void DataReset()
    {
        PlayerPrefs.SetInt("hasGold", 0);
        PlayerPrefs.SetInt("HP_Lvl", 1);
        PlayerPrefs.SetInt("SPEED_Lvl", 1);
        PlayerPrefs.SetInt("ATTACK_Lvl", 1);
        PlayerPrefs.SetInt("Score", 0);
    }
}
