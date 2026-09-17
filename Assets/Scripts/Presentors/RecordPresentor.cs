using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
    
public class RecordPresentor : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Record _record;

    private void OnEnable()
    {
        _record.Updated += Render;
        Render();
    }

    private void OnDisable()
    {
        _record.Updated -= Render;
    }

    private void Render()
    {
        _text.text = _record.LastValue.ToString();
    }
}
