using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private SecondaryMenuView secondaryMenuView;

    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private void Start()
    {
        ServiceLocator serviceLocator = new ServiceLocator();

        IFadeService fadeService = new FadeService();
        serviceLocator.TryAddService(fadeService);

        ISoundPlayer soundPlayer = new SoundPlayer(audioSource, openSound, closeSound);
        serviceLocator.TryAddService(soundPlayer);

        MainMenuController mainMenuController = new(mainMenuView, serviceLocator);
        SecondaryMenuController secondaryMenuController = new(secondaryMenuView, serviceLocator);

        List<IUIState> uIStates = new() { mainMenuController, secondaryMenuController };

        UISwitcher uISwitcher = new(uIStates);

        mainMenuController.OnOpenButtonClicked += uISwitcher.ChangeState<SecondaryMenuController>;
        secondaryMenuController.OnCloseButtonClicked += uISwitcher.ChangeState<MainMenuController>;

        uISwitcher.ChangeState<MainMenuController>();
    }
}
