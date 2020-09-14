using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    public Image[] codificators;
    public GameObject[] guessObjects;
    public Button confirmGuessButton;

    private void Awake()
    {
      if(codificators.Length != guessObjects.Length)
        {
            Debug.LogError("Arrays lengths must be the same\n guess array length: " + guessObjects.Length + ", codificator array length: " + codificators.Length);
        }
  
    }

    

    public void ConfirmGuess()
    {
        //lock colors submitted
        Disable();
                
        List<Color> guess = getColorsFromGameObjects(guessObjects);
        
        //check guess
        List<Color> codificatorsResult = GameManager.instance.Guess(guess);
        
        //fill codificator with result
        for(int i=0; i<codificatorsResult.Count; i++)
        {
            codificators[i].color = codificatorsResult[i];
        }

     }

    private List<Color> getColorsFromGameObjects(GameObject[] GOArray)
    {
        List<Color> colorList = new List<Color>();

        int codeLength = GameManager.instance.code.Length;

        for (int i = 0; i < codeLength; i++)
        {
            colorList.Add(GOArray[i].GetComponent<Image>().color);

        }

        return colorList;
    }

    public void Clear(Color clearColor)
    {
        for (int i = 0; i < codificators.Length; i++)
        {
            codificators[i].color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }

        for (int i = 0; i < guessObjects.Length; i++)
        {
            guessObjects[i].GetComponent<Image>().color = clearColor;

        }
    }


    public void Disable()
    {
        confirmGuessButton.enabled = false;
        confirmGuessButton.GetComponentInChildren<Text>().enabled = false;

        foreach (GameObject go in guessObjects)
        {
            go.GetComponent<Button>().enabled = false;
        }
    }

    public void Enable()
    {
        confirmGuessButton.enabled = true;
        confirmGuessButton.GetComponentInChildren<Text>().enabled = true;

        foreach (GameObject go in guessObjects)
        {
            go.GetComponent<Button>().enabled = true;
        }

        GameManager.instance.selectedHole = guessObjects[0];

    }

    //display the number of buttons according to code length
    public void setGuessLength(float value) //dynamic float
    {
        int length = (int)value;

        for (int i = 0; i < guessObjects.Length; i++)
        {
            guessObjects[i].SetActive(false);
            codificators[i].gameObject.SetActive(false);
        }
            

        for (int i = 0; i < length; i++)
        {
            guessObjects[i].SetActive(true);
            codificators[i].gameObject.SetActive(true);
        }
    }

}
