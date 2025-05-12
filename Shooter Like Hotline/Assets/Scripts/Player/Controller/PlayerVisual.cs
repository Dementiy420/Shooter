using Player;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string WALKING_FLAG = "IsWalking";

    private Animator _animator;
    private void Awake()
    {
        var data = DataBase.Instance.GetDataBase.GetCharacter(PlayerPrefs.GetInt("Character"));
        _animator = GetComponent<Animator>();
        _animator.runtimeAnimatorController = data.Anim;
    }

    private void Update()
    {
        _animator.SetBool(WALKING_FLAG, PlayerControl.Instance.GetFlagMove());
    }
}