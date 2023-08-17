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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player" || other.tag == "Bullet")
        {
            Vector3 reactVec = transform.position - other.gameObject.transform.position;
            StartCoroutine(OnReact(reactVec));
        }
    }

    public IEnumerator OnDamage(int getDmg)
    {
        hp -= getDmg;

        if (hp <= 0)
            gameObject.SetActive(false);

        yield return null;
    }

    public IEnumerator OnReact(Vector3 react)
    {
        yield return new WaitForSeconds(.05f);
        rigid.AddForce(react * 2, ForceMode.Impulse);
        StartCoroutine(OnDamage(dmg));
    }

}
