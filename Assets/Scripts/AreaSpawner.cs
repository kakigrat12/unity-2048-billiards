using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [Space]
    [SerializeField] private Rigidbody2D[] _objectsToSpawn;
    [SerializeField] private int _count = 2;
    public Rigidbody2D[] SpawnedObjects { get; private set; }

    public event Action SpawnedAll;

    private void Start()
    {
        SpawnAll();
    }

    public void SpawnAll()
    {
        SpawnedObjects = Spawn(_count);
        SpawnedAll?.Invoke();
    }

    private Rigidbody2D[] Spawn(int count)
    {
        Rigidbody2D[] spawneds = new Rigidbody2D[count];

        for (int i = 0; i < count; i++)
            spawneds[i] = Spawn();

        return spawneds;
    }

    private Rigidbody2D Spawn()
    {
        var objectToSpawn = GetRandomObjectToSpawn();
        Vector2 position = GetRandomPosition();

        var spawned = Instantiate(objectToSpawn, position, Quaternion.identity, _container);
        return spawned;
    }

    private Rigidbody2D GetRandomObjectToSpawn()
    {
        int id = Random.Range(0, _objectsToSpawn.Length);
        return _objectsToSpawn[id];
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 areaSize = transform.localScale;
        float halfX = areaSize.x / 2f;
        float halfY = areaSize.y / 2f;

        Vector2 position = transform.position;
        float maxX = position.x + halfX;
        float minX = position.x - halfX;
        float maxY = position.y + halfY;
        float minY = position.y - halfY;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}
