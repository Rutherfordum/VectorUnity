using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public ExampleCube Cube;
    public int Count;
    public UnityObjectPool<ExampleCube> CubePool;

    void Start()
    {
        CubePool = new UnityObjectPool<ExampleCube>(Cube, Count, transform);
    }

    void Update()
    {
        CubePool.SpawnFromPool();
    }
}
