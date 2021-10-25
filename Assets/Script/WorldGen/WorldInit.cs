using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldInit : MonoBehaviour
{
    public static WorldInit Instance;
    [SerializeField] private int _worldSize;
    [SerializeField] public int worldSize { get=>_worldSize; }
    
    public void Init()
    {
        Instance = this;
        PerlinArrays.SetPerlinSize(_worldSize);
    }
    public IEnumerator CreateWorldMesh()
    {
        Debug.Log("Firing Create Mesh Coroutine");
        StartCoroutine(OverWorldMesh.Instance.CreateMesh());


        yield return null;
    }
    
}
