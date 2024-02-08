using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private GameObject panelButton;
    [SerializeField] private GameObject bossField;
    [SerializeField] private TextMeshProUGUI interactNpcName;

    public CharacterInformation chara;

    private void Start()
    {
        bossField.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            panelButton.SetActive(true);
            interactNpcName.text = chara.interactNpcName;
        }
        if (other.gameObject.tag == "BossField")
        {
            bossField.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bossField.SetActive(false);
        panelButton.SetActive(false);
        chara = null;
    }
}
