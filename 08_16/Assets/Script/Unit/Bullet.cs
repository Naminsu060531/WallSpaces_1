using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Unit
{
    Vector3 startPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        startPos = Player.instance.firePos.position;
        Move();
    }

    void Move()
    {
        if(target == Target.enemy)
            transform.position += Vector3.forward * speed * Time.deltaTime;

        if (target == Target.player)
            transform.position += -Vector3.forward * speed * Time.deltaTime;
    }

    public void Init()
    {
        transform.position = startPos;
        gameObject.SetActive(true);
        Invoke("Unset", 5f);
    }

    void Unset()
    {
        gameObject.SetActive(false);
        transform.position = startPos;
    }
}
