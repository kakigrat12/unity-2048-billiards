using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private float _sensetive = 1f;
    [SerializeField] private float _maxAngel = 70f;
    [SerializeField] private float _minDeltaToActivate = 0.5f;
    [SerializeField] private float _minDelta = 2f;

    public void InverceState(bool value) => Inverce = value;
    public bool Inverce;

    private Vector2 _startPosition;
    public Vector2 CurrentDelta { get; private set; }

    public event Action Updated;
    public event Action ScrollEnded;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _startPosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            CurrentDelta = (_startPosition - (Vector2)Input.mousePosition) * _sensetive * (Inverce ? -1 : 1);
            CurrentDelta = AngelClamp(CurrentDelta, _maxAngel / 2f, Vector2.up);
            CurrentDelta = MagnitudeClamp(CurrentDelta, _minDelta);
            //if (CurrentDelta.magnitude < _minDeltaToActivate) return;

            Updated?.Invoke();
        }

        if (Input.GetMouseButtonUp(0) && CurrentDelta.magnitude >= _minDeltaToActivate)
            ScrollEnded?.Invoke();
    }

    private Vector2 AngelClamp(Vector2 value, float maxAngel, Vector2 direction)
    {
        direction.Normalize();
        float angel = Vector2.SignedAngle(direction, value);

        if (Mathf.Abs(angel) <= maxAngel)
            return value;

        Quaternion rotaion = Quaternion.AngleAxis(maxAngel * Mathf.Sign(angel), Vector3.forward);
        return rotaion * direction * value.magnitude;
    }

    private Vector2 MagnitudeClamp(Vector2 value, float minMagnitude)
    {
        return value.normalized * Mathf.Max(value.magnitude, minMagnitude);
    }
}
