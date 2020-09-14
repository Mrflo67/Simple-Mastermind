using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySettingsWindow : MonoBehaviour
{
    public Slider codeLengthSlider;
    public Toggle doubleToggle;
    public Toggle gapsToggle;

    public Gradient gradient;
    public Image fill;

    public ColorElement[] colorSelectors;

    private void Start()
    {
        GetCurrentSettings();
        fill.color = gradient.Evaluate(codeLengthSlider.normalizedValue);
    }

    public void OnSliderValueChange(float value)
    {
        fill.color = gradient.Evaluate(codeLengthSlider.normalizedValue);

        if (value < 2)
        {
            doubleToggle.isOn = false;
        }

        GameSettings.instance.SetCodeLength((int)value);
    }

    public void OnDoubleToggleChange(bool value)
    {
        if (doubleToggle.isOn && codeLengthSlider.value < 2)
        {
            codeLengthSlider.value = 2;
        }

        GameSettings.instance.AllowDoubleColors(value);
    }

    public void OnGapsToggleChange(bool value)
    {
        GameSettings.instance.AllowGaps(value);
    }

        private void GetCurrentSettings()
    {
        CodeDifficulty currentCodeDifficulty = GameSettings.instance.difficulty.Code;


        codeLengthSlider.value = currentCodeDifficulty.Length;
        doubleToggle.isOn = currentCodeDifficulty.AllowDoubles;
        gapsToggle.isOn = currentCodeDifficulty.AllowGaps;

        GetCurrentColorSettings();

    }


    private void GetCurrentColorSettings()
    {
        ColorDifficulty currentColorDifficulty = GameSettings.instance.difficulty.colorDifficulty;

        List<Color> selectedColors = currentColorDifficulty.GetSelectedColors();
        List<Color> unSelectedColors = currentColorDifficulty.GetRemainingColors();
        var i = 0;
        var j = 0;
        
        foreach (ColorElement ce in colorSelectors)
        {
            if(i<selectedColors.Count)
            {
                ce.Color = selectedColors[i];
                ce.IsAdded = true;
                i++;
            }else
            {
                ce.Color = unSelectedColors[j];
                ce.IsAdded = false;
                j++;
            }
        }
    }
}


