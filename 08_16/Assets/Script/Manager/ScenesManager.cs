using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void loadUpgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }

    public void loadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
