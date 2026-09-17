
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerTraining : MonoBehaviour
{
    private delegate void Slide();
    private Slide[] _slides = new Slide[5];
    private int _currentSlide;

    [SerializeField] private GameObject _panel1;
    [SerializeField] private GameObject _panel2;
    [SerializeField] private GameObject _panel3;
    [SerializeField] private GameObject _panel4;
    [Space]
    [SerializeField] private TouchInput _input;
    [SerializeField] private Record _record;
    private float _timeToWait = 1.4f;

    private void Awake()
    {
        _slides[0] = Slide1;
        _slides[1] = PreSlide2;
        _slides[2] = PreSlide3;
        _slides[3] = PreSlide4;
        _slides[4] = Stop;

        _record.Updated += OnRecordLoaded;
    }

    private void OnRecordLoaded()
    {
        if (_record.LastValue == 0)
        {
            StartTraining();
        }
        else
        {
            enabled = false;
        }

        _record.Updated -= OnRecordLoaded;
    }

    public void StartTraining()
    {
        _input.ScrollEnded += PreSlide2;

        Slide1();
        _currentSlide = 0;
    }

    public void Next() => TryToNext();

    public bool TryToNext()
    {
        if (!enabled) return false;

        if (_currentSlide >= _slides.Length - 1)
        {
            _slides[_currentSlide]();
            return false;
        }

        _slides[++_currentSlide]();
        return true;
    }

    //Слайды

    private void Slide1()
    {
        _panel1.SetActive(true);
    }

    private void PreSlide2()
    {
        var animator = _panel1.GetComponent<Animator>();
        animator.SetTrigger("End");
        Invoke(nameof(Slide2), _timeToWait);
    }

    private void Slide2()
    {
        _currentSlide = 1;

        _input.enabled = false;
        _panel1.SetActive(false);
        _panel2.SetActive(true);

        _input.ScrollEnded -= PreSlide2;
    }

    private void PreSlide3()
    {
        float time = 0.5f;
        Invoke(nameof(Slide3), time);
    }

    private void Slide3()
    {
        _panel2.SetActive(false);
        _panel3.SetActive(true);
    }

    private void PreSlide4()
    {
        float time = 0.5f;
        Invoke(nameof(Slide4), time);
    }

    private void Slide4()
    {
        _panel3.SetActive(false);
        _panel4.SetActive(true);
    }

    private void Stop()
    {
        _input.enabled = true;
        _panel4.SetActive(false);
    }
}
