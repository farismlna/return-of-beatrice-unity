using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    public Color activeColor;
    public Color currentColor;

    public QuestArrow arrow;
    public Quest[] allQuest;


    private void Start()
    {
        allQuest = FindObjectsOfType<Quest>();
        currentColor = questItem.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (Collision.tag == "Player")
        // {
        //     FinishQuest();
        //     Destroy(gameObject);
        // }
    }

    void FinishQuest()
    {
        questItem.GetComponent<Button>().interactable = false;
        currentColor = completedColor;
        questItem.color = completedColor;
        arrow.gameObject.SetActive(false);
    }

    public void OnClickQuest()
    {
        arrow.gameObject.SetActive(true);
        arrow.target = this.transform;
        foreach (Quest quest in allQuest)
        {
            quest.questItem.color = quest.currentColor;
        }
        questItem.color = activeColor;
    }
}
