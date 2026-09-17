using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class Loss : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Player _player;
    [SerializeField] private int _maxBallsCount = 16;
    [SerializeField] private float _timeToWait = 10f;
    public int CurrentAttempts { get; private set; }
    private Coroutine _currentWaiter;

    public float TimeToWait => _timeToWait;

    public event Action CountdownCanceled;
    public event Action CurrentAttemptsUpdated;
    public event Action AttemptsOver;
    public event Action Losed;

    private void OnEnable()
    {
        _counter.BallsCountUpdated += CheakLoss;
        CheakLoss();
    }

    private void OnDisable()
    {
        _counter.BallsCountUpdated -= CheakLoss;
    }

    public void Reset()
    {
        if (_currentWaiter is not null)
        {
            StopCoroutine(_currentWaiter);
            CountdownCanceled?.Invoke();
        }
    }

    private void CheakLoss()
    {
        if (_currentWaiter != null)
        {
            StopCoroutine(_currentWaiter);
            _player.enabled = true;
        }

        CurrentAttempts = _maxBallsCount - _counter.BallsCount;
        if (IsMaximum())
        {
            _currentWaiter = StartCoroutine(Wait(_timeToWait));
        }
        else
        {
            if(_currentWaiter is not null)
                CountdownCanceled?.Invoke();
        }

        CurrentAttemptsUpdated?.Invoke();
    }

    private IEnumerator Wait(float time)
    {
        _player.enabled = false;
        AttemptsOver?.Invoke();
        yield return new WaitForSeconds(time);

        if (IsMaximum())
        {
            Losing();
        }
        else
        {
            _player.enabled = true;
        }
    }

    private bool IsMaximum() => CurrentAttempts <= 0;

    private void Losing()
    {
        Debug.Log("Lose");
        _player.enabled = false;
        Losed?.Invoke();
    }
}
