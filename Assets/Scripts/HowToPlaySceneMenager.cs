using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlaySceneMenager : MonoBehaviour
{
    public void ExitScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
