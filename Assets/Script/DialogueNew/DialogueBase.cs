using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue Setup/Dialogue")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public CharacterInformation characterInformation;

        //public string name;
        //public Sprite potrait;

        [TextArea(4, 8)]
        public string text;
    }

    [Header("Insert Dialogue Information")]
    public Info[] dialogueInfo;




}
