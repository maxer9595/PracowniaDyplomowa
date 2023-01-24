using UnityEngine;

public class ShowHelp : MonoBehaviour
{
    public GameObject helpUi;
    public static ShowHelp instance;
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
        if (Input.GetKeyDown(KeyCode.H) && !PauseGame.instance.isActive)
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
        helpUi.SetActive(true);
        Time.timeScale = 0f;
        isActive = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        helpUi.SetActive(false);
        Time.timeScale = 1f;
        isActive = false;
    }
}
