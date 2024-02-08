using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject child;

    public void PlayGame()
    {
        animator.SetTrigger("start");
        StartCoroutine(LoadScene());
        child.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Game has quit!!");
        Application.Quit();
    }

    public void BossGame()
    {
        SceneManager.LoadScene("Boss");
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("CutScene1");
    }
}
