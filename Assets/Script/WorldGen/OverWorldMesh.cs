using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class OverWorldMesh : MonoBehaviour
{
    public static OverWorldMesh Instance;
    public static int _meshSize{get; private set; }
    public static Vector3[] vertices{get => _overWorldMesh.vertices;}
    public static Vector4[,] tileHeights {get; private set;}
    public static GameObject _overWorld { get; private set; }
    [SerializeField] private Material overWorldMaterial;
    public static Mesh _overWorldMesh { get; private set; }
    public static GameObject _worldWindow { get; private set; }
    private Material material;
    public static Vector3 worldWindowLastPosition{ get; private set; }
    public void Init()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        OverWorldMeshUtility.RoundWorldWindowPosition();
        
        CheckPositionChangeAndFireUpdateMethods();
        
        SetWorldWindowLastPosition();
    }
    private void UpdateMeshVerts()
    {
        UpdateXAndZAxisVertices();
        HeightMapManager.Instance.UpdateMeshHeightMap();
    }

    private void CheckPositionChangeAndFireUpdateMethods()
    {
        if (!OverWorldMeshUtility.HasPositionChanged())
            return;
        
        UpdateMeshVerts();
        ZoneManager.GenerateNewZonePerlinIfPositionChanged();
        OverWorldTextureManager.Instance.UpdateUVS();
        OverWorldObjectManager.Instance.UpdateOverWorldObjects();
        OverWorldMeshUtility.recaluclateMeshCollider();


    }
    private void InitMeshVariables()
    {
        _meshSize = WorldInit.Instance.worldSize;

        _overWorld = new GameObject("OverWorld");
        _overWorld.transform.SetParent(transform);

        _overWorld.AddComponent<MeshRenderer>();

        var meshFilter = _overWorld.AddComponent<MeshFilter>();
        meshFilter.mesh = _overWorldMesh = new Mesh();

        _worldWindow =  new GameObject("World Window");
        _worldWindow.transform.SetParent(_overWorld.transform);
        var halfMeshSize = _meshSize / 2;
        _worldWindow.transform.position = new Vector3(halfMeshSize, 0, halfMeshSize);
        
        SetWorldWindowLastPosition();
    }
    
    public IEnumerator CreateMesh()
    {
        InitMeshVariables();

        ///////VERTICES CREATION///////////
        var localVertices = new Vector3[(int)(Math.Pow(_meshSize, 2)*4)];
        var mapVerts = _meshSize+1;
        for (int z=0,i=0; z< mapVerts;z++)
        {
            for (int x=0; x< mapVerts;x++,i+=4)
            {
                switch (OverWorldMeshUtility.CheckIfVertexEdgeCase(x,z))
                {
                    case 0://surrounded on all sides
                        localVertices[i] = new Vector3(x, 0, z);
                        localVertices[i + 1] = new Vector3(x, 0, z);
                        localVertices[i + 2] = new Vector3(x, 0, z);
                        localVertices[i + 3] = new Vector3(x, 0, z);
                        break;
                    case 1://corner
                        localVertices[i] = new Vector3(x, 0, z);
                        i-=3;
                        break;
                    case 2://non-corner edges
                        localVertices[i] = new Vector3(x, 0, z);
                        localVertices[i + 1] = new Vector3(x, 0, z);
                        i-=2;
                        break;
                }
            }
        }
        ////////////////////////////////////
        
        ///////TRIANGLES CREATION///////////
        var localTriangles = new int[(int)Math.Pow(_meshSize,2)*6];
        for (int z =0,tris=0; z<_meshSize; z++)
        {
            for (int x = 0; x < _meshSize; x++,tris += 6)
            {
                var trianglesVertices = OverWorldMeshUtility.GetTileTrianglesVertices(x,z);
                localTriangles[tris] = (int)trianglesVertices[0];
                localTriangles[tris + 1] = (int)trianglesVertices[1];
                localTriangles[tris + 2] = (int)trianglesVertices[2];

                localTriangles[tris + 3] = (int)trianglesVertices[2];
                localTriangles[tris + 4] = (int)trianglesVertices[1]; 
                localTriangles[tris + 5] = (int)trianglesVertices[3];
            }
        }
        ////////////////////////////////////
        
        _overWorldMesh.indexFormat = IndexFormat.UInt32;
        
        SetOverWorldVertices(localVertices);
        UpdateXAndZAxisVertices();
        HeightMapManager.Instance.UpdateMeshHeightMap();
        
        _overWorldMesh.triangles = localTriangles;

        OverWorldTextureManager.Instance.Assign_GlobalBuildingUVS();
            
        _overWorldMesh.RecalculateNormals();
        material = _overWorld.GetComponent<MeshRenderer>().material = overWorldMaterial;
        _overWorld.AddComponent<MeshCollider>();
        yield return null;
    }

    public void ModifyMeshHeightMap(float[,] heightmap) 
    {//Iterates through the OverWorldMesh, modifying the y coordinate of each individual vertex
        tileHeights = new Vector4[_meshSize,_meshSize];
        
        var meshVertices = _overWorldMesh.vertices;
        var mapVerts =  _meshSize+1;
        
        for (int z=0,i=0; z< mapVerts;z++)
        {
            for (int x=0; x< mapVerts;x++,i+=4)
            {
                switch (OverWorldMeshUtility.CheckIfVertexEdgeCase(x,z))
                {
                    case 0://surrounded on all sides
                        meshVertices[i].y = heightmap[x,z];
                        meshVertices[i+1].y = heightmap[x,z];
                        meshVertices[i+2].y = heightmap[x,z];
                        meshVertices[i+3].y = heightmap[x,z];
                        break;
                    case 1://corner
                        meshVertices[i].y = heightmap[x,z];
                        i-=3;
                        break;
                    case 2://non-corner edges
                        meshVertices[i].y = heightmap[x,z];
                        meshVertices[i+1].y = heightmap[x,z];
                        i-=2;
                        break;
                }
                
                if(x == mapVerts - 1 || z == mapVerts - 1)
                    continue;
                
                tileHeights[x, z][0] = heightmap[x, z];
                tileHeights[x, z][1] = heightmap[x+1, z];
                tileHeights[x, z][2] = heightmap[x, z+1];
                tileHeights[x, z][3] = heightmap[x+1, z+1];
                
                    
            }
        }

        SetOverWorldVertices(meshVertices);
    }


    public void SetOverWorldUVs()
    {
        _overWorldMesh.uv = OverWorldTextureManager.Instance.GetGlobalBuildingUVS();
        _overWorldMesh.RecalculateNormals();
    }
    public void SetOverWorldTexture(Texture2D overWorldTexture)
    { 
        material = overWorldMaterial;
        material.mainTexture = overWorldTexture;
    }
    public Vector3 GetWorldWindowPosition()
    {
        return _worldWindow.transform.position;
    }
    
    private void UpdateXAndZAxisVertices()
    {
        Vector2Int amountToShift = OverWorldMeshUtility.GetPositionChange();
        ShiftVerticesInOverworldMesh(amountToShift);
    }
    private void ShiftVerticesInOverworldMesh(Vector2Int amountToShift)
    {
        Vector3[] localVertices = _overWorldMesh.vertices;
        int xDifference = amountToShift.x;
        int zDifference = amountToShift.y;

            for (int x = 0,i=0; x < localVertices.Length; x++, i++)
            {
                localVertices[i].x += xDifference;
                localVertices[i].z += zDifference;
            }
            SetOverWorldVertices(localVertices);
    }
    
    private void SetOverWorldVertices(Vector3[] newVertices)
    {
        
        _overWorldMesh.vertices = newVertices;
        _overWorldMesh.RecalculateNormals();
        _overWorldMesh.RecalculateBounds();
        
    }
    public void SetWorldWindowPosition(Vector3 newPosition)
    {
        var oldPosition = _worldWindow.transform.position;
        var position = new Vector3(newPosition.x, oldPosition.y, newPosition.z);
        _worldWindow.transform.position = position;
    }
    public void SetWorldWindowLastPosition()
    {
        var worldWindowPosition = _worldWindow.transform.position;
        worldWindowLastPosition = worldWindowPosition;
    }


    
}