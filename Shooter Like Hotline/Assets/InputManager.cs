using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private static CharacterController _characterController;

    private void Awake()
    {
        Instance = this;
        _characterController = new CharacterController();
        _characterController.Enable();
    }

    public Vector2 GetVectorMovement() =>
        _characterController.Player.Movement.ReadValue<Vector2>();

    public static void DisableInput(bool isEnabled) 
    {
        if (isEnabled) 
            _characterController.Disable();
        else
            _characterController.Enable();
    } 
}