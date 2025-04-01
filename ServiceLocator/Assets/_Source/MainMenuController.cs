using System;
public class MainMenuController : IUIState
{
    private readonly MainMenuView _menuView;

    private readonly IServiceLocator _serviceLocator;

    public MainMenuController(MainMenuView menuView, IServiceLocator serviceLocator)
    {
        _menuView = menuView != null ? menuView : throw new ArgumentNullException(nameof(menuView));
        _serviceLocator = serviceLocator ?? throw new ArgumentNullException(nameof(serviceLocator));
    }

    public event Action OnOpenButtonClicked;

    public void Enter()
    {
        _menuView.SubscribeToButtonClick(OnOpenButtonClicked);
        _menuView.gameObject.SetActive(true);

        if (_serviceLocator.TryGetService(out ISoundPlayer soundPlayer))
        {
            soundPlayer.PlayOpenSound();
        }
    }

    public void Exit()
    {
        if (_serviceLocator.TryGetService(out ISoundPlayer soundPlayer))
        {
            soundPlayer.PlayCloseSound();
        }

        _menuView.gameObject.SetActive(false);
        _menuView.UnsubscribeFromButtonClick(OnOpenButtonClicked);
    }

    private void InvokeOnOpenButtonClicked()
    {
        OnOpenButtonClicked?.Invoke();
    }
}
