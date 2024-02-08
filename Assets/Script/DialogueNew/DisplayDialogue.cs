using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDialogue : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI interactNpcName;
    [SerializeField] private GameObject buttonPanel;
    public DialogueBase dialogue;
    public GameObject player;
    public GameObject modelNPC;
    [SerializeField] public CharacterInformation chara;

    public Queue<DialogueBase.Info> dialogueInfo;

    ManageDialogue manage;
    float distance;

    private void Start()
    {
        buttonPanel.SetActive(false);
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    public void TriggerDialogue()
    {
        ManageDialogue.instance.EnqueueDialogue(dialogue, this);
        buttonPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<InteractButton>().chara = chara;

        interactNpcName.text = chara.interactNpcName;
        if (Input.GetKeyDown(KeyCode.E))
            TriggerDialogue();
    }

    private void OnTriggerStay(Collider other)
    {
        player.GetComponent<InteractButton>().chara = chara;

        interactNpcName.text = chara.interactNpcName;
        if (Input.GetKeyDown(KeyCode.E))
            TriggerDialogue();
    }

    // private void Update()
    // {
    //     distance = Vector3.Distance(player.transform.position, this.transform.position);
    //     if (distance <= 2)
    //     {
    //         player.GetComponent<InteractButton>().chara = chara;

    //         interactNpcName.text = chara.interactNpcName;
    //         if (Input.GetKeyDown(KeyCode.E))
    //             TriggerDialogue();
    //     }
    // }

    public void DisableGameObject()
    {
        modelNPC.SetActive(false);
    }
}
