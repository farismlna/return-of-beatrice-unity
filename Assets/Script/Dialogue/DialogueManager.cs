using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject buttonPanel;
    [SerializeField] public NPC npc;

    [SerializeField] public GameObject player;
    [SerializeField] public GameObject dialogueNpcUI;

    [SerializeField] public TextMeshProUGUI interactNpcName;
    [SerializeField] public Text npcName;
    [SerializeField] public Text npcDialogueBox;
    [SerializeField] public Image npcImage;
    [SerializeField] public Text playerResponse;

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueNpcUI.SetActive(false);
        buttonPanel.SetActive(false);
    }
    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2f)
        {
            //player.GetComponent<InteractButton>().chara = chara;
            interactNpcName.text = npc.interactNpcName;
            if (Input.GetMouseButtonDown(0))
            {
                curResponseTracker++;
                if (curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if (curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }

            //trigger dialogue
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
                HideButtonInteract();
            }
            else if (Input.GetKeyDown(KeyCode.E) & isTalking == true)
            {
                EndDialogue();
                ShowButtonInteract();
            }

            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                }
            }
            else if (curResponseTracker == 3 && npc.playerDialogue.Length >= 3)
            {
                playerResponse.text = npc.playerDialogue[3];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[4];
                }
            }
            else if (curResponseTracker == 4 && npc.playerDialogue.Length >= 4)
            {
                playerResponse.text = npc.playerDialogue[4];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[5];
                }
            }
            else if (curResponseTracker == 5 && npc.playerDialogue.Length >= 5)
            {
                playerResponse.text = npc.playerDialogue[5];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[6];
                }
            }
            else if (curResponseTracker == 6 && npc.playerDialogue.Length >= 6)
            {
                playerResponse.text = npc.playerDialogue[6];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[7];
                }
            }
            else if (curResponseTracker == 7 && npc.playerDialogue.Length >= 7)
            {
                playerResponse.text = npc.playerDialogue[7];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[8];
                }
            }
            else if (curResponseTracker == 8 && npc.playerDialogue.Length >= 8)
            {
                playerResponse.text = npc.playerDialogue[8];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[9];
                }
            }
            else if (curResponseTracker == 9 && npc.playerDialogue.Length >= 9)
            {
                playerResponse.text = npc.playerDialogue[9];
                if (Input.GetMouseButtonDown(0))
                {
                    npcDialogueBox.text = npc.dialogue[10];
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueNpcUI.SetActive(true);
        npcName.text = npc.name;
        npcImage.sprite = npc.npcImage;
        npcDialogueBox.text = npc.dialogue[0];

        //player.GetComponent<PlayerInput>().enabled = false;
        //player.GetComponent<Animator>().enabled = false;
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueNpcUI.SetActive(false);

        //player.GetComponent<PlayerInput>().enabled = true;
        //player.GetComponent<Animator>().enabled = true;
        TeleportToBase();
    }

    void HideButtonInteract()
    {

        Debug.Log("Dialog NPC : " + dialogueNpcUI.activeSelf + " Is Talking : " + isTalking);
        if (dialogueNpcUI.activeSelf == true && isTalking == true)
        {
            buttonPanel.SetActive(false);
        }
    }

    void ShowButtonInteract()
    {
        if (dialogueNpcUI.activeSelf == false && isTalking == false)
        {
            buttonPanel.SetActive(true);
        }
    }

    void TeleportToBase()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(8f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }

}
