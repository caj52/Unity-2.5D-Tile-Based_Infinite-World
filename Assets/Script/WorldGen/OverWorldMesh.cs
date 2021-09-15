using UnityEngine;
using System.Collections;
public class OverWorldMesh : MonoBehaviour
{
    public static OverWorldMesh instance;

    private static Vector2Int _meshSize = new Vector2Int(64,64);
    private static Vector3[] _vertices = new Vector3[(_meshSize.x + 1) * (_meshSize.y + 1)];
    private static int[] _triangles = new int[_meshSize.x * _meshSize.y * 6];
    private static Vector2[] _uvs = new Vector2[_vertices.Length];
    private static GameObject _overWorld;
    private static Mesh _overWorldMesh;

    private void Start()
    {
        instance = this;
    }
    public IEnumerator CreateMesh()
    {
        _overWorld = new GameObject("OverWorld");
        _overWorld.transform.SetParent(transform);
        var meshRenderer = _overWorld.AddComponent<MeshRenderer>();
        _overWorld.AddComponent<MeshCollider>();
        var meshFilter = _overWorld.AddComponent<MeshFilter>();
        meshFilter.mesh = _overWorldMesh = new Mesh();

        for (int x = 0, i = 0; x < _meshSize.x; x++)
        {
            for (int z = 0; z < _meshSize.y; z++,i++)
            {
                _vertices[i] = new Vector3(x, 0, z);
                _uvs[i] = new Vector2(x / _meshSize.x, z / _meshSize.y);
            }
        }

        var vert = 0;
        var tris = 0;

        for (int x = 0; x < _meshSize.x-1; x++,vert++)
        {
            for (int z = 0; z < _meshSize.y-1; z++, vert++,tris+=6)
            {
                _triangles[tris] = vert + 1;
                _triangles[tris + 1] = vert + _meshSize.x + 1;
                _triangles[tris + 2] = vert;

                _triangles[tris + 3] = vert + _meshSize.x + 2;
                _triangles[tris + 4] = vert + _meshSize.x + 1;
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
        var meshDimension = _meshSize.x;
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

    void OnDrawGizmos()
    {
        if (_overWorldMesh!=null)
        {
            Gizmos.color = Color.red; 
            Gizmos.DrawSphere(_overWorldMesh.vertices[0] + _overWorld.transform.position, .1f); 
        }

    }

}