using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawnManager : MonoBehaviour
{
    public static BossSpawnManager instance;

    public float bossSpawnTime;
    public Boss boss;
    public GameObject BossObj;
    public float BossHealth, BossMaxHealth;
    public Slider BossHP_UI;
    public int bossLevel = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        BossSet();
        BossBarSet();
    }

    public void BossSet()
    {
        bossSpawnTime += Time.deltaTime;

        if (BossObj.activeInHierarchy)
            bossSpawnTime = 0;

        if (bossSpawnTime >= 60)
        {
            BossObj = Instantiate(boss.gameObject, transform.position, transform.rotation);
            bossSpawnTime = 0;
        }
    }

    public void BossBarSet()
    {
        if(BossObj.activeInHierarchy)
        {
            BossHP_UI.gameObject.SetActive(true);
            BossHP_UI.maxValue = BossMaxHealth;
            BossHP_UI.value = BossHealth;
        }
    }

}
