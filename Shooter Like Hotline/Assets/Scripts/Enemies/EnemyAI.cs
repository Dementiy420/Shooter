using UnityEngine;
using UnityEngine.AI;
using GeneralFunctions.Utils;

public class EnemyAI : MonoBehaviour
{
    #region Поля инспектора
    [SerializeField] private bool NavRotate;
    [SerializeField] private bool NavAxis;
    [SerializeField] private States defaultState;
    [SerializeField] private float maxDistance = 7f; // максимальная дистанция
    [SerializeField] private float minDistance = 3f; // минимальная дистанция
    [SerializeField] private float timer = 2f; // таймер за который должен пройти враг до точки

    #endregion

    #region Закрытые поля

    private NavMeshAgent _navMeshAgent;
    private States _state; // переменная для хранения состояния
    private float _roamingTime; // пройденное время
    private Vector3 _roamingPosition; // точка, на которую должен прийти враг
    private Vector3 _startingPosition; // начальная точка врага

    private enum States
    {
        Idle, // состояние покоя врага
        Roaming // состояния передвижения
    }
    #endregion

    #region Методы MonoBehaviour

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        //настройки NavMesh для 2D - плоскости
        _navMeshAgent.updateUpAxis = false;
        _navMeshAgent.updateRotation = false;

        _state = defaultState;
    }

    private void Start() {
        _startingPosition = transform.position; // считывание исходной позиции врага
    }

    private void Update()
    {
        switch (_state) 
        {
            default:
                case States.Idle:
                break;

                case States.Roaming: // при состоянии передвижения
                
                _roamingTime -= Time.deltaTime; // время передвижения уходит
                
                if (_roamingTime < 0) { // если враг не успел дойти, то он ищет новую точку
                    Roaming();
                    _roamingTime = timer; // обновление таймера
                }

                break;
        }
    }

    #endregion

    #region Вспомогательные методы

    private void Roaming() 
    {
        _roamingPosition = GetRoamingPosition(); 
        _navMeshAgent.SetDestination(_roamingPosition); // передвижение врага к текущей точке
    } 

    //получение новой точки для движения
    private Vector3 GetRoamingPosition() => _startingPosition + Utils.GetRandomDirection() * UnityEngine.Random.Range(minDistance,maxDistance);
    

    #endregion
}