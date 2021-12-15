using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputRouter : IView
{
    private PlayerInput _playerInput;
    private PlayerModel _playerModel;

    public event UnityAction JumpEvent;
    public event UnityAction<float> MoveEvent;

    public InputRouter(PlayerModel model)
    {
        _playerInput = new PlayerInput();
        _playerModel = model;
    }

    public void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Jump.performed += OnJumpClick;
    }

    public void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Jump.performed -= OnJumpClick;
    }

    public void Update()
    {
        if (MovePerformed())
            _playerModel.Accelarate(GetInputDirection(), Time.deltaTime);
        else
            _playerModel.SlowDowm();
    }

    private float GetInputDirection()
    {
        return _playerInput.Player.Move.ReadValue<float>();
    }

    private bool MovePerformed()
    {
        return _playerInput.Player.Move.phase == InputActionPhase.Performed;
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
