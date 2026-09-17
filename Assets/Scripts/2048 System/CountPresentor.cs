using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountPresentor : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _count;
    [Space]
    [SerializeField] private CountTextAnimation _animation;
    private int _lastValue = 0;

    private void OnEnable()
    {
        _counter.ValueUpdated += Render;
        Render();
    }

    private void OnDisable()
    {
        _counter.ValueUpdated -= Render;
    }

    private void Render()
    {
        int currentValue = _counter.CurrenValue;
        _animation.Play(_count, _lastValue, currentValue);

        _lastValue = currentValue;
    }
}
