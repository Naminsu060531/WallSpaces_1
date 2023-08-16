using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            OnDamage(1);
        }
    }
}
