using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public struct Line
{
    public Chara chara;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Chara speakerLeft;
    public Chara speakerRight;
    public Line[] lines;
    public Conversation nextConversation;
}
