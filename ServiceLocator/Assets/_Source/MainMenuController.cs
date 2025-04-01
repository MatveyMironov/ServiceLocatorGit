using System;
public class MainMenuController : IUIState
{
    private readonly MainMenuView _menuView;

    public MainMenuController(MainMenuView menuView)
    {
        _menuView = menuView != null ? menuView : throw new ArgumentNullException(nameof(menuView));
    }

    public void Enter()
    {
        _menuView.gameObject.SetActive(true);
    }

    public void Exit()
    {
        _menuView.gameObject.SetActive(false);
    }
}
