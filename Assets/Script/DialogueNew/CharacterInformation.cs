using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Dialogue Setup/Character")]
public class CharacterInformation : ScriptableObject
{
    public string name;
    public Sprite portrait;
    public string interactNpcName;
}
