using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static DataBase Instance { get; private set; }

    [SerializeField] private CharactersDataBase DB;

    private void Awake()
    {
        Instance = this;
    }


    public CharactersDataBase GetDataBase
    {
        get { return DB; }
        private set { }
    }
}