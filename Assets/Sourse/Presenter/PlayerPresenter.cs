using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : Presenter
{
    [SerializeField] private float _radius = 2f;
    [SerializeField] private LayerMask _ground;

    private bool _isGrounded;
    private InputRouter _inputRouter;

    public void Init(InputRouter router)
    {
        _inputRouter = router;
    }

    public void Enable()
    {
        _inputRouter.JumpEvent += OnJumpEvent;
        _inputRouter.MoveEvent += OnMoveEvent;
    }
    public void Disable()
    {
        _inputRouter.JumpEvent -= OnJumpEvent;
        _inputRouter.MoveEvent -= OnMoveEvent;
    }

    private void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Model.Init(rigidbody);
    }


    private void Update()
    {
        if (Model is IUpdatable)
            Model.Update(Time.deltaTime);

        Collider2D colliders = Physics2D.OverlapCircle(transform.position, _radius, _ground);
        if (colliders == null)
        {
            _isGrounded = false;
            return;
        }

        _isGrounded = true;
    }

    

    private void OnMoveEvent(float direction)
    {
        Model.SetMovingAbillity(1);
        Model.MoveSides(direction);
    }

    private void OnJumpEvent()
    {
        if (_isGrounded == false)
            return;

        Model.Jump();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
