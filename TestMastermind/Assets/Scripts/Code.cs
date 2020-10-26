
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public GameObject[] CodeObjects;
    public GameObject Shield;

    private int _length;
    private List<Color> _codeColors;

    public int Length
    {
        get => _length;
        set {
            if(value > 0)
            {
                _length = value;
                UpdateActiveObjects();
            }
            else
            {
                Debug.LogError("length must be a positive value");
            }
        }
    }

    private void Awake()
    {
        Show();
        _length = 1;
        _codeColors = new List<Color>() ;
        
    }

    public void GenerateRandomCombination(List<Color> colorChoices, bool allowDouble=false)
    {
        for (int i = 0; i < _length; i++)
        {

            int iRandom = UnityEngine.Random.Range(0, colorChoices.Count);
            Color secretColor = colorChoices[iRandom];

            CodeObjects[i].GetComponentInChildren<Image>().color = secretColor;
            _codeColors.Add(secretColor);

            // Note the code will have doubles if the colorlist become too small
            if((!allowDouble) && (colorChoices.Count > 1))
            {
                colorChoices.Remove(colorChoices[iRandom]);
            }
        }
    }

    /// <summary>Fills the checkFeedback colorList and 
    /// return <c>true</c> if the guessList is same as this object codeColors.</summary>
    public bool Check(List<Color> guess, out List<Color> checkFeedback)
    {
        checkFeedback = new List<Color>();

        if(guess.Count != _length)
        {
            Debug.LogError($" argument lengths must be the same\n guess List length: { guess.Count }, code List length: {_length}");
            
            return false;
        }

        List<Color> guessCopy = new List<Color>(guess);
        List<Color> codeColorsCopy = new List<Color>(_codeColors);

        int blacks = 0;
        int whites = 0;
        int checkCount = _length;

        // Check for good positions
        // Reverse order to allow list deletions
        for(var i=checkCount-1; i>=0; i--)
        {
            if(CompareColors(guessCopy[i], codeColorsCopy[i]))
            {
                blacks++;
                codeColorsCopy.RemoveAt(i);
                guessCopy.RemoveAt(i);
            }
        }

        // Check for remaining in wrong position

        checkCount = guessCopy.Count;
        for (var i = checkCount - 1; i >= 0; i--)
        {
            int iFound = codeColorsCopy.IndexOf(guessCopy[i]);

            if (iFound >= 0)
            {
                whites++;
                codeColorsCopy.RemoveAt(iFound);
            }
        }
          

        for (var i = 0; i < blacks; i++)
        {
            checkFeedback.Add(Color.black);
        }

        if (blacks == _length)
            return true;

        for (var i = 0; i < whites; i++)
        {
            checkFeedback.Add(Color.white);
        }

        return false;
    }

    
    public bool CompareColors(Color color1, Color color2)
    {
        bool comparisonResult = ((color1 - color2) == Color.clear); ;
        
        return comparisonResult;
    }

   private void UpdateActiveObjects()
    {
        // Disable all objects
        foreach (GameObject codeObject in CodeObjects)
        {
            codeObject.SetActive(false);
        }

        // Then activate number required
        for (int i = 0; i < _length; i++)
        {
            CodeObjects[i].SetActive(true);
        }
    }
    

    public void Show()
    {
       
        Shield.SetActive(false);
    }

    public void Hide()
    {
        Shield.SetActive(true);

        string shieldText = "";

        for (int i = 0; i < _length; i++)
        {
            shieldText += "? ";
        }
        Shield.GetComponentInChildren<Text>().text = shieldText;

    }
}
