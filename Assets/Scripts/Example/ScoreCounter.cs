using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _scoresToWin;

    public int CurrentScore { get; private set; }
    public bool IsWin => CurrentScore >= _scoresToWin;

    public void AddScore()
    {
        CurrentScore += _scoreToAdd;
    }
}