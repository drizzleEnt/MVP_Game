using System;
using UnityEngine;

[Serializable]
public class PlayerModel : IUpdatable
{
    [SerializeField] private float _force = 300f;
    [SerializeField] private Vector2 _offset = Vector2.right;

    private float _movingTime = 0;
    private Rigidbody2D _rigidbody;

    public void Init(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
    }
    
    public void Update(float deltaTime)
    {
        if (_movingTime <= 0)
        {

            return;
        }

        _movingTime -= deltaTime;
    }

    public void MoveSides(float direction)
    {
        Vector2 currentPosition = _rigidbody.position;
        Vector2 newPosition = currentPosition + _offset * direction;
        Vector2 moveDirection = newPosition - currentPosition;
        _rigidbody.AddForce(moveDirection, ForceMode2D.Impulse);
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
