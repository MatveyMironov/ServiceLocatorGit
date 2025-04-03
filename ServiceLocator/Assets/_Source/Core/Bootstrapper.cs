using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button collectButton;

    [Inject]
    private void Bootstrap(MainMenuController mainMenuController, SecondaryMenuController secondaryMenuController, Score score)
    {
        List<IUIState> uIStates = new() { mainMenuController, secondaryMenuController };
        UISwitcher uISwitcher = new(uIStates);

        mainMenuController.OnOpenButtonClicked += uISwitcher.ChangeState<SecondaryMenuController>;
        secondaryMenuController.OnCloseButtonClicked += uISwitcher.ChangeState<MainMenuController>;

        uISwitcher.ChangeState<MainMenuController>();

        ScoreAdder scoreAdder = new(score);
        collectButton.onClick.AddListener(scoreAdder.AddPoints);

        ScoreDisplayer scoreDisplayer = new(scoreText);
        scoreDisplayer.DisplayScore(score);
    }
}
