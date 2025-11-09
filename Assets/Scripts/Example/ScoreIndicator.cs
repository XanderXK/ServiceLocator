using UnityEngine;

public class ScoreIndicator : IIndicator
{
    public void Show(int value)
    {
        Debug.Log($"Current Score: {value}");
    }
}