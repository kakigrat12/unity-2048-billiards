using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Level))]
public class LevelUpdateEventer : MonoBehaviour
{
    private Level _level;
    public event Action<Level> LevelUpped;

    private void Awake()
    {
        _level = GetComponent<Level>();
    }

    private void OnEnable()
    {
        _level.LevelUpped += OnLevelUpped;
    }

    private void OnDisable()
    {
        _level.LevelUpped -= OnLevelUpped;
    }

    private void OnLevelUpped() => LevelUpped?.Invoke(_level);
}
