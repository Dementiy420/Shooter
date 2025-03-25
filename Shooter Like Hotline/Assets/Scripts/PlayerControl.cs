using UnityEngine;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        // приватные поля
        private Vector2 _input; // Ввод игрока
        private Rigidbody2D _rigidbody2D; // физика
        private float _x, _y;

        // поля для инспектора
        [SerializeField] float speed = 5f; // скорость
        [SerializeField] public Transform bulletSpawn; // точка спавна пули
        [SerializeField] private GameObject bulletPrefab; // префаб пули


        private void Start() // инициализация объектов
        {
            _rigidbody2D = GetComponent<Rigidbody2D>(); // инициализация физики
        }

        private void Update() // логика управления
        {
            InputPlayer();
            MouseSpectate();
            Shooting();
        }
        

        private void FixedUpdate()
        {
            Movement();
        }

        private void InputPlayer()
        {
            _x = Input.GetAxisRaw("Horizontal");
            _y = Input.GetAxisRaw("Vertical");
            
            _input = new Vector2(_x, _y).normalized;
        }

        private void Movement() => _rigidbody2D.linearVelocity = new Vector2(_input.x * speed, _input.y * speed);
        

        private void MouseSpectate() // поворот персонажа в сторону курсора
        {
            // считывание курсоса и поворот игрока 
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
            Debug.DrawRay(bulletSpawn.position, bulletSpawn.up * 100f, Color.red);
            
            bulletSpawn.rotation = transform.rotation;
        }

        private void Shooting() // реализация стрельбы
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}