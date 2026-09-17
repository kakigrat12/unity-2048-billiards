using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Puller _puller;
    [SerializeField] private AreaSpawner _spawner;
    public int CurrenValue { get; private set; }
    public Level Biggest { get; private set; }
    public int BallsCount { get; private set; }

    public event Action ValueUpdated;
    public event Action BallsCountUpdated;

    private void OnEnable()
    {
        _puller.Pulled += AddLevelObject;
        _spawner.SpawnedAll += OnStartedSpawnedAll;
    }

    private void OnDisable()
    {
        _puller.Pulled -= AddLevelObject;
        _spawner.SpawnedAll -= OnStartedSpawnedAll;
    }

    public void Reset()
    {
        CurrenValue = 0;
        Biggest = null;
        BallsCount = 0;

        ValueUpdated?.Invoke();
        BallsCountUpdated?.Invoke();
    }

    public bool TryToRemoveBalls(uint count)
    {
        if (BallsCount - (int)count <= 0) return false;

        BallsCount -= (int)count;
        BallsCountUpdated?.Invoke();
        return true;
    }

    private void OnStartedSpawnedAll()
    {
        var spawneds = _spawner.SpawnedObjects;
        foreach (var spawned in spawneds)
            AddLevelObject(spawned);
    }

    private void AddLevelObject()
    {
        var spawned = _puller.LastSpawnedObject;
        AddLevelObject(spawned);
    }

    private void AddLevelObject(Rigidbody2D spawned)
    {
        var levelObject = spawned.GetComponent<LevelUpdateEventer>();
        BallsCount++;
        BallsCountUpdated?.Invoke();

        levelObject.LevelUpped += ChangeValue;
    }

    private void ChangeValue(Level level)
    {
        CheakBiggestLevel(level);
        BallsCount--;
        BallsCountUpdated?.Invoke();

        CurrenValue += (int)Mathf.Pow(2, level.GetValue());
        ValueUpdated?.Invoke();
    }

    private void CheakBiggestLevel(Level level)
    {
        if (Biggest == null || level.GetValue() > Biggest.GetValue())
            Biggest = level;
    }
}
