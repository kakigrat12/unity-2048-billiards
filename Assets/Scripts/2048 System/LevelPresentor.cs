using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPresentor : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private TMP_Text _levelText;
    [Space]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Gradient _ballColor;

    public event Action Rendered;

    private void OnEnable()
    {
        _level.LevelUpped += Render;
        Render();
    }

    private void OnDisable()
    {
        _level.LevelUpped -= Render;
    }

    private void Render()
    {
        int level = _level.GetValue();
        int value = GetPowerValue(level);
        _levelText.text = value.ToString();

        _spriteRenderer.color = GetCurrentColor(level);

        Rendered?.Invoke();
    }

    private Color GetCurrentColor(int level)
    {
        float n = 5;
        float value = -1f * n / (level + n) + 1;
        return _ballColor.Evaluate(value);
    }

    private int GetPowerValue(int value) => (int)Mathf.Pow(2, value);
}
