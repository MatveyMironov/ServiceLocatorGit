using System;
using UnityEngine;

[Serializable]
public class Score
{
    [SerializeField] int _points;

    public int Points { get => _points; }

    public event Action OnScoreChanged;

    public void AddPoints(int points)
    {
        if (points <= 0)
            throw new ArgumentOutOfRangeException();

        _points += points;
        OnScoreChanged?.Invoke();
    }

    public void SubtractPoints(int points)
    {
        if (points <= 0)
            throw new ArgumentOutOfRangeException();

        if (_points - points < 0)
            return;

        _points -= points;
        OnScoreChanged?.Invoke();
    }
}
