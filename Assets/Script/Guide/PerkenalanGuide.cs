using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkenalanGuide : MonoBehaviour
{
    [SerializeField] private GameObject panelAwalan;

    private void Start()
    {
        panelAwalan.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelAwalan.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelAwalan.SetActive(false);
        }
    }
}
