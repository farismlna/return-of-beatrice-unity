using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterWinDialogue : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI interactNpcName;
    [SerializeField] private GameObject buttonPanel;
    public DialogueBase dialogue;
    public GameObject player;
    [SerializeField] public CharacterInformation chara;

    public Queue<DialogueBase.Info> dialogueInfo;

    float distance;

    private void Start()
    {
        buttonPanel.SetActive(false);
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    public void TriggerDialogue()
    {
        ManageDialogue2.instance.EnqueueDialogue(dialogue);
        buttonPanel.SetActive(false);
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2)
        {
            player.GetComponent<InteractButton>().chara = chara;

            interactNpcName.text = chara.interactNpcName;
            if (Input.GetKeyDown(KeyCode.E))
                TriggerDialogue();
        }
    }
}
