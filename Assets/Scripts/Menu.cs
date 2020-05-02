using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PausePanel;
    public Button StartButton;
    public Button RestartButton;

    public void Awake()
    {
        Time.timeScale = 0;
        if (GameData.PlayerWantRestart)
        {
            StartGame();
            GameData.PlayerWantRestart = false;
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameData.PlayerWantRestart = true;
    }

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        Sounds.PlaySound("music");
        Time.timeScale = 1;
    }
    
    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (StartButton.IsActive())
            {
                StartGame();
            }
            else if (RestartButton.IsActive())
            {
                TryAgain();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!StartButton.IsActive())
            {
                Time.timeScale = 0;
                PausePanel.SetActive(true);
            }
        }
    }
}
