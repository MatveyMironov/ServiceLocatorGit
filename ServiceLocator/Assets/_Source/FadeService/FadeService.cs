using DG.Tweening;
using UnityEngine.UI;

public class FadeService : IFadeService
{
    public void FadeIn(Image image, float fadeDuration)
    {
        image.DOFade(1.0f, fadeDuration);
    }

    public void FadeOut(Image image, float fadeDuration)
    {
        image.DOFade(0f, fadeDuration);
    }
}
