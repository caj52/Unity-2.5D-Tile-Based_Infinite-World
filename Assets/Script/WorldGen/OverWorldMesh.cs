using System;
using UnityEngine;
using System.Collections;
public class OverWorldMesh : MonoBehaviour
{
    public static OverWorldMesh instance;

    private static int _meshSize;
    private static Vector3[] _vertices;
    private static int[] _triangles;
    private static Vector2[] _uvs;
    private static GameObject _overWorld;
    private static Mesh _overWorldMesh;
    private void Start()
    {
        instance = this;
    }
    private void InitMeshVariables()
    {
        _meshSize = (int)PerlinArrays.GetHeightMapPerlinArray()[0];
        _vertices = new Vector3[(int)Math.Pow(_meshSize+1,2)];
        _triangles = new int[(int)Math.Pow(_meshSize,2)*6];
        _uvs = new Vector2[_vertices.Length];
        
    }
    public IEnumerator CreateMesh()
    {
        InitMeshVariables();
 
        _overWorld = new GameObject("OverWorld");
        _overWorld.transform.SetParent(transform);
        var meshRenderer = _overWorld.AddComponent<MeshRenderer>();
        _overWorld.AddComponent<MeshCollider>();
        var meshFilter = _overWorld.AddComponent<MeshFilter>();
        meshFilter.mesh = _overWorldMesh = new Mesh();

        for (int x = 0, i = 0; x < _meshSize; x++)
        {
            for (int z = 0; z < _meshSize; z++,i++)
            {
                _vertices[i] = new Vector3(x, 0, z);
                _uvs[i] = new Vector2(x / _meshSize, z / _meshSize);
            }
        }

        var vert = 0;
        var tris = 0;

        for (int x = 0; x < _meshSize-1; x++,vert++)
        {
            for (int z = 0; z < _meshSize-1; z++, vert++,tris+=6)
            {
                _triangles[tris] = vert + 1;
                _triangles[tris + 1] = vert + _meshSize + 1;
                _triangles[tris + 2] = vert;

                _triangles[tris + 3] = vert + _meshSize + 2;
                _triangles[tris + 4] = vert + _meshSize + 1;
                _triangles[tris + 5] = vert + 1;
            }
        }
        _overWorldMesh.vertices = _vertices;
        _overWorldMesh.triangles = _triangles;
        _overWorldMesh.uv = _uvs;
        _overWorldMesh.RecalculateNormals();     

        Debug.Log("Mesh Created");
        yield return null;
    }

    public void ModifyMeshHeightMap(float[,] heightmap) 
    {//Iterates through the OverWorldMesh, modifying the y coordinate of each individual vertex
        var meshVertices = _overWorldMesh.vertices;
        var meshDimension = _meshSize;
        for (int x = 0; x < meshDimension;x++)
        {
            for (int y = 0; y < meshDimension; y++)
            {
                var index = (meshDimension * x) + y;
                meshVertices[index].y = heightmap[x,y];
            }
        }
        _overWorldMesh.vertices = meshVertices;
        _overWorldMesh.RecalculateNormals();
    }

    public static Vector3 GetMeshPosition()
    {
        return _overWorld.transform.position;
    }
    
}