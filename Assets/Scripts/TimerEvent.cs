using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    [SerializeField] private float _timeToWaite = 1f;
    [SerializeField] private bool _onAwake;
    private Coroutine _currentWaite;

    public UnityEvent Finished;

    private void OnEnable()
    {
        if (_onAwake) StartWait();
    }

    public void StartWait()
    {
        if (_currentWaite is not null) StopCoroutine(_currentWaite);
        _currentWaite = StartCoroutine(Waite());
    }

    private IEnumerator Waite()
    {
        yield return new WaitForSeconds(_timeToWaite);
        Finished?.Invoke();
    }
}
