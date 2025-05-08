using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies", fileName = "New Enemy")]
public class Enemies : ScriptableObject
{
    [Tooltip("Enemy Sprite")]
    [SerializeField] private Sprite sprite;
    public Sprite Sprite
    {
        get { return sprite; }
        private set { }
    }

    [Tooltip("Enemy Speed")]
    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        private set { }
    }

    [Tooltip("Enemy Bullet")]
    [SerializeField] private GameObject? bullet;
    public GameObject Bullet
    {
        get { return bullet; }
        private set { }
    }

    [Tooltip("Enemy Damage")]
    [SerializeField] private int damage;
    public int Damage
    {
        get { return damage; }
        private set { }
    }

    [Tooltip("Enemy Health")]
    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        private set { }
    }

    [Tooltip("Enemy Animation")]
    [SerializeField] private AnimatorController animation;
    public AnimatorController Animation 
    {
        get { return animation; }
        private set {}
    }
}