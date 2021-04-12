using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuWidget : GameHUDWidget
{
    [SerializeField] private string ExitMenuSceneName;

    public void ResumeGame()
    {
        MyPauseManager.instance.UnPauseGame();
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(ExitMenuSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
