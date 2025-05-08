using UnityEngine;

[CreateAssetMenu (menuName = "Characters/DataBase", fileName = "New DataBase")]
public class CharactersDataBase : ScriptableObject
{
    [Tooltip("Characters")]
    public CharacterData[] characters;

    public CharacterData GetCharacter(int index)
    {
        return characters[index];
    }
}