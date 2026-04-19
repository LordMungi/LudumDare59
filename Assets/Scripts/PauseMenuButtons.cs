using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    void Update()
    {

    }
    
    private void Resume()
    {
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }

    private void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
