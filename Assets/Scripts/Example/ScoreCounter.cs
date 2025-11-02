using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scoreToAdd = 1;
    [SerializeField] private int _scoresToWin = 5;

    public int CurrentScore { get; private set; }
    public bool IsWin => CurrentScore >= _scoresToWin;

    public void AddScore()
    {
        CurrentScore += _scoreToAdd;
    }
}