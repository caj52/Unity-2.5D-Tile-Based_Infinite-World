using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HeightMapManager : MonoBehaviour
{
    public const float WorldMaxHeightMultiplier =50;//this designates the highest possible elevation
    public static HeightMapManager Instance;
    public void Init()
    {
        Instance = this;
    }
    
    public void UpdateMeshHeightMap() 
    {
        var meshPosition = OverWorldMesh.Instance.GetWorldWindowPosition();
        PerlinArrays.AdjustHeightMapPerlinCoordinates(meshPosition);

        var heightPerlinArray = PerlinArrays.GetHeightMapArray();
        
        var heightMap = PerlinGen.Generate(heightPerlinArray);

        heightMap = ApplyIntensityToHeightMap(heightMap);
        heightMap=PerlinFilters.LayerHeights(heightMap);
        
        OverWorldMesh.Instance.ModifyMeshHeightMap(heightMap);
    }
    private static float[,] ApplyIntensityToHeightMap(float[,] startingHeightMap)
    {
        var newHeightMap = startingHeightMap;

        var mapVerts = Math.Sqrt(newHeightMap.Length);
        
        var intensityPerlinArray = PerlinArrays.GetHeightIntensityArray();
        var intensityMap = PerlinGen.Generate(intensityPerlinArray);
        
        for (int z=0; z< mapVerts;z++)
        {
            for (int x=0; x< mapVerts;x++)
            {
                newHeightMap[x, z] *= intensityMap[x, z] * WorldMaxHeightMultiplier;
            }
        }
        return newHeightMap;
    }
}
