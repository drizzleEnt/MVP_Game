using System;
using UnityEngine;

[Serializable]
public class PlayerModel : IUpdatable
{
    [SerializeField] private float _force = 300f;
    [SerializeField] private float _speed = 3f;

    private Vector2 _offset = Vector2.right;
    private float _movingTime = 0;
    private Vector2 _moveDirection;
    private Vector2 _newPosition;
    private Rigidbody2D _rigidbody;
    private Transform _playerTransform;

    public void Init(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
        _playerTransform = _rigidbody.GetComponent<Transform>();
    }
    
    public void Update(float deltaTime)
    {
        if (_movingTime <= 0)
        {
            return;
        }

        _movingTime -= deltaTime;
        _playerTransform.Translate(_moveDirection * _speed * deltaTime);
    }

    public void MoveSides(float direction)
    {
        Vector2 currentPosition = _rigidbody.position;
        _newPosition = currentPosition + _offset * direction;
        _moveDirection = _newPosition - currentPosition;
        //_rigidbody.AddForce(moveDirection, ForceMode2D.Impulse);
        

    }

    public void SetMovingAbillity(float movingTime)
    {
        _movingTime = movingTime;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _force, ForceMode2D.Force);
    }

}
