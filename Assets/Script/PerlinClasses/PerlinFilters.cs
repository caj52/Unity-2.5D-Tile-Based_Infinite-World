using System;
using UnityEngine;

public class PerlinFilters : MonoBehaviour
{
    public static float[,] LayerHeights(float[,] perlinData)
    {
        var perlinDimension = Math.Sqrt(perlinData.Length);
        for (int y = 0; y < perlinDimension; y++) 
        {
            for (int x = 0; x < perlinDimension; x++)
            {
                var maxHeight = HeightMapManager.WorldMaxHeightMultiplier;
                var tileTall = (1 / maxHeight) * 100;
                var entry = Mathf.FloorToInt(perlinData[x,y] * 100);
                if (entry % tileTall != 0)
                    entry += 1;
                perlinData[x,y]=entry/100;
            }
        }
        return perlinData;
    }
}
