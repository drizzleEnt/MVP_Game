using System;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    private PlayerModel _model;
    private IView _view;

    protected PlayerModel Model => _model;
    protected IView View => _view;

    

    public void Init(PlayerModel model, IView view)
    {
        _model = model;
        _view = view;
    }

    public void Init(PlayerModel model)
    {
        _model = model;
    }
}
