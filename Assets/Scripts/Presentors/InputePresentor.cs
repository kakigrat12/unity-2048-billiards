using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputePresentor : PullWayPresentor
{
    [Space]
    [SerializeField] private TouchInput _touchInput;

    private void OnEnable()
    {
        _touchInput.Updated += Render;
        _touchInput.ScrollEnded += Clean;
    }

    private void OnDisable()
    {
        _touchInput.Updated -= Render;
        _touchInput.ScrollEnded -= Clean;
    }

    private void Render()
        => Direct(_touchInput.CurrentDelta, _touchInput.CurrentDelta.magnitude);

    private void Clean()
        => Direct(Vector2.zero, 0f);
}
