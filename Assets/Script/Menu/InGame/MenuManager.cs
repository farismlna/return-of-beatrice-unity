using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void BackToOpening()
    {
        SceneManager.LoadScene("Opening");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameMain");
    }

    public void Close()
    {
        transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
    }
}
