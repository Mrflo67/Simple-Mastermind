using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CodeDifficulty
{
    public int Length;
    public bool AllowDoubles;
    public bool AllowGaps;
    

}

public class ColorDifficulty
{
    private Color[] _allColors;
    private List<Color> _nonSelected;
    private List<Color> _selected;

    public ColorDifficulty(Color[] colorArray)
    {
        _allColors = new Color[colorArray.Length];
        _nonSelected = new List<Color>();
        _selected = new List<Color>();

        Array.Copy(colorArray, _allColors, colorArray.Length);

        foreach(Color color in _allColors)
        {
            _nonSelected.Add(color);
        }
    }

    public void SelectColor(Color color)
    {
        _selected.Add(color);
        _nonSelected.Remove(color);
    }

    public void UnselectColor(Color color)
    {
        _selected.Remove(color);
        _nonSelected.Add(color);
    }

    public void SelectAll()
    {
        foreach (Color color in _allColors)
        {
            _selected.Add(color);
        }

        _nonSelected.Clear();
    }

    public void UnselectAll()
    {
        
        foreach (Color color in _allColors)
        {
            _nonSelected.Add(color);
        }

        _selected.Clear();
    }

    public Color[] GetAllColors()
    {
        return _allColors;
    }


    public List<Color> GetSelectedColors()
    {
        return _selected;
    }

    public List<Color> GetRemainingColors()
    {
        return _nonSelected;
    }


}


public class Difficulty : MonoBehaviour
{
    public CodeDifficulty Code;
    public ColorDifficulty colorDifficulty;

    public Color GapColor;


}
