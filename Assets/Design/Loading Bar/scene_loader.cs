using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_loader : MonoBehaviour
{
    public Image loadngfill;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading());     
    }

    IEnumerator Loading()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("GameMain");
        
        while (!loading.isDone)
        {
            loadngfill.fillAmount = loading.progress/0.9f;

            yield return null;
        }
    }
}
