using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class OverWorldMesh : MonoBehaviour
{
    public static OverWorldMesh Instance;

    private static Vector2Int meshSize = new Vector2Int(64,64);
    private static Vector3[] vertices = new Vector3[(meshSize.x + 1) * (meshSize.y + 1)];
    private static int[] triangles = new int[meshSize.x * meshSize.y * 6];
    private static Vector2[] uvs = new Vector2[vertices.Length];
    private static GameObject overWorld;

    private void Start()
    {
        Instance = this;
    }
    public IEnumerator CreateMesh()
    {
        overWorld = new GameObject("OverWorld");
        overWorld.transform.SetParent(transform);
        var meshRenderer = overWorld.AddComponent<MeshRenderer>();
        overWorld.AddComponent<MeshCollider>();
        var meshFilter = overWorld.AddComponent<MeshFilter>();
        var overworldMesh = new Mesh();
        meshFilter.mesh = overworldMesh;

        for (int x = 0, i = 0; x <= meshSize.x; x++)
        {
            for (int z = 0; z >= -meshSize.y; z--,i++)
            {
                vertices[i] = new Vector3(x, 0, z);
                uvs[i] = new Vector2(x / meshSize.x, z / -meshSize.y);
            }
        }

        var vert = 0;
        var tris = 0;

        for (int x = 0; x < meshSize.y; x++,vert++)
        {
            for (int z = 0; z < meshSize.x; z++, vert++,tris+=6)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + meshSize.x + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + meshSize.x + 1;
                triangles[tris + 5] = vert + meshSize.x + 2;
            }
        }
        overworldMesh.vertices = vertices;
        overworldMesh.triangles = triangles;
        overworldMesh.uv = uvs;
        overworldMesh.RecalculateNormals();     

        Debug.Log("Mesh Created");
        yield return null;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        for (int i = 0; i< vertices.Length; i++) 
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }

        
    }

}