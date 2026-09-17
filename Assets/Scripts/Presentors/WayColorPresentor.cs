using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayColorPresentor : MonoBehaviour
{
    [SerializeField] private LineRenderer _way;
    [SerializeField] private LevelPresentor _levelPresentor;
    [SerializeField] private SpriteRenderer _ball;

    private void OnEnable()
    {
        _levelPresentor.Rendered += Render;
    }

    private void OnDisable()
    {
        _levelPresentor.Rendered -= Render;
    }

    private void Render()
    {
        Color color = _ball.color;
        SetSingleColor(_way, color);
    }

    void SetSingleColor(LineRenderer lineRendererToChange, Color newColor)
    {
        Gradient tempGradient = lineRendererToChange.colorGradient;
        GradientColorKey[] tempColorKeys = tempGradient.colorKeys;
        for (int i = 0; i < tempColorKeys.Length; i++)
            tempColorKeys[i].color = newColor;
    
        tempGradient.colorKeys = tempColorKeys;
        lineRendererToChange.colorGradient = tempGradient;
    }
}
