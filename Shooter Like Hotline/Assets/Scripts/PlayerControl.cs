using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 _input;
    [SerializeField] float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform bulletSpawn;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Cursor.visible = false;
        MouseSpectate();
        Movement();
        
    }

    private void Movement()
    {    
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody2D.linearVelocity = _input.normalized * speed;
    }

    private void MouseSpectate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(bulletSpawn.position, mousePos * 10f, Color.red);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
    }
}
