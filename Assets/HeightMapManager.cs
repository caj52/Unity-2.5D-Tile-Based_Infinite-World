using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapManager : MonoBehaviour
{
    private static float worldMaxHeightMultiplier =10;

    private static void UpdateMeshHeightMap() 
    {
        var heightPerlinArray = PerlinArrays.GetHeightMapPerlinArray();
        var heightMap = PerlinGen.Generate(heightPerlinArray);
        heightMap = ApplyIntensityToHeightMap(heightMap);
        OverWorldMesh.Instance.ModifyMeshHeightMap(heightMap);
    
    }

    public void Start() 
    {
        UpdateMeshHeightMap();
    }

    private static float[,] ApplyIntensityToHeightMap(float[,] _startingHeightMap)
    {
        var newHeightMap = _startingHeightMap;
        var heightMapDimension = Mathf.Sqrt(newHeightMap.Length);
        var intensityPerlinArray = PerlinArrays.GetHeightIntensityPerlinArray();
        var intensityMap = PerlinGen.Generate(intensityPerlinArray);

        for (int x=0,y=0;x< heightMapDimension; x++)
        {
            newHeightMap[x,y] *=intensityMap[x,y]* worldMaxHeightMultiplier;
            if (x == heightMapDimension) { y++; }
        }

        return newHeightMap;
    }
}
