using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Win : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [Space]
    [SerializeField] private int _winValue = 11;

    public event Action Winned;
    public UnityEvent WinnedEvent;

    private void OnEnable()
    {
        Rest();
    }

    private void OnDisable()
    {
        _counter.ValueUpdated -= Cheack;
    }

    public void Rest()
    {
        _counter.ValueUpdated += Cheack;
    }

    private void Cheack()
    {
        Level biggest = _counter.Biggest;
        //Debug.Log("Max level: " + biggest.GetValue());
        if (biggest != null && biggest.GetValue() == _winValue)
        {
            _counter.ValueUpdated -= Cheack;
            Winned?.Invoke();
            WinnedEvent?.Invoke();
        }
    }
}
