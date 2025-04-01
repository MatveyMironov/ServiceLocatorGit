using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button secondaryMenuButton;
    [SerializeField] private Image panelImage;

    private readonly List<Action> _buttonClickActions = new();

    public Image PanelImage { get { return panelImage; } }

    private void Start()
    {
        secondaryMenuButton.onClick.AddListener(InvokeButtonClickActions);
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
        foreach (var action in _buttonClickActions.ToArray())
        {
            action?.Invoke();
        }
    }
}
