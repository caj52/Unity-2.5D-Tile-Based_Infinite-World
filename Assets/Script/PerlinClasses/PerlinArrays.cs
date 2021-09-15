using UnityEngine;

public class PerlinArrays : MonoBehaviour
{//////////////////////////////////width,height,scale,coordx,coordy,frequency,lacunarity,persistance,octaves,amplitude
    private const float UnitCoordinatesBase = 10;
    private static float[] _heightMapArray =       { 64, 64, 1.2f, 0, 0, 0.3f, 1, .5f, 2 };
    private static float[] _heightIntensityArray = { 64, 64, .8f, 0, 0, 0.1f, 1.15f, 1.25f, 4 };
    public static float[] GetHeightMapPerlinArray()
    {   
        return _heightMapArray;   
    }   
    public static float[] GetHeightIntensityPerlinArray()
    {    
        return _heightIntensityArray;  
    }
    public static void AdjustHeightMapPerlinCoordinates(Vector3 perlinCoordinates)
    {
        var heightMapScale = _heightMapArray[2];
        //var heightIntensityScale = _heightIntensityArray[2];

         _heightMapArray[3] = perlinCoordinates.x/ UnitCoordinatesBase * heightMapScale;
        //HeightIntensityArray[3] = perlinCoordinates.x/10* heightIntensityScale;

        _heightMapArray[4] = perlinCoordinates.z/ UnitCoordinatesBase * heightMapScale;
        //HeightIntensityArray[4] = perlinCoordinates.z / 10 * heightIntensityScale;
    }
}
