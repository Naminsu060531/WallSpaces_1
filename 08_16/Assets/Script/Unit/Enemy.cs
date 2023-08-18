using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public enum Rank { Normal, Rare, Epic, Boss}
    public Rank rank;
    public float attackDelay, attackDelayMax;
    public bool isSee = false, isUP, isForce;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        setEnemyType();
    }

    private void Update()
    {
        if(rank != Rank.Boss)
        {
            attackDelay += Time.deltaTime;
            if(attackDelay >= attackDelayMax)
            {
                StartCoroutine(AttackCo());
            }

            UpAndDown();
        }

    }
    void UpAndDown()
    {
        if(rank != Rank.Boss)
        {
            if (transform.position.z <= -9f)
                isUP = true;
            if (transform.position.z >= 9f)
                isUP = false;

            float dir = isUP ? 1 : -1;

            Vector3 nextPos = transform.position + new Vector3(0, 0, dir * speed * Time.deltaTime);
            transform.position = nextPos;
        }
    }
    public void setEnemyType()
    {
        if(rank == Rank.Boss)
        {
            return;
        }

        int ranValue = Random.Range(0, 3);
        
        switch(ranValue)
        {
            case 0:
                rank = Rank.Normal;
                break;
            case 1:
                rank = Rank.Rare;
                break;
            case 2:
                rank = Rank.Epic;
                break;
        }

        setEnemyStats();
    }

    public void setEnemyStats()
    {
        if(rank == Rank.Normal)
        {
            hp = 2;
            speed = 5;
            dmg = 1;
            dropGold = 5;
            getScore = 5;
            attackDelayMax = 1f;
        }

        if (rank == Rank.Rare)
        {
            hp = 4;
            speed = 8;
            dmg = 2;
            dropGold = 25;
            getScore = 25;
            attackDelayMax = 1.25f;
        }

        if (rank == Rank.Epic)
        {
            hp = 5;
            speed = 12;
            dmg = 3;
            dropGold = 25;
            getScore = 50;
            attackDelayMax = 1.75f;
        }

        if (rank == Rank.Boss)
        {
            int a = BossSpawnManager.instance.bossLevel;

            hp = 100 * a;
            speed = 12 + a;
            dmg = 5;
            dropGold = 500 * a;
            getScore = 500 * a;
            attackDelayMax = 3f;
        }
    }

    public void targeting()
    {
        if(isSee)
        {
            transform.LookAt(Player.instance.gameObject.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(isForce)
            {
                Vector3 react = transform.position - other.transform.position;
                StartCoroutine(OnReact(react));

                StartCoroutine(OnDamage(2));
            }
        }

        if(other.tag == "Bullet")
        {
            Vector3 react = transform.position - other.transform.position;
            StartCoroutine(OnReact(react));

            Bullet bullet = other.GetComponent<Bullet>();

            if(bullet.target == Target.enemy)
            {
                StartCoroutine(OnDamage(bullet.dmg));
            }
        }

        if(other.tag == "Wall" && isForce && rank != Rank.Boss)
        {
            Vector3 react = transform.position - other.transform.position;
            StartCoroutine(OnReact(react));

            StartCoroutine(OnDamage(3));
        }

        if (other.tag == "Force")
        {
            Vector3 react = transform.position - other.transform.position;
            StartCoroutine(OnReact(react));

            StartCoroutine(forceCo());
        }

        if (other.tag == "DeadLine")
            gameObject.SetActive(false);
    }

    public IEnumerator OnDamage(int dmg)
    {
        if(rank == Rank.Boss)
        {
            BossSpawnManager.instance.BossHealth = hp;
        }

        hp -= dmg;

        if(hp <= 0)
        {
            /*DataManager.instance.addGold(dropGold);
            DataManager.instance.addScore(getScore);*/

            if (rank == Rank.Boss)
            {
                BossSpawnManager.instance.BossHP_UI.gameObject.SetActive(false);
                BossSpawnManager.instance.bossLevel++;
            }

            gameObject.SetActive(false);    
        }

        UIManager.instance.setText();

        yield return null;
    }

    public IEnumerator OnReact(Vector3 react)
    {
        rigid.AddForce(react * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(.5f);
    }

    public IEnumerator AttackCo()
    {
        switch(rank)
        {
            case Rank.Normal:

            case Rank.Rare:

                break;
            case Rank.Epic:

                break;
        }

        attackDelay = 0;
        yield return null;
    }

    public IEnumerator forceCo()
    {
        isForce = true;
        yield return new WaitForSeconds(3f);
        isForce = false;
    }

    
}
