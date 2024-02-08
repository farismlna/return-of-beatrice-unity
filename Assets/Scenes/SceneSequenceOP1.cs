using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequenceOP1 : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2; 
    public GameObject Cam3;
    public GameObject Cam4;
    public GameObject Cam5;
    public GameObject Cam6;
    public GameObject Cam7;
    public GameObject Cam8;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(4);
        Cam2.SetActive(true);
        Cam3.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);
        Cam8.SetActive(false);
        yield return new WaitForSeconds(4);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);
        Cam8.SetActive(false);
        yield return new WaitForSeconds(3);
        Cam4.SetActive(true);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam5.SetActive(false);
        Cam6.SetActive(false);
        Cam7.SetActive(false);
        Cam8.SetActive(false);
        yield return new WaitForSeconds(3);
        Cam5.SetActive(true);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam4.SetActive(false);
        Cam7.SetActive(false);
        Cam6.SetActive(false);
        Cam8.SetActive(false);
        yield return new WaitForSeconds(3);
        Cam6.SetActive(true);
        Cam5.SetActive(false);
        Cam4.SetActive(false);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam7.SetActive(false);
        Cam8.SetActive(false);
        yield return new WaitForSeconds(3);
        Cam7.SetActive(true);
        Cam6.SetActive(false);
        Cam5.SetActive(false);
        Cam4.SetActive(false);
        Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam8.SetActive(false);
        yield return new WaitForSeconds(3);
        Cam8.SetActive(true);
        Cam7.SetActive(false);
        Cam6.SetActive(false);
        Cam5.SetActive(false);
        Cam4.SetActive(false);
        Cam3.SetActive(false);
        Cam2.SetActive(false);

    }
}
