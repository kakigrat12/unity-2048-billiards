using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwicherButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _on;
    [SerializeField] private Color _off;
    private Coroutine _currentAnimatior;
    [SerializeField] private bool _isOn = false;

    public UnityEvent On;
    public UnityEvent Off;

    private void Start()
    {
        _isOn = !_isOn;
        Swich();
    }

    public void Swich()
    {
        Debug.Log("Swich");
        _isOn = !_isOn;
        if (_isOn)
        {
            ChangeCollorTo(_on);
            On?.Invoke();
        }
        else
        {
            ChangeCollorTo(_off);
            Off?.Invoke();
        }
    }

    private void ChangeCollorTo(Color color)
    {
        if (_currentAnimatior is not null)
            StopCoroutine(_currentAnimatior);

        _currentAnimatior = StartCoroutine(AnimationColor(color));
    }

    private IEnumerator AnimationColor(Color color)
    {
        float speed = 10f;
        while (_image.color != color)
        {
            Debug.Log("color");
            var currentColor = Color.Lerp(_image.color, color, speed * Time.deltaTime);
            _image.color = currentColor;
            yield return null;
        }
    }
}
