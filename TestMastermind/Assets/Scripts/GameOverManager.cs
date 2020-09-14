using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Canvas gameOverUI;
    public string mainMenuScene;


    public static GameOverManager instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("can't create more GameOverManageer in the scene. Use gameOverManager.instance to access it");
            return;
        }

        instance = this;

        gameOverUI.enabled = false;
    }

    public void OnGameOver(string gameOverText)
    {
        gameOverUI.gameObject.GetComponentInChildren<Text>().text = gameOverText;
        gameOverUI.enabled = true;

      
    }


    public void RePlay()
    {
        gameOverUI.enabled = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MasterMindBoard");
    }

    public void MainMenu()
    {
        gameOverUI.enabled = false;
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene(mainMenuScene);
    }


    public void Quit()
    {
        Application.Quit();

    }
}
