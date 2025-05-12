using UnityEngine;
using UnityEngine.AI;
using GeneralFunctions.Utils;

public class EnemyAI : MonoBehaviour
{
    #region ���� ����������
    [SerializeField] private bool NavRotate;
    [SerializeField] private bool NavAxis;
    [SerializeField] private States defaultState;
    [SerializeField] private float maxDistance = 7f; // ������������ ���������
    [SerializeField] private float minDistance = 3f; // ����������� ���������
    [SerializeField] private float timer = 2f; // ������ �� ������� ������ ������ ���� �� �����

    #endregion

    #region �������� ����

    private NavMeshAgent _navMeshAgent;
    private States _state; // ���������� ��� �������� ���������
    private float _roamingTime; // ���������� �����
    private Vector3 _roamingPosition; // �����, �� ������� ������ ������ ����
    private Vector3 _startingPosition; // ��������� ����� �����

    private enum States
    {
        Idle, // ��������� ����� �����
        Roaming // ��������� ������������
    }
    #endregion

    #region ������ MonoBehaviour

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        //��������� NavMesh ��� 2D - ���������
        _navMeshAgent.updateUpAxis = false;
        _navMeshAgent.updateRotation = false;

        _state = defaultState;
    }

    private void Start() {
        _startingPosition = transform.position; // ���������� �������� ������� �����
    }

    private void Update()
    {
        switch (_state) 
        {
            default:
                case States.Idle:
                break;

                case States.Roaming: // ��� ��������� ������������
                
                _roamingTime -= Time.deltaTime; // ����� ������������ ������
                
                if (_roamingTime < 0) { // ���� ���� �� ����� �����, �� �� ���� ����� �����
                    Roaming();
                    _roamingTime = timer; // ���������� �������
                }

                break;
        }
    }

    #endregion

    #region ��������������� ������

    private void Roaming() 
    {
        _roamingPosition = GetRoamingPosition(); 
        _navMeshAgent.SetDestination(_roamingPosition); // ������������ ����� � ������� �����
    } 

    //��������� ����� ����� ��� ��������
    private Vector3 GetRoamingPosition() => _startingPosition + Utils.GetRandomDirection() * UnityEngine.Random.Range(minDistance,maxDistance);
    

    #endregion
}