using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageDialogue : MonoBehaviour
{
    public static ManageDialogue instance;
    public DisplayDialogue displayDialogue;

    public bool endDialogue = false;

    private void Awake()
    {
        if (instance != null)
            Debug.LogWarning("fix this" + gameObject.name);
        else
            instance = this;
    }

    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;

    public float delay = 0.1f;

    public Queue<DialogueBase.Info> dialogueInfo;

    private bool isCurrentlyTyping;
    private string completeText;

    private void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    public void EnqueueDialogue(DialogueBase db, DisplayDialogue characterDialgoue)
    {
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        displayDialogue = characterDialgoue;

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndDialogue();
            displayDialogue.DisableGameObject();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.text;

        //dialogueName.text = info.name;
        dialogueName.text = info.characterInformation.name;
        dialogueText.text = info.text;
        //dialoguePortrait.sprite = info.potrait;
        dialoguePortrait.sprite = info.characterInformation.portrait;

        dialogueText.text = "";
        StartCoroutine(TypeWrite(info));
    }

    IEnumerator TypeWrite(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        foreach (char c in info.text.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
        }

        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        endDialogue = true;
    }
}