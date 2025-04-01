using UnityEngine;

public class PlayerPrefsSaver : ISaver
{
    private readonly Score _score;

    public PlayerPrefsSaver(Score score)
    {
        _score = score ?? throw new System.ArgumentNullException(nameof(score));
    }

    public void SaveScore(string path = null)
    {
        PlayerPrefs.SetInt("score", _score.Points);
        PlayerPrefs.Save();
    }
}
