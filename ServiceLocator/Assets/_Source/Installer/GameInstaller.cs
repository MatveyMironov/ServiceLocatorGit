using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private SecondaryMenuView secondaryMenuView;

    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    public override void InstallBindings()
    {
        Container.Bind<ISoundPlayer>().To<SoundPlayer>().FromInstance(new(audioSource, openSound, closeSound)).AsSingle();
        Container.Bind<IFadeService>().To<FadeService>().AsSingle();
        Container.Bind<ISaver>().To<JSONSaver>().AsSingle();

        Container.Bind<MainMenuView>().FromInstance(mainMenuView).AsSingle();
        Container.Bind<SecondaryMenuView>().FromInstance(secondaryMenuView).AsSingle();

        Container.Bind<MainMenuController>().AsSingle();
        Container.Bind<SecondaryMenuController>().AsSingle();

        Container.Bind<Score>().AsSingle();
    }
}
