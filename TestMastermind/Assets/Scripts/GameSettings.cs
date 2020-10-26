using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Difficulty difficulty;
    
    public static GameSettings instance;
  


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Ther's already a gameSettings instance !");
            return;
        }

        instance = this;

        SetCodeLength(4);
        AllowDoubleColors(true);
        AllowGaps(false);
        difficulty.GapColor = new Color(1.0f, 1.0f, 1.0f, 0.22f);

        Color lightBlue = new Color(0f, 0.6f, 1f, 1f);
        Color orange = new Color(1f, 0.6f, 0f, 1f);
        Color purple = new Color(0.6f, 0f, 0.8f, 1f);
        Color[] ColorsToChoseFrom = { Color.black, Color.white, Color.red, Color.yellow, Color.green,
            lightBlue, orange, purple };

        difficulty.colorDifficulty = new ColorDifficulty(ColorsToChoseFrom);

        difficulty.colorDifficulty.SelectAll();
        difficulty.colorDifficulty.UnselectColor(orange);
        difficulty.colorDifficulty.UnselectColor(purple);

    }

    
    public void SetCodeLength(float codeLength)
    {
        difficulty.Code.Length = (int)codeLength;
    }

    public void AllowDoubleColors(bool setting)
    {
        difficulty.Code.AllowDoubles = setting;

    }

    public void AllowGaps(bool setting)
    {
        difficulty.Code.AllowGaps = setting;
    }

    public void AddColor(Color colorToAdd)
    {
       
        difficulty.colorDifficulty.SelectColor(colorToAdd);
    }

    public void RemoveColor(Color colorToRemove)
    {
       
        difficulty.colorDifficulty.UnselectColor(colorToRemove);

    }


}
