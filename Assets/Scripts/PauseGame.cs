using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUi;
    bool isActive = false;
    void Start()
    {
        // pauseMenuUi.SetActive(false);
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive)
            {
                Resume();
            }
            else { Pause(); }
        }
    }
    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        isActive = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isActive = false;
    }
}
