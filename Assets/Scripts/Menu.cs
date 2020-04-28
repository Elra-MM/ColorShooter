using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public void Awake()
    {
        Time.timeScale = 0;
    }

    public void TryAgain()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Time.timeScale = 1;
   }

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
