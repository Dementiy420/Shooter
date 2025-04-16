using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(CircleCollider2D))] // установление обязательных требований для объекта
    public class PlayerControl : MonoBehaviour
    {
        // приватные поля
        private Vector2 _input; // 
        private Rigidbody2D _rigidbody2D; // физика
        private SpriteRenderer _spriteRenderer; // рендер спрайта
        private float _x, _y; // Ввод игрока
        private CharacterData data; // данные для игрока
        
        // поля для инспектора
        [SerializeField] private Transform bulletSpawn; // точка спавна пули
        [SerializeField] private GameObject bulletPrefab; // префаб пули
        [SerializeField] private Camera cam; // камера
        [SerializeField] private DataBase dataBase; // база данных
        /*
         * насчет строчки 20, это какой - то ультракостыль,
         * который используется один раз за весь скрипт,
         * поэтому вроде как некритично...
         * но по крайней мере нет повторения кода для игрока
         * и игрового менеджера
         */

        private void Awake() // инициализируем данные для персонажа
        {
            data = dataBase.GetDataBase.GetCharacter(PlayerPrefs.GetInt("Character")); //считываем по ключу Character переменную, что выбрал игрок для персонажа
            _rigidbody2D = GetComponent<Rigidbody2D>(); // получаем доступ к физике объекта
            _spriteRenderer = GetComponent<SpriteRenderer>(); // получаем доступ к спрайту объекта
        }
        
        private void Start() // инициализация объектов
        {
            _spriteRenderer.sprite = data.Sprite; // задаем спрайт объекту из ScriptableObject
        }

        private void Update() // логика управления
        {
            InputPlayer(); //считывание ввода с клавиатуры
            MouseSpectate(); // слежение объекта за курсором
            Shooting(); // реализация стрельбы на пробел
        }
        

        private void FixedUpdate() // обновление кадров с точным расчетом физики
        {
            Movement(); // собственно метод для придания движения игроку 
        }

        private void InputPlayer() 
        {
            _x = Input.GetAxisRaw("Horizontal"); // в переменную заносится ввод в горизонталной оси (стрелки вправо влево, A и D)
            _y = Input.GetAxisRaw("Vertical"); // в переменную заносится ввод в вертикальной оси (стрелки вверх вниз, W и S)
            
            _input = new Vector2(_x, _y).normalized; // в переменную передается новый вектор движения с параметром normalized, чтобы избежать умножения векторов по диагонали
        }

        private void Movement() => 
            _rigidbody2D.linearVelocity = 
                new Vector2(_input.x * data.Speed, _input.y * data.Speed); // через физику и свойство linearVelocity задаем саму скорость объекту
        
        private void MouseSpectate() // поворот персонажа в сторону курсора
        {
            // считывание курсоса и поворот игрока 
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
            transform.right = mousePos - new Vector2(transform.position.x, transform.position.y);
            Debug.DrawRay(bulletSpawn.position, bulletSpawn.up * 100f, Color.red); // на сцене создается луч, который указывает поворот игрока
            
        }

        private void Shooting() // реализация стрельбы
        {
            if (Input.GetKeyDown(KeyCode.Space)) // считывание пробела для стрельбы
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}