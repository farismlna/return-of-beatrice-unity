using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftGuide : MonoBehaviour
{
    [SerializeField] private GameObject panelShift;
    private void Start()
    {
        panelShift.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelShift.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelShift.SetActive(false);
        }
    }
}
