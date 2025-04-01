using System;

public class SecondaryMenuController : IUIState
{
    private readonly SecondaryMenuView _menuView;

    private readonly IServiceLocator _serviceLocator;

    public SecondaryMenuController(SecondaryMenuView menuView, IServiceLocator serviceLocator)
    {
        _menuView = menuView != null ? menuView : throw new ArgumentNullException(nameof(menuView));

        _serviceLocator = serviceLocator ?? throw new ArgumentNullException(nameof(serviceLocator));
    }

    public event Action OnCloseButtonClicked;

    public void Enter()
    {
        if (_serviceLocator.TryGetService(out ISoundPlayer soundPlayer))
        {
            soundPlayer.PlayOpenSound();
        }

        _menuView.SubscribeToButtonClick(OnCloseButtonClicked);
        _menuView.gameObject.SetActive(true);

        if (_serviceLocator.TryGetService(out IFadeService fadeService))
        {
            fadeService.FadeIn(_menuView.PanelImage, 0.5f);
        }
    }

    public void Exit()
    {
        if (_serviceLocator.TryGetService(out ISoundPlayer soundPlayer))
        {
            soundPlayer.PlayCloseSound();
        }

        if (_serviceLocator.TryGetService(out IFadeService fadeService))
        {
            fadeService.FadeOut(_menuView.PanelImage, 0.5f);
        }

        _menuView.gameObject.SetActive(false);
        _menuView.UnsubscribeFromButtonClick(OnCloseButtonClicked);
    }
}
