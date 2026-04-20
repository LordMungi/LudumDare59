using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button exitButton;

    [SerializeField] Button backButton;
    [SerializeField] GameObject canvasCredits;
    [SerializeField] GameObject mainMenu;

    void OnEnable()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Destroy(exitButton.gameObject);
        }
    }
    void Start()
    {
        playButton.onClick.AddListener(play);

        creditsButton.onClick.AddListener(credits); //AGREGO ESTO
        exitButton?.onClick.AddListener(exitGame); //AGREGO ESTO
        backButton.onClick.AddListener(backToMenu); //AGREGO ESTO
        canvasCredits.SetActive(false); //AGREGO ESTO
        mainMenu.SetActive(true); //AGREGO ESTO
    }

    void Update()
    {
        
    }

    private void play()
    {
        SceneManager.LoadScene("Game");
    }

    private void credits() //AGREGO ESTO
    {
        canvasCredits.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void exitGame() //AGREGO ESTO
    {
        Application.Quit();
    }

    public void backToMenu() //AGREGO ESTO
    {
        canvasCredits.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(play);
        creditsButton.onClick.RemoveListener(credits); //AGREGO ESTO
        exitButton?.onClick.RemoveListener(exitGame); //AGREGO ESTO
        backButton.onClick.RemoveListener(backToMenu); //AGREGO ESTO
    }
}
