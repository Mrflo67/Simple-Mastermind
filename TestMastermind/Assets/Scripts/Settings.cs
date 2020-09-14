using UnityEngine;

public class Settings : MonoBehaviour
{
    public Canvas GameSettingsUI;

    public void GameSettings()
    {
        GameSettingsUI.enabled = true;
    }

    public void CloseGameSettings()
    {
        GameSettingsUI.enabled = false;

    }
}
