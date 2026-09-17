using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _wall;
    [Space]
    [Header("Nots")]
    [SerializeField] private AudioClip[] _nots;

    private void OnEnable()
    {
        _level.LevelUpped += OnLevelUpped;
    }

    private void OnDisable()
    {
        _level.LevelUpped -= OnLevelUpped;
    }

    private void OnLevelUpped()
    {
        int currentLevel = _level.GetValue();
        int id = currentLevel % _nots.Length;

        //_audioSource.clip = _nots[id];
        _audioSource.PlayOneShot(_nots[id]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Чтоб играл только один
        float minSpeed = 1.5f;
        if (collision.relativeVelocity.magnitude < minSpeed)
            return;

        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (collision.transform.position.x >= transform.position.x)
                return;
            Hit();
        }
        else
        {
            Wall();
        }
    }

    private void Hit()
    {
        //_audioSource.clip = _hit;
        Debug.Log("HitSound");
        _audioSource.PlayOneShot(_hit);
    }

    private void Wall()
    {
        //_audioSource.clip = _wall;
        Debug.Log("WallHitSound");
        _audioSource.PlayOneShot(_wall);
    }
}
