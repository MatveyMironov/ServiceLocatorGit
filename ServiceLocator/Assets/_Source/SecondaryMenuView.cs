using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryMenuView : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    private readonly List<Action> _buttonClickActions = new();

    private void Start()
    {
        closeButton.onClick.AddListener(InvokeButtonClickActions);
    }

    public void SubscribeToButtonClick(Action action)
    {
        _buttonClickActions.Add(action);
    }

    public void UnsubscribeFromButtonClick(Action action)
    {
        _buttonClickActions.Remove(action);
    }

    private void InvokeButtonClickActions()
    {
        foreach (var action in _buttonClickActions)
        {
            action?.Invoke();
        }
    }
}
