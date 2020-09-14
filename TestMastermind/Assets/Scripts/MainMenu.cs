using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    public void NewGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
