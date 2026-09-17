using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullerPresentor : MonoBehaviour
{
    [SerializeField] private RandomPuller _pullerPresentor;
    [SerializeField] private SettableLevel _settableLevel;

    private void OnEnable()
    {
        _pullerPresentor.Chosen += Render;
    }

    private void OnDisable()
    {
        _pullerPresentor.Chosen -= Render;
    }

    private void Render()
    {
        _settableLevel.SetLevel(_pullerPresentor.Forthcoming.Level.GetValue());
    }
}
