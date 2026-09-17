using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private TouchInput _touchInput;
    [SerializeField] private Puller _puller;
    [Space]
    [SerializeField] private float _maxDelta = 9f;
    [SerializeField] private float _maxForce = 1.6f;
    [Space]
    [SerializeField] private float _delay = 1f;

    private Coroutine _waiter;

    public UnityEvent StartingWait;
    public UnityEvent StopingWait;

    private void OnEnable()
    {
        _touchInput.ScrollEnded += TryToPull;
    }

    private void OnDisable()
    {
        _touchInput.ScrollEnded -= TryToPull;
    }

    private void TryToPull()
    {
        if (_waiter == null)
            Pull();
    }

    private void Pull()
    {
        Vector2 delta = _touchInput.CurrentDelta;
        float magnitude = Mathf.Min(delta.magnitude, _maxDelta);
        delta = delta.normalized * magnitude;

        Vector2 force = delta / _maxDelta * _maxForce;

        _puller.Pull(force);
        _waiter = StartCoroutine(Wait(_delay));
    }

    private IEnumerator Wait(float time)
    {
        StartingWait?.Invoke();

        yield return new WaitForSeconds(time);

        _waiter = null;
        StopingWait?.Invoke();
    }
}
