using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(CapsuleCollider2D))] // установление обязательных требований для объекта
    public class PlayerControl : MonoBehaviour
    {
        public static PlayerControl Instance { get; private set; }

        // приватные поля
        private Rigidbody2D _rigidbody2D; // физика
        private CharacterData _data; // данные для игрока 
        private bool _isMove = false; // флаг для установки 

        // поля для инспектора
        [SerializeField] private Transform bulletSpawn; // точка спавна пули
        [SerializeField] private GameObject bulletPrefab; // префаб пули

        private void Awake() // инициализируем данные для персонажа
        {
            Instance = this;

            int? checkPrefs = PlayerPrefs.GetInt("Character");

            if (checkPrefs == null)
                Debug.Log("Данные о выбранном персонаже отсутствуют");

            try {
                _data = DataBase.Instance.GetDataBase.GetCharacter(PlayerPrefs.GetInt("Character")); //считываем по ключу Character переменную, что выбрал игрок для персонажа
            }
            catch (Exception e) {
                Debug.Log(e);
                PlayerPrefs.SetInt("Character", 0);
                _data = DataBase.Instance.GetDataBase.GetCharacter(PlayerPrefs.GetInt("Character"));
            }

            _rigidbody2D = GetComponent<Rigidbody2D>(); // получаем доступ к физике объекта
        }      

        private void Update() // логика управления
        {
            if (Input.GetKeyDown(KeyCode.P))
                InputManager.DisableInput(true);

            if (Input.GetKeyDown(KeyCode.O))
                InputManager.DisableInput(false);
        }

        private void FixedUpdate() // обновление кадров с точным расчетом физики
        {
            Movement();
        }

        private void Movement() 
        {
            Vector2 inputPlayer = InputManager.Instance.GetVectorMovement();
            inputPlayer = inputPlayer.normalized;
            Debug.Log(inputPlayer);
            _rigidbody2D.MovePosition(_rigidbody2D.position + inputPlayer * (_data.Speed * Time.fixedDeltaTime));

            if (Math.Abs(inputPlayer.x) > 0.1 || Math.Abs(inputPlayer.y) > 0.1)
                _isMove = true;
            else
                _isMove = false;
        }

        public bool GetFlagMove() => _isMove;
    }
}