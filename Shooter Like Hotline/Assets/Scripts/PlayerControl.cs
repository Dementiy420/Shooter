using UnityEngine;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        // приватные поля
        private Vector2 _input; // Ввод игрока
        private Rigidbody2D _rigidbody2D; // физика

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
            MouseSpectate();
            Movement();
            Shooting();
        }

        private void Movement() // передвижение персонажа
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //считывание ввода
            _rigidbody2D.linearVelocity = _input.normalized * speed; // движение игрока через физику Rigidbody2D
        }

        private void MouseSpectate() // поворот персонажа в сторону курсора
        {
            // считывание курсоса и поворот игрока 
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);

            bulletSpawn.rotation = transform.rotation;
            Debug.DrawRay(bulletSpawn.position, bulletSpawn.up * 100f, Color.red);
        }

        private void Shooting() // реализация стрельбы
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            }
        }
    }

}