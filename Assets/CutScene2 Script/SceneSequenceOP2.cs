using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSequenceOP2 : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;
    public GameObject Cam5;
    public GameObject Cam6;
    public GameObject Cam7;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    // Update is called once per frame
    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(2);
        Cam1.SetActive(true);
        Cam2.SetActive(false); 
        Cam3.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);

        yield return new WaitForSeconds(2);
        Cam2.SetActive(true);   
        Cam1.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);

        yield return new WaitForSeconds(3);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);

        yield return new WaitForSeconds(2);
        Cam4.SetActive(true);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);

        yield return new WaitForSeconds(2);
        Cam5.SetActive(true);
        Cam6.SetActive(false);
        Cam4.SetActive(false);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam7.SetActive(false);

        yield return new WaitForSeconds(3);
        Cam6.SetActive(true);
        Cam5.SetActive(false);
        Cam4.SetActive(false);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam7.SetActive(false);

        yield return new WaitForSeconds(3);
        Cam7.SetActive(true);
        Cam6.SetActive(false);
        Cam5.SetActive(false);
        Cam4.SetActive(false);
        Cam3.SetActive(false);
        Cam2.SetActive(false);

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TestingLoad");
    }
}
