using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Record : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private PlayerProgressSaver _saver;
    public int LastValue { get; private set; }
    private bool _wasRecord;

    public event Action Updated;
    public UnityEvent NewRecord;

    private void OnEnable()
    {
        _counter.ValueUpdated += Cheack;
        _saver.Loaded += OnLoaded;
    }

    private void OnDisable()
    {
        _counter.ValueUpdated -= Cheack;
        _saver.Loaded -= OnLoaded;
    }

    private void OnLoaded()
    {
        Debug.Log("Loaded");
        LastValue = GetPlayerData().Count;
        Updated?.Invoke();
    }

    private void Cheack()
    {
        Debug.Log("Cheack");
        var data = GetPlayerData();
        int currentValue = _counter.CurrenValue;

        if (currentValue > data.Count)
        {
            data.Count = currentValue;
            LastValue = currentValue;

            if (!_wasRecord)
            {
                _wasRecord = true;
                if(data.Count != 0)
                    NewRecord?.Invoke();
            }

            _saver.Save(data);
            Updated?.Invoke();
        }
        else
        {
            _wasRecord = false;
        }
    }

    private PlayerData GetPlayerData() => _saver.GetPlayerData();
}
