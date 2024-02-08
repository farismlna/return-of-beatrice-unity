using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterFigthtBoss : MonoBehaviour
{
    public GameObject panelWarn;

    private void Start()
    {
        panelWarn.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        panelWarn.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        panelWarn.SetActive(false);
    }
}
