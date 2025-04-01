using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private SecondaryMenuView secondaryMenuView;

    [Space]
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        ServiceLocator serviceLocator = new ServiceLocator();

        IFadeService fadeService = new FadeService();
        serviceLocator.TryAddService(fadeService);

        ISoundPlayer soundPlayer = new SoundPlayer(audioSource);
        serviceLocator.TryAddService(soundPlayer);

        MainMenuController mainMenuController = new(mainMenuView, serviceLocator);
        SecondaryMenuController secondaryMenuController = new(secondaryMenuView);

        List<IUIState> uIStates = new() { mainMenuController, secondaryMenuController };

        UISwitcher uISwitcher = new(uIStates);

        mainMenuController.OnOpenButtonClicked += uISwitcher.ChangeState<SecondaryMenuController>;
        secondaryMenuController.OnCloseButtonClicked += uISwitcher.ChangeState<MainMenuController>;

        uISwitcher.ChangeState<MainMenuController>();
    }
}
