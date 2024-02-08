using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    // Update is called once per frame
    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(4);
        Cam2.SetActive(true);   
        Cam1.SetActive(false);
        Cam4.SetActive(false);

        yield return new WaitForSeconds(4);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        Cam4.SetActive(false);

        yield return new WaitForSeconds(2);
        Cam4.SetActive(true);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
    }
}
