using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public static PauseGame instance;
    [HideInInspector] public bool isActive = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ShowHelp.instance.isActive)
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
