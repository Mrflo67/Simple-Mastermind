using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public Canvas settingsWindow;

    public void NewGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsWindow()
    {
        settingsWindow.enabled =true;
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
