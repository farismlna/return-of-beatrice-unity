using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Chara")]
public class Chara : ScriptableObject
{
    public string fullName;
    public Sprite portrait;
    public string interactNpcName;
}

