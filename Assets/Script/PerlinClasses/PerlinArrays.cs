using UnityEngine;

public class PerlinArrays : MonoBehaviour
{//////////////////////////////////height&width,scale,coordx,coordy,frequency,lacunarity,persistance,octaves,amplitude
    private const float UnitCoordinatesBase = 10;
    private static float[] _heightMapArray =       { 0, .3f, 0, 0, 0.1f, 3, .7f, 2 };
    private static float[] _heightIntensityArray = { 0, .2f, 0, 0, 0.1f, 1.15f, 1.25f, 4 };
    public static float[] GetHeightMapPerlinArray()
    {   
        return _heightMapArray;   
    }   
    public static float[] GetHeightIntensityPerlinArray()
    {    
        return _heightIntensityArray;  
    }

    public static void SetPerlinSize(int size)
    {
        _heightMapArray[0] = size;
        _heightIntensityArray[0] = size;
    }
    
    public static void AdjustHeightMapPerlinCoordinates(Vector3 perlinCoordinates)
    {
        var heightMapScale = _heightMapArray[1];
        var heightIntensityScale = _heightIntensityArray[1];

         _heightMapArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * heightMapScale;
         _heightIntensityArray[2] = perlinCoordinates.x/10* heightIntensityScale;

        _heightMapArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * heightMapScale;
        _heightIntensityArray[3] = perlinCoordinates.z / 10 * heightIntensityScale;
    }
}
