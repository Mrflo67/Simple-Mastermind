using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public string mainMenuScene;

    public Canvas pauseMenuUI;
    public Canvas settingsMenuUI;
    public Text scoreText;
    public Text infoText;

    string[] infoTexts = { "You can do it !", "Think harder", "Too hard ? Too bad !",
            "Did you noticed the animated main menu background ?", "Don't cheat !",
            "Gaps are just transparent colors !","Sorry for the ugly buttons !",
            "Too easy ? Add some colors !","Play some music", "Hello from France !",
            "The cake is a lie", "Henry has come to see us !", "Color involved games are risky nowadays !",
            "Don't know what to say !", "Sorry if you're colorblind !", "Maybe I should add options for colorblind people...",
            "These messages are the real thing of this app", "You pause more than you play, what is wrong with you?",
            "This is the last message", "Back in the loop !!", "Now for real", "Finish the game and stop that",
            "That was fun !", "I almost feel empathy for a simple text"};

    int iCurrent;
    int iLast;


    private void Awake()
    {
        pauseMenuUI.enabled = false;
        settingsMenuUI.enabled = false;

        iCurrent = 0;
        iLast = infoTexts.Length;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                Paused();
            }
            else
            {
                Resume();
            }
        }
        
    }

    public void Resume()
    {
        isGamePaused = false;
        pauseMenuUI.enabled = false;
    }

    public void Paused()
    {
        infoText.text = infoTexts[iCurrent];
        iCurrent++;
        if (iCurrent == iLast)
            iCurrent = 0;

        scoreText.text = "Score : " + GameManager.instance.score.ToString();
 
        isGamePaused = true;
        pauseMenuUI.enabled = true;
    }

    public void NewGame()
    {
        Resume();
        SceneManager.LoadScene("MastermindBoard");
    }

    public void Settings()
    {
        settingsMenuUI.enabled = true;
    }

    public void CloseSettings()
    {
        settingsMenuUI.enabled = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void SetCodeLength(float codeLength)
    {
        GameSettings.instance.SetCodeLength(codeLength);
    }

    public void AllowDoubleColors(bool setting)
    {
        GameSettings.instance.AllowDoubleColors(setting);

    }

    public void AllowGaps(bool setting)
    {
        GameSettings.instance.AllowGaps(setting);
    }

}
