using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPuller : Puller
{
    [SerializeField] private Ball[] _prefabs;
    public Ball Forthcoming { get; private set; }
    //public Level ForthcomingLevel => Forthcoming.Level;

    public event Action Chosen;

    private void Start()
    {
        ChoseNextBall();
    }

    public override void Pull(Vector2 force)
    {
        if (!enabled) return;

        var rigidbody = Forthcoming.Rigidbody;
        Spawn(rigidbody);
        Push(LastSpawnedObject, force);

        ChoseNextBall();
    }

    private void ChoseNextBall()
    {
        Forthcoming = GetRandomPrefap();
        Chosen?.Invoke();
    }

    private Ball GetRandomPrefap()
    {
        int id = UnityEngine.Random.Range(0,_prefabs.Length);
        return _prefabs[id];
    }
}
