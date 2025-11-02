using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private IInput _input;
    private ScoreCounter _scoreCounter;
    private ScoreIndicator _scoreIndicator;

    private void Awake()
    {
        _input = ServiceLocator.Get<IInput>();
        _scoreCounter = ServiceLocator.Get<ScoreCounter>();
        _scoreIndicator = ServiceLocator.Get<ScoreIndicator>();
    }

    private void Update()
    {
        var moveInput = _input.GetMove();
        var direction = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(direction * (_moveSpeed * Time.deltaTime));

        if (_input.GetAction())
        {
            _scoreCounter.AddScore();
            var currentScore = _scoreCounter.CurrentScore;
            _scoreIndicator.ShowScore(currentScore);
            
            if (_scoreCounter.IsWin)
            {
                Debug.Log("You win!");
                RestartLevel();
            }
        }
    }
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}