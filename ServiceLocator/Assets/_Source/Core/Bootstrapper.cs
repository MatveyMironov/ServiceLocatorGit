using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private SecondaryMenuView secondaryMenuView;

    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    [Space]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button collectButton;

    private void Start()
    {
        ServiceLocator serviceLocator = new();

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

        Score score = new();

        ScoreAdder scoreAdder = new(score);
        collectButton.onClick.AddListener(scoreAdder.AddPoints);

        ScoreDisplayer scoreDisplayer = new(scoreText);
        scoreDisplayer.DisplayScore(score);

        ISaver saver = new JSONSaver(score);
        serviceLocator.TryAddService(saver);
    }
}
