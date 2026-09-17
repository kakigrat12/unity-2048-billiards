using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private Remover _remover;

    public Level Level => _level;
    public Rigidbody2D Rigidbody => _rigidbody;
    public CircleCollider2D Collider => _collider;
    public Remover Remover => _remover;
}
