using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int Value = 1;
    public int GetValue() => Value;
    protected void SetValue(int value) => Value = value;

    public event Action LevelUpped;

    public void LevelUp()
    {
        Value += 1;
        LevelUpped?.Invoke();
    }
}
