using System;
using UnityEngine;

[Serializable]
public class PlayerModel : IUpdatable
{
    private readonly float _force = 300f;
    private readonly float _speed = 3f;

    private Rigidbody2D _rigidbody;
    private Transform _playerTransform;
    private Vector2 _acceleration;

    public Vector2 Acceleration => _acceleration;

    public void Init(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
        _playerTransform = _rigidbody.GetComponent<Transform>();
    }
    
    public void Update(float deltaTime)
    {
        Move(deltaTime);
    }

    public void Accelarate(float direction, float deltaTime)
    {
        _acceleration.x = direction;
    }

    public void SlowDowm()
    {
        _acceleration.x = 0;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Force);
    }

    private void Move(float deltaTime)
    {
        _playerTransform.position = Vector2.MoveTowards(_playerTransform.position, (Vector2)_playerTransform.position + _acceleration, _speed * deltaTime);
    }

}
