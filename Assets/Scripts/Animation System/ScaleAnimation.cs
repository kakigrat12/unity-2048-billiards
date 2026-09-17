using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScaleAnimation : Animation
{
    private Vector3 _startScale;

    public void Play(MonoBehaviour monoBehaviour)
    {
        Transform transform = monoBehaviour.transform;
        _startScale = transform.localScale;

        Play(x => ChangeScale(x, transform), monoBehaviour);
    }

    private void ChangeScale(float value, Transform transform)
    {
        transform.localScale = _startScale * value;
    }
}
