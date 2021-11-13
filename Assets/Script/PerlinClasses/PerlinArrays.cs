using System.Collections.Generic;
using UnityEngine;

public class PerlinArrays : MonoBehaviour
{//////////////////////////////////height&width,          scale,coordx,coordy,frequency,lacunarity,persistance,octaves,amplitude
    private const float UnitCoordinatesBase = 10;
    private const float seed = 420;
    private static float[] _heightMapArray =       { 200f,   .3f,  10f,   10f,     0.1f,        3f,      1.3f,       2f ,    1};
    private static float[] _heightIntensityArray = { 200f,   .5f,  10f,   10f,     0.2f,     .21f,      1.3f,       2f ,    1};
    private static float[] _zonesArray =    { 200f, .005f,          10f,   10f,     2.6f,      2f,      1.2f,       3f ,    1};
    private static float[] _forestObjectArray =    { 200f,      1f, 10f,   10f,     0.18f,      1f,    .44f,       6f,    1};
    private static readonly Dictionary<OverWorldZone, float[]> OverWorldZonePerlinArrays = new Dictionary<OverWorldZone, float[]>
    {
        {OverWorldZone.Forest,_forestObjectArray},
        {OverWorldZone.Sand,_forestObjectArray},
    };
    public static float[] GetHeightMapArray()
    {   
        return _heightMapArray;   
    }   
    public static float[] GetHeightIntensityArray()
    {    
        return _heightIntensityArray;  
    }
    public static float[] GetZonesArray()
    {   
        return _zonesArray;   
    }

    public static float[] GetZoneArrayFromZoneType(OverWorldZone zoneType)
    {
        float[] returnZone = new float[8];
        OverWorldZonePerlinArrays.TryGetValue(zoneType, out returnZone);
        return returnZone;
    }
    public static void SetPerlinSize(int size)
    {
        _heightMapArray[0] = size+1;//these are modifying vertices, so they are larger than the number of tiles
        _heightIntensityArray[0] = size+1;//these are modifying vertices, so they are larger than the number of tiles
        _zonesArray[0] = size+1;
    }
    
    public static void AdjustHeightMapPerlinCoordinates(Vector3 perlinCoordinates)
    {
        perlinCoordinates += new Vector3(seed, 0, seed);
        var heightMapScale = _heightMapArray[1];
        var heightIntensityScale = _heightIntensityArray[1];

         _heightMapArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * heightMapScale;
         _heightMapArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * heightMapScale;
         
         _heightIntensityArray[2] = perlinCoordinates.x/UnitCoordinatesBase* heightIntensityScale;
         _heightIntensityArray[3] = perlinCoordinates.z / UnitCoordinatesBase * heightIntensityScale;
    }
    public static void AdjustZonesPerlinCoordinates(Vector3 perlinCoordinates)
    {
        perlinCoordinates += new Vector3(seed, 0, seed);
        var zoneScale = _zonesArray[1];
        var forestScale = _zonesArray[1];
        
        _zonesArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * zoneScale;
        _zonesArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * zoneScale;
        
        _forestObjectArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * forestScale;
        _forestObjectArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * forestScale;

    }
}
