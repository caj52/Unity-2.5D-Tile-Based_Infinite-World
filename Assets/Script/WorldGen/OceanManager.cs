using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class OceanManager : MonoBehaviour
{
    public static OceanManager Instance; 
    private static int _meshSize{get => OverWorldMesh._meshSize;}
    public Vector3[] vertices{get => _oceanMesh.vertices;}
    private static GameObject _ocean;
    [SerializeField] private Material oceanMaterial;
    private static Mesh _oceanMesh;
    public Vector2[] meshUVS { get => _oceanMesh.uv; }
    private Material material;

    public float seaLevel = 20;
    // Start is called before the first frame update
    public void Init()
    {
        Instance = this;
    }
    public IEnumerator CreateOceanMesh()
    {
        InitMeshVariables();

        ///////VERTICES CREATION///////////
        var localVertices = new Vector3[(int)(Math.Pow(_meshSize+1, 2))];
        for (int z=0,i=0; z<= _meshSize;z++)
        {
            for (int x=0; x<= _meshSize;x++,i++)
            {
                localVertices[i] = new Vector3(x, seaLevel, z);
            }
        }
        ////////////////////////////////////
        ///////TRIANGLES CREATION///////////
        var localTriangles = new int[(int)Math.Pow(_meshSize,2)*6];
        for (int z =0,tris=0,vert=0; z<_meshSize; z++)
        {
            for (int x = 0; x < _meshSize; x++,tris += 6,vert++)
            {
                localTriangles[tris] = vert;
                localTriangles[tris + 1] = vert + _meshSize+ 1;
                localTriangles[tris + 2] = vert + 1;

                localTriangles[tris + 3] =  vert + 1;
                localTriangles[tris + 4] = vert + _meshSize+ 1;
                localTriangles[tris + 5] = vert + _meshSize+ 2;
            }
        }
        ////////////////////////////////////
        
        _oceanMesh.indexFormat = IndexFormat.UInt32;
        _oceanMesh.vertices = localVertices;
        _oceanMesh.triangles = localTriangles;
        _oceanMesh.RecalculateNormals();
        _oceanMesh.RecalculateBounds();
        _ocean.GetComponent<MeshRenderer>().material = oceanMaterial;
        yield return null;
    }
    private void InitMeshVariables()
    {
        _ocean = new GameObject("Ocean");
        _ocean.transform.SetParent(OverWorldMesh._worldWindow.transform);

        _ocean.AddComponent<MeshRenderer>();

        var meshFilter = _ocean.AddComponent<MeshFilter>();
        meshFilter.mesh = _oceanMesh = new Mesh();

    }
}
