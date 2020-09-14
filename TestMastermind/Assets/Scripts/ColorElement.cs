
using UnityEngine;
using UnityEngine.UI;


public class ColorElement : MonoBehaviour
{
    public Button removeButton;
    public Button addButton;
    public Image colorDisplay;
    private Color _color;
    private bool _isAdded;
    public bool IsAdded
    {
        get { return _isAdded; }
        set
        {
            _isAdded = value;
            if(value==true)
            {
                addButton.gameObject.SetActive(false);
                removeButton.gameObject.SetActive(true);
            }else
            {
                addButton.gameObject.SetActive(true);
                removeButton.gameObject.SetActive(false);
            }
            
        }
    }



    public Color Color
    {
        get { return _color; }
        set {
            _color = value;
            SetDisplayColor(value);
        }
    }

    private void Awake()
    {
        _color = colorDisplay.color;
        IsAdded = false;
    }

   


    private void SetDisplayColor(Color displayColor)
    {
        colorDisplay.color = displayColor;
    }


    public void RemoveElement()
    {
        if(GameSettings.instance.difficulty.colorDifficulty.GetSelectedColors().Count >1)
        {
            GameSettings.instance.RemoveColor(_color);
            IsAdded = false;
        }
       
    }

    public void AddElement()
    {
        GameSettings.instance.AddColor(_color);
        IsAdded = true;
    }

}
