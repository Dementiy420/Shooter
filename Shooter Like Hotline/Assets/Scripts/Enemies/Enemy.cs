using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D), typeof (BoxCollider2D), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemies data;

    private SpriteRenderer spriteRenderer;
    private AnimatorController animatorController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<AnimatorController>();
    }

    void Start()
    {
        spriteRenderer.sprite = data.Sprite;
        animatorController = data.Animation;
    }

    void Update()
    {
        transform.Translate(data.Speed,0,0);

    }
}
