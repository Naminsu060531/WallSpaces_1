using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type { player, enemy, bullet}
    public Type type;

    public enum Target { player, enemy}
    public Target target;

    public int hp, dropGold, getScore;
    public float speed;

    public Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public IEnumerator OnDamage(int getDmg)
    {
        hp -= getDmg;
        yield return null;
    }

}
