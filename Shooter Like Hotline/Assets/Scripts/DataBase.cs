using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] private CharactersDataBase DB;

    public CharactersDataBase GetDataBase
    {
        get { return DB; }
        private set { }
    }
}
