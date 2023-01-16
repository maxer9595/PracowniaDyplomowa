using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneMenager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TestingScene");
    }
    public void HowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void OptionsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
