using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisappearanceRemover : Remover
{
    [SerializeField] private float _minDelay = 0f;
    [SerializeField] private float _maxDelay = 1.4f;
    [Space]
    [SerializeField] private ScaleAnimation _scaleAnimation;
    [Space]
    public UnityEvent StartRemoving;

    public override void Remove()
    {
        float time = Random.Range(_minDelay, _maxDelay);
        StartCoroutine(Wait(time));

        StartRemoving?.Invoke();
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        _scaleAnimation.Play(this);
        yield return new WaitForSeconds(_scaleAnimation.Duration);
        Destroy(gameObject);
    }
}
