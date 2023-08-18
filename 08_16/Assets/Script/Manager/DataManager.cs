using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int Score, Gold;
    public float PlayTime;
    public int hour, min, sec;
    public int HP_Level, Speed_Level, Attack_Level;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addScore(int score)
    {
        Score += score;
        int addscore = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", addscore + score);
        UIManager.instance.setText();
    }

    public void addGold(int gold)
    {
        Gold += gold;
        int addscore = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", addscore + Gold);
        UIManager.instance.setText();
    }

    public void TimeSet()
    {
        PlayTime += Time.deltaTime;

        hour = (int)(PlayTime / 3600);
        min = (int)((PlayTime - hour * 3600) / 60);
        sec = (int)(PlayTime % 60);
    }

    public void DataReset()
    {
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("HP_Level", 0);
        PlayerPrefs.SetInt("Speed_Level", 0);
        PlayerPrefs.SetInt("Attack_Level", 0);
        PlayerPrefs.SetInt("BestScore", 0);
    }
}
