using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        BossSpawnManager.instance.BossMaxHealth = hp;
        BossSpawnManager.instance.BossHealth = BossSpawnManager.instance.BossMaxHealth;
    }
}
