using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOverValue;

    private void Awake()
    {
        instance = this;
    }

    public void CheckPlayer()
    {
        if (Player.instance.hp <= 0)
        {
            gameOverValue = true;
            Player.instance.hp = 0;
            StartCoroutine(GameOverCo());
        }
    }
    public IEnumerator GameOverCo()
    {
        UIManager.instance.gameOverScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        ScenesManager.instance.loadUpgrade();
    }
}
