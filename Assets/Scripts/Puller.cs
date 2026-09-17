using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puller : MonoBehaviour
{
    [SerializeField] private Transform _container;
    public Rigidbody2D LastSpawnedObject { get; private set; }
    public event Action Pulled;

    public abstract void Pull(Vector2 force);

    protected void Push(Rigidbody2D rigidbody, Vector2 force)
    {
        rigidbody.AddForce(force, ForceMode2D.Impulse);

        Pulled?.Invoke();
    }

    protected void Spawn(Rigidbody2D rigidbody)
    {
        LastSpawnedObject = Instantiate(rigidbody, transform.position, Quaternion.identity, _container);
    }
}
