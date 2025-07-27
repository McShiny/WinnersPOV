using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIContorller : MonoBehaviour
{

    private GameInput gameInput;

    private void Awake()
    {
        gameInput = FindAnyObjectByType<GameInput>();
    }

    public void Restart()
    {
        gameInput.OnDisable();
        SceneManager.LoadScene("Gameplay");

    }

    public void Home()
    {
        gameInput.OnDisable();
        SceneManager.LoadScene("MainMenu");
    }
}
