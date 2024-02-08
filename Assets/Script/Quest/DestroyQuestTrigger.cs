using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyQuestTrigger : MonoBehaviour
{
    [SerializeField] private GameObject guidePanel;
    public GameObject questTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            questTrigger.GetComponent<QuestTrigger>().DestroyTrigger();
            guidePanel.SetActive(false);
            Debug.Log("player has lewat");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
}
