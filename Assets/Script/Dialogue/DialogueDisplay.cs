using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    public Conversation conversation;
    public Conversation defaultConversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    [SerializeField] public GameObject player;

    [SerializeField] public TextMeshProUGUI interactNpcName;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] public Chara charaName;

    private int activeLineIndex = 0;
    private bool conversationStarted = false;

    bool isTalking = false;
    float distance;

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    // Start is called before the first frame update
    void Start()
    {
        speakerLeft.SetActive(false);
        speakerRight.SetActive(false);

        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

        buttonPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= 2)
        {
            //player.GetComponent<InteractButton>(). = ;
            interactNpcName.text = charaName.interactNpcName;

            if (Input.GetMouseButtonDown(0))
            {
                AdvanceLine();
            }
            else if (Input.GetKeyDown("x"))
            {
                EndConversation();
            }


        }
    }

    void StartConversation()
    {
        isTalking = true;
        AdvanceConversation();
        buttonPanel.SetActive(false);
        //player.GetComponent<PlayerInput>().enabled = false;
    }

    private void EndConversation()
    {
        conversation = defaultConversation;
        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
        buttonPanel.SetActive(true);
        Debug.Log("End Conversation");
    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }

    private void AdvanceLine()
    {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
            DisplayLine();
        else
            AdvanceConversation();
    }

    void AdvanceConversation()
    {
        if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else
            EndConversation();
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Chara chara = line.chara;

        if (speakerUILeft.SpeakerIs(chara))
        {
            SetDialogue(speakerUILeft, speakerUIRight, line);
        }
        else
        {
            SetDialogue(speakerUIRight, speakerUILeft, line);
        }

        activeLineIndex += 1;
    }

    void SetDialogue(
        SpeakerUI activeSpeakerUI,
        SpeakerUI inactiveSpeakerUI,
        Line line
    )
    {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialogue = "";

        StopAllCoroutines();
        StartCoroutine(EffectTypewritter(line.text, activeSpeakerUI));
    }

    IEnumerator EffectTypewritter(string text, SpeakerUI controller)
    {
        foreach (char character in text.ToCharArray())
        {
            controller.Dialogue += character;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
