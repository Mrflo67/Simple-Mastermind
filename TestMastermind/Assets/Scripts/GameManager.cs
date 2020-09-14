using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    

    public Code code;
 
    public GameObject selectedHole;
    public GameObject[] colorSelector;
    public ScrollRect colorScrollRect;
    public GameObject colorScrollbar;

    public Row[] rows;

    public List<Color> _colorList;
    public Color _gapColor;

    public static GameManager instance;

    public int codeLength;
    public int currentRow;
    public int maxRow;
    public int score;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("IL y a plus d'une instance de GameManager dans la scène");
            return;
        }

        instance = this;

        _colorList = new List<Color>();
        maxRow = rows.Length-1;
        score = (maxRow + 1) * 10;

        colorScrollbar.SetActive(false);
        colorScrollRect.enabled = false;

    }

    private void Start()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.orientation = ScreenOrientation.AutoRotation;

        NewGame();
    }

    public void ApplySelectedColorInSelectedHole(Color colorToApply)
    {
        Image targetImage = selectedHole.GetComponent<Image>();

        if(code.CompareColors(targetImage.color, colorToApply))
        {
            targetImage.color = _gapColor;
            return;
        }
        targetImage.color = colorToApply;
    }


    private void GetColorListSettings()
    {
        _gapColor = GameSettings.instance.difficulty.GapColor;

        for (var i = 0; i < colorSelector.Length; i++)
            colorSelector[i].gameObject.SetActive(false);

        _colorList.Clear();
        
      //  List<Color> colorListSettings = GameSettings.instance.difficulty.SelectedColors;
        List<Color> colorListSettings = GameSettings.instance.difficulty.colorDifficulty.GetSelectedColors();



        for (var i=0; i<colorListSettings.Count; i++)
        {
            Color colorElement = colorListSettings[i]; 

            _colorList.Add(colorElement);
            colorSelector[i].GetComponent<Image>().color = colorElement;
            colorSelector[i].gameObject.SetActive(true);
        }

        if(colorListSettings.Count > 7)
        {
            colorScrollbar.SetActive(true);
            colorScrollRect.enabled = true;
        }

        bool gaps = GameSettings.instance.difficulty.Code.AllowGaps;
       
        if (gaps==true)
        {
            _colorList.Add(_gapColor);
        }
    }

    private void ClearBoard()
    {
        ClearRows();
        DisableRows();
    }

    private void ClearRows()
    {
        for (var i = 0; i < rows.Length; ++i)
        {
            rows[i].Clear(_gapColor);
        }

    }

    private void DisableRows()
    {
        for (var i = 0; i < rows.Length; ++i)
        {
            rows[i].Disable();
        }
    }

    public void NewGame()
    {
        GetColorListSettings();
        ClearBoard();

        SetCodeLength(GameSettings.instance.difficulty.Code.Length);
        bool doubles = GameSettings.instance.difficulty.Code.AllowDoubles;
        

        code.GenerateRandomCombination(_colorList, doubles);
        code.Hide();

        currentRow = 0;
        rows[currentRow].Enable();

    }


    public void SetCodeLength(float value)
    {
        int iValue = (int)value;

        codeLength = iValue;
        code.Length = iValue;
        UpdateRowsDisplay(iValue);
    }



    //set number of cells (holes) displayed according to code length (between minSize and maxSize)
    private void UpdateRowsDisplay(int value)
    {
        //guess cells count should be equal to code cells
        foreach (Row guessRank in rows)
        {
            guessRank.setGuessLength(value);
        }
    }


    public List<Color> Guess(List<Color> guess)
    {
        bool guessMatchesCode= code.Check(guess, out List <Color> guessFeedback);
        
        if (guessMatchesCode)
        {
            Win();
        }
        else if (currentRow >= maxRow)
        {
            Lose();
        }
        else
        {
            rows[++currentRow].Enable();
            score -= 10;
        }

        return guessFeedback;
    }

    private void Win()
    {
        //revele le code
        code.Show();

        //affiche écran gameOver
        GameOverManager.instance.OnGameOver("You found the code !\n Score : " + score.ToString());
    }

    private void Lose()
    {
        //revele le code
        code.Show();

        //affiche écran gameOver
        GameOverManager.instance.OnGameOver("Game Over !\n Score : " + score.ToString());
    }

}
