using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
[System.Serializable]
public class LangugeText
{
    [SerializeField] private string _text;
}
*/

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLangugeChanger : MonoBehaviour
{
    [SerializeField] private string[] _texts = new string[2];
    private CurrentLanguge _languge => CurrentLanguge.Instance;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Render();
    }

    private void Render()
    {
        _text.text = _texts[(int)_languge.Current];
    }
}
