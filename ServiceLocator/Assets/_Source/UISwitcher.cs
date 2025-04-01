using System;
using System.Collections.Generic;

public class UISwitcher
{
    private readonly Dictionary<Type, IUIState> _uIStates;

    private IUIState _currentState;

    public UISwitcher(List<IUIState> uIStates)
    {
        foreach (var uIState in uIStates)
        {
            _uIStates.TryAdd(typeof(IUIState), uIState);
        }
    }

    public void ChangeState<T>() where T : IUIState
    {
        if (_uIStates.TryGetValue(typeof(T), out IUIState uIState))
        {
            SetState(uIState);
        }
    }

    private void SetState(IUIState uIState)
    {
        _currentState?.Exit();
        _currentState = uIState;
        _currentState.Enter();
    }
}
