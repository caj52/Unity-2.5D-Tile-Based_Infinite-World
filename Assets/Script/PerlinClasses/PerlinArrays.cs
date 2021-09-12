using UnityEngine;

public class PerlinArrays : MonoBehaviour
{//////////////////////////////////width,height,scale,coordx,coordy,frequency,lacunarity,persistance,octaves,amplitude
    private static readonly float[] HeightMapArray = { 64, 64, 1.2f, 0, 0, 0.3f, 1, .5f, 2 };
    private static readonly float[] HeightIntensityArray = { 64, 64, .8f, 0, 0, 0.1f, 1.15f, 1.25f, 4 };
    public static float[] GetHeightMapPerlinArray()
    {   
        return HeightMapArray;   
    }   
    public static float[] GetHeightIntensityPerlinArray()
    {    
        return HeightIntensityArray;  
    }
}
