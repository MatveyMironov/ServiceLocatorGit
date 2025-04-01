using System;
using TMPro;

public class ScoreDisplayer
{
    private readonly TextMeshProUGUI _scoreText;

    private Score _score;

    public ScoreDisplayer(TextMeshProUGUI scoreText)
    {
        _scoreText = scoreText != null ? scoreText : throw new ArgumentNullException(nameof(scoreText));
    }

    public void DisplayScore(Score score)
    {
        _score = score;
        _score.OnScoreChanged += DisplayPoints;
        DisplayPoints();
    }

    public void HideScore()
    {
        _score.OnScoreChanged -= DisplayPoints;
        _score = null;
    }

    private void DisplayPoints()
    {
        if (_score == null)
            return;

        _scoreText.text = _score.Points.ToString();
    }
}
