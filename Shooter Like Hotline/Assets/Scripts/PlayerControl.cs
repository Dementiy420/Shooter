using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // приватные поля
    private Vector2 _input;
    private Rigidbody2D _rigidbody2D;
    
    // поля для инспектора
    [SerializeField] float speed = 5f; // скорость
    [SerializeField] private Transform bulletSpawn; // точка спавна пули
    [SerializeField] private LineRenderer lineRenderer;
    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MouseSpectate();
        Movement();
        
    }

    private void Movement() // передвижение персонажа
    {    
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //считывание ввода
        _rigidbody2D.linearVelocity = _input.normalized * speed;  // движение игрока через физику Rigidbody2D
    }

    private void MouseSpectate() // поворот персонажа в сторону курсора
    {
        // считывание курсоса и поворот игрока 
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
        bulletSpawn.rotation = transform.rotation;
        
        RaycastHit2D hit = Physics2D.Raycast(bulletSpawn.position, transform.up);
        Debug.DrawRay(bulletSpawn.position, bulletSpawn.up * 100f, Color.red);
        if (hit)
        {
            Debug.Log(hit.transform.name);
            lineRenderer.SetPosition(0, bulletSpawn.position);
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    private void Shooting(RaycastHit2D hitInfo) // реализация стрельбы
    {
        
    }
}
