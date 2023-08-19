using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCheckManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Debug.Log("HP_Lvl: " + PlayerPrefs.GetInt("HP_Lvl"));
        Debug.Log("Speed_Lvl : " + PlayerPrefs.GetInt("SPEED_Lvl"));
        Debug.Log("ATK_Lvl : " + PlayerPrefs.GetInt("ATTACK_Lvl"));
    }
}
