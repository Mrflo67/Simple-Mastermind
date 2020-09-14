using UnityEngine;
using UnityEngine.UI;


public class SliderValueToText : MonoBehaviour
{
    public void ShowSliderValue(float sliderValue)
    {
        gameObject.GetComponent<Text>().text = sliderValue.ToString();
    }
}