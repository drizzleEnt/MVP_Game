using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputRouter : IView
{
    private PlayerInput _playerInput;

    public event UnityAction JumpEvent;
    public event UnityAction<float> MoveEvent;

    public InputRouter()
    {
        _playerInput = new PlayerInput();
    }

    public void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Jump.performed += OnJumpClick;
        _playerInput.Player.Move.performed += OnMoveClick;
    }

    public void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Jump.performed -= OnJumpClick;
        _playerInput.Player.Move.performed -= OnMoveClick;
    }

    private void OnMoveClick(InputAction.CallbackContext obj)
    {
        float inputValue = _playerInput.Player.Move.ReadValue<float>();
        MoveEvent?.Invoke(inputValue);
    }

    private void OnJumpClick(InputAction.CallbackContext obj)
    {
        JumpEvent?.Invoke();
    }
}
