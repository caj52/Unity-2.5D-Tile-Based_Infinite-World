using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WorldInit : MonoBehaviour
{
    public static WorldInit Instance;
    private void Start()
    {
        Instance = this;
    }
    public IEnumerator CreateWorldMesh()
    {
        Debug.Log("Firing Create Mesh Coroutine");
        StartCoroutine(OverWorldMesh.instance.CreateMesh());


        yield return null;
    }
}
