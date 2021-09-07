using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneElevationsCalculator : MonoBehaviour
{
    // the nested method class of shame
    public static float[,] GenElevation(string biometobuild)
    {
        float[,] elevation=null;

        elevation = GroundLevels.Filter(PerlinGen.Generate(PerlinArrays.Elevations(biometobuild)));
        return elevation;
    }
}
