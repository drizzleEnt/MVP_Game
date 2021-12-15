using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : Presenter
{
    [SerializeField] private float _radius = 2f;
    [SerializeField] private LayerMask _ground;

    private bool _isGrounded;
    private InputRouter _inputRouter;
    private Rigidbody2D _rigidbody;

    public void Init(InputRouter router)
    {
        _inputRouter = router;
    }

    public void Enable()
    {
        _inputRouter.JumpEvent += OnJumpEvent;
    }
    public void Disable()
    {
        _inputRouter.JumpEvent -= OnJumpEvent;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Model.Init(_rigidbody);
    }


    private void Update()
    {
        if (Model is IUpdatable)
            Model.Update(Time.deltaTime);

        _isGrounded = Physics2D.OverlapCircle(transform.position, _radius, _ground);
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
