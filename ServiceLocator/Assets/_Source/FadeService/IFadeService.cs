using UnityEngine.UI;

public interface IFadeService
{
    void FadeIn(Image image, float fadeDuration);
    void FadeOut(Image image, float fadeDuration);
}
