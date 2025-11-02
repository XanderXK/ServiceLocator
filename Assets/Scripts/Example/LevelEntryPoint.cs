using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounterPrefab;
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    private void Start()
    {
        if (!Boot.IsStartedFromBoot)
        {
            SceneManager.LoadScene("Boot");
            return;
        }

        RegisterScopedServices();
        SpawnPlayer();
    }

    private void RegisterScopedServices()
    {
        var scoreCounter = Instantiate(_scoreCounterPrefab);
        ServiceLocator.RegisterScoped<ScoreCounter>(scoreCounter);
    }

    private void SpawnPlayer()
    {
        Instantiate(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);
    }

    private void OnDisable()
    {
        ServiceLocator.ClearScopedServices();
    }
}