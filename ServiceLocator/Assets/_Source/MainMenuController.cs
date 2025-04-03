using System;
using Zenject;

public class MainMenuController : IUIState
{
    private readonly MainMenuView _menuView;

    private readonly ISoundPlayer _soundPlayer;
    private readonly IFadeService _fadeService;

    [Inject]
    public MainMenuController(MainMenuView menuView, ISoundPlayer soundPlayer, IFadeService fadeService)
    {
        _menuView = menuView != null ? menuView : throw new ArgumentNullException(nameof(menuView));

        _soundPlayer = soundPlayer ?? throw new ArgumentNullException(nameof(soundPlayer));
        _fadeService = fadeService ?? throw new ArgumentNullException(nameof(fadeService));
    }

    public event Action OnOpenButtonClicked;

    public void Enter()
    {
        _soundPlayer.PlayOpenSound();

        _menuView.SubscribeToButtonClick(OnOpenButtonClicked);
        _menuView.gameObject.SetActive(true);

        _fadeService.FadeIn(_menuView.PanelImage, 0.5f);
    }

    public void Exit()
    {
        _soundPlayer.PlayCloseSound();
        _fadeService.FadeOut(_menuView.PanelImage, 0.5f);

        _menuView.gameObject.SetActive(false);
        _menuView.UnsubscribeFromButtonClick(OnOpenButtonClicked);
    }
}
