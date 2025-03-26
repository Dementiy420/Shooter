using UnityEngine;

[CreateAssetMenu (menuName = "Characters/Default", fileName = "New Character")]
public class CharacterData : ScriptableObject
{
    [Tooltip ("Character Sprite")]
    [SerializeField] private Sprite sprite;
    public Sprite Sprite
    {
        get { return sprite; }
        protected set { }
    }

    [Tooltip("Character Name")] 
    [SerializeField] private string naming;
    public string Name
    {
        get { return naming; }
        protected set { }
    }

    [Tooltip("Character Speed")]
    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        protected set { }
    }

    [Tooltip("Character Health")] 
    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        protected set { }
    }
    

}
