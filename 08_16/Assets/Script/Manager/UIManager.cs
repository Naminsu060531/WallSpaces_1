using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text HP_UI, SPEED_UI, ATK_UI, HP_LEVEL_UI, SPD_LEVEL_UI, ATK_LEVEL_UI, SCORE_UI, GOLD_UI;
    public GameObject gameOverScreen;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerStatsSet();
    }

    public void getScore(int score)
    {
        int addscore = score + PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", addscore);
        playerStatsSet();
        Debug.Log("GS");
    }

    public void getGold(int gold)
    {
        int addgold = gold + PlayerPrefs.GetInt("hasGold");
        PlayerPrefs.SetInt("hasGold", addgold);
        playerStatsSet();
        Debug.Log("GG");
    }

    public void playerStatsSet()
    {
        HP_UI.text = "HP : " + Player.instance.hp;
        SPEED_UI.text = "Speed : " + Player.instance.speed;
        ATK_UI.text = "ATK : " + PlayerPrefs.GetInt("ATTACK_Lvl");
        HP_LEVEL_UI.text = "HP_Lvl : " + PlayerPrefs.GetInt("HP_Lvl");
        SPD_LEVEL_UI.text = "Speed_Lvl : " + PlayerPrefs.GetInt("SPEED_Lvl");
        ATK_LEVEL_UI.text = "Attack_Lvl : " + PlayerPrefs.GetInt("ATTACK_Lvl");
        GOLD_UI.text = "Gold : " + PlayerPrefs.GetInt("hasGold");
        SCORE_UI.text = "Score : " + PlayerPrefs.GetInt("Score");
    }

}
