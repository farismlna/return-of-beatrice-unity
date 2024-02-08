using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGuide : MonoBehaviour
{
    [SerializeField] private GameObject panelAttack;

    private void Start()
    {
        panelAttack.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelAttack.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelAttack.SetActive(false);
        }
    }
}
