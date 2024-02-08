using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMenu : MonoBehaviour
{
    public void BackToOpening()
    {
        SceneManager.LoadScene("Opening");
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("GameMain");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
