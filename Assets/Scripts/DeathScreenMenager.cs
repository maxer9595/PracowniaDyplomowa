using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMenager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
