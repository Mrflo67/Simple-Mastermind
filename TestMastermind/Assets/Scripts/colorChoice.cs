using UnityEngine;
using UnityEngine.UI;

public class colorChoice : MonoBehaviour
{
    public void OnColorSelected()
    {
        Color selectedColor = gameObject.GetComponent<Image>().color;

        GameManager.instance.ApplySelectedColorInSelectedHole(selectedColor);
        
    }
}
