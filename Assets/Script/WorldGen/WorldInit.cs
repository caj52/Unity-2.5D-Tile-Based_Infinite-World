﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldInit : MonoBehaviour
{
    public static WorldInit Instance;
    [SerializeField] private int _worldSize;
    [SerializeField] public int worldSize { get=>_worldSize; } //255 is max size for now

    private void Start()
    {
        Instance = this;
        PerlinArrays.SetPerlinSize(_worldSize);
        TileUVs.Init();
    }
    public IEnumerator CreateWorldMesh()
    {
        Debug.Log("Firing Create Mesh Coroutine");
        StartCoroutine(OverWorldManager.Instance.CreateMesh());


        yield return null;
    }
}
