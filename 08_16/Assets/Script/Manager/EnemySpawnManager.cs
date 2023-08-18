using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    ObjectPool<Enemy> EnemyPool;
    public Enemy enemy;
    public float shotDelay, shotDelayMax;
    bool isRight;

    private void Start()
    {
        EnemyPool = new ObjectPool<Enemy>(enemy.gameObject);
    }

    private void Update()
    {
        shotDelay += Time.deltaTime;
        if (shotDelay >= shotDelayMax)
        {
            Instantiate(enemy.gameObject, transform.position, transform.rotation);
            shotDelayMax = Random.Range(0, 4);
            shotDelay = 0;
        }

        LeftAndRight();
    }

    void LeftAndRight()
    {
        if (transform.position.x <= -15)
            isRight = true;
        if (transform.position.x >= 15)
            isRight = false;

        float dir = isRight ? 1 : -1;

        Vector3 nextPos = transform.position + new Vector3(dir * 5 * Time.deltaTime,0,0);
        transform.position = nextPos;
    }
}
