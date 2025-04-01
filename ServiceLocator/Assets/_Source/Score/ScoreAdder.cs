using System;

public class ScoreAdder
{
    private readonly Score _score;

    public ScoreAdder(Score score)
    {
        _score = score ?? throw new ArgumentNullException(nameof(score));
    }

    public void AddPoints()
    {
        _score.AddPoints(1);
    }
}
