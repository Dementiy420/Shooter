using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public class PlayerControl : MonoBehaviour
    {
        // приватные поля
        private Vector2 _input; // Ввод игрока
        private Rigidbody2D _rigidbody2D; // физика
        private SpriteRenderer _spriteRenderer;
        private float _x, _y;
        private CharacterData data;
        
        // поля для инспектора
        [SerializeField] private Transform bulletSpawn; // точка спавна пули
        [SerializeField] private GameObject bulletPrefab; // префаб пули
        [SerializeField] private Camera cam;
        [SerializeField] private CharactersDataBase DB;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            int i = PlayerPrefs.GetInt("Character");
            Debug.Log(i);
            data = DB.GetCharacter(i);
        }

        private void Start() // инициализация объектов
        {
            _spriteRenderer.sprite = data.Sprite;
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

        private void Movement() => 
            _rigidbody2D.linearVelocity = 
                new Vector2(_input.x * data.Speed, _input.y * data.Speed);
        
        private void MouseSpectate() // поворот персонажа в сторону курсора
        {
            // считывание курсоса и поворот игрока 
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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