using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public abstract class Animation
{
    [SerializeField] private AnimationCurve _cruve;
    [SerializeField] private float _duration = 1f;
    protected delegate void Animator(float value);
    protected Coroutine CurrentAnimation;

    public float Duration => _duration;

    //public abstract void Play(MonoBehaviour monoBehaviour);

    protected void Play(Animator animator, MonoBehaviour monoBehaviour)
    {
        if (CurrentAnimation != null) monoBehaviour.StopCoroutine(CurrentAnimation);
        CurrentAnimation = monoBehaviour.StartCoroutine(Animate(_duration, animator));
    }

    protected IEnumerator Animate(float duration, Animator animator)
    {
        float time = 0;
        while (time / duration < 1)
        {
            float value = _cruve.Evaluate(time / duration);
            animator(value);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
