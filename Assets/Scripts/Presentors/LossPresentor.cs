using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossPresentor : MonoBehaviour
{
    [SerializeField] private Loss _loss;
    [SerializeField] private Counter _counter;
    [SerializeField] private Record _record;
    [Space]
    [SerializeField] private float _timeToCountdown = 3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _adsPanel;
    [SerializeField] private GameObject _adsRecordPanel;
    [Space]
    [SerializeField] private float _partOfRecord = 0.7f;
    [SerializeField] private float _probabilityInPart = 1f;
    [SerializeField] private float _probabilityOutPart = 0.6f;
    private Coroutine _currentWaiter;

    private float _probabilityInPartS;
    private float _probabilityOutPartS;

    private void OnEnable()
    {
        Reset();

        _loss.AttemptsOver += OnAttemptsOver;
        _loss.Losed += ChosePanel;
        _loss.CountdownCanceled += CancleCountdown;
    }

    private void OnDisable()
    {
        _loss.AttemptsOver -= OnAttemptsOver;
        _loss.Losed -= ChosePanel;
        _loss.CountdownCanceled -= CancleCountdown;
    }

    public void Reset()
    {
        _probabilityInPartS = _probabilityInPart;
        _probabilityOutPartS = _probabilityOutPart;
    }

    private void OnAttemptsOver()
    {
        float time = _loss.TimeToWait - _timeToCountdown;
        _currentWaiter = StartCoroutine(Wait(time));
    }

    private void CancleCountdown()
    {
        StopCoroutine(_currentWaiter);
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        _animator.SetTrigger("Start");
        Debug.Log("End");
    }

    private void ChosePanel()
    {
        float partOfRecord = _counter.CurrenValue / _record.LastValue;

        if (partOfRecord >= _partOfRecord)
        {
            if (partOfRecord < 1)
            {
                ShowPanelsWithProbability(_losePanel, _adsRecordPanel, _probabilityInPartS);
                _probabilityInPartS /= 2;
                _probabilityOutPartS /= 2;
            }
            else
            {
                ShowPanelsWithProbability(_losePanel, _adsPanel, _probabilityOutPartS);
                _probabilityInPartS /= 2;
                _probabilityOutPartS /= 2;
            }
        }
        else
        {
            ShowPanelsWithProbability(_losePanel, _adsPanel, _probabilityOutPartS);
            _probabilityInPartS /= 2;
            _probabilityOutPartS /= 2;
        }
    }

    private void ShowPanelsWithProbability(GameObject negative, GameObject positive, float probability)
    {
        float curremtProbability = Random.value;
        if (curremtProbability <= probability)
        {
            positive.SetActive(true);
        }
        else
        {
            negative.SetActive(true);
        }
    }
}
