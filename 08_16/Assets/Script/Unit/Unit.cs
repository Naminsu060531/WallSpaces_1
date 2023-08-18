using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type { player, enemy, bullet}
    public Type type;

    public enum Target { player, enemy}
    public Target target;

    public int hp, dmg,dropGold, getScore;
    public float speed;

    public Rigidbody rigid;

}
