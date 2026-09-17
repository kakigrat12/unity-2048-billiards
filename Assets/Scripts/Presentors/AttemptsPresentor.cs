using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptsPresentor : MonoBehaviour
{
    [SerializeField] private Loss _loss;
    [SerializeField] private TMP_Text _attempts;

    private void OnEnable()
    {
        _loss.CurrentAttemptsUpdated += Render;
        Render();
    }

    private void OnDisable()
    {
        _loss.CurrentAttemptsUpdated -= Render;
    }

    private void Render()
    {
        _attempts.text = _loss.CurrentAttempts.ToString();
    }
}
