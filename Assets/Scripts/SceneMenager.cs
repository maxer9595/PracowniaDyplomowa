using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenager : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DeathScreen" || SceneManager.GetActiveScene().name == "EndLevelScene")
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
         if (SceneManager.GetActiveScene().name == "MapScene")
        {
            bgMusic.instance.GetComponent<AudioSource>().Pause();
        }
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            bgMusic.instance.GetComponent<AudioSource>().Play();
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToMap()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void HowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void DeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }
    public void EndLevelScene()
    {
        SceneManager.LoadScene("EndLevelScene");
    }
    public void StoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }
}