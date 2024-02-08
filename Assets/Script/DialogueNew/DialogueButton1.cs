using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton1 : MonoBehaviour
{
    public void GetNextLine()
    {
        ManageDialogue2.instance.DequeueDialogue();
    }
}
