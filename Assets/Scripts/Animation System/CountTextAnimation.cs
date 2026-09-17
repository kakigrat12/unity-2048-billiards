using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CountTextAnimation : Animation
{
    public void Play(TMP_Text text, int from, int to)
    {
        Play(x => AnimateText(text, from, to, x), text);
    }

    private void AnimateText(TMP_Text text, int from, int to, float value)
    {
        int currentValue = (int)Mathf.Lerp(from, to, value);
        text.text = currentValue.ToString();
    }
}
