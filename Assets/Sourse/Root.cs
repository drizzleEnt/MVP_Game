using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _presenter;

    private PlayerModel _playerModel;
    private InputRouter _router;

    private void Awake()
    {
        _playerModel = new PlayerModel();
        _router = new InputRouter(_playerModel);
        
        _presenter.Init(_playerModel);
        _presenter.Init(_router);
    }

    private void OnEnable()
    {
        _router.OnEnable();
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _router.OnDisable();
        _presenter.Disable();
    }

    private void Update()
    {
        _router.Update();
    }
}
