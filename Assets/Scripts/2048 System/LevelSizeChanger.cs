using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSizeChanger : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private AnimationCurve _scale;
    //[SerializeField] private float _scaleFactor = 2f;
    private Vector3 _startScale;

    private void OnEnable()
    {
        _level.LevelUpped += Change;
        _startScale = transform.localScale;
        Change();
    }

    private void OnDisable()
    {
        _level.LevelUpped -= Change;
    }

    private void Change()
    {
        float currentScale = _scale.Evaluate(_level.GetValue());
        transform.localScale = _startScale * currentScale; //Mathf.Pow(_scaleFactor, _level.GetValue() - 1);
        //transform.localScale *= _scaleFactor;
    }
}
