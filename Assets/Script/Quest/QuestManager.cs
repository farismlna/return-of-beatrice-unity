using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject endGameWarn;

    public TMP_Text leftVilalger;
    bool savedAllVillager = false;
    public int sisaVillager;

    // Update is called once per frame

    private void Start()
    {
        endGameWarn.SetActive(false);
    }

    void EndGame()
    {
        savedAllVillager = true;
    }

    private void OnTriggerStay(Collider other)
    {
        sisaVillager = GameObject.FindGameObjectsWithTag("NPC").Length;
        leftVilalger.SetText(sisaVillager.ToString());

        if (sisaVillager == 0)
        {
            endGameWarn.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            sisaVillager--;
            leftVilalger.SetText(sisaVillager.ToString());
        }
    }
}
