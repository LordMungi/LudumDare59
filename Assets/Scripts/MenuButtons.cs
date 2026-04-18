using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button exitButton;

    void Start()
    {
        playButton.onClick.AddListener(play);
    }

    void Update()
    {
        
    }

    private void play()
    {
        SceneManager.LoadScene("Game");
    }
}
