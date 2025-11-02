using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    public static bool IsStartedFromBoot { get; private set; }

    private void Start()
    {
        RegisterServices();
        IsStartedFromBoot = true;
        SceneManager.LoadScene("Level");
    }

    private void RegisterServices()
    {
        var inputService = new KeyInput();
        ServiceLocator.RegisterSingleton<IInput>(inputService);

        ServiceLocator.RegisterTransient<ScoreIndicator>(() => new ScoreIndicator());
    }
}