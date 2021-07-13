using UnityEngine;

public class WorldStuff : MonoBehaviour
{
    public static int cstart;
    public static float[] typesperlin;
    public static float[] biomesperlin;
    public static string tiletype;
    public static void Objects_ZoneSubTypes(string zonetobuild)
    {
        typesperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.ZoneSubTypes(zonetobuild)));
        biomesperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.ZoneBiomes(zonetobuild)));
        cstart = 0;
        for (int bigloop = 1; bigloop <= 16; bigloop++)
        {
            if (bigloop >= 1 && bigloop < 5)
            {
                cstart = (bigloop - 1) * 32;
            }
            else if (bigloop >= 5 && bigloop < 9)
            {
                cstart = ((bigloop - 5) * 32) + 4096;
            }
            else if (bigloop >= 9 && bigloop < 13)
            {
                cstart = ((bigloop - 9) * 32) + 8192;
            }
            else if (bigloop >= 13 && bigloop < 17)
            {
                cstart = ((bigloop - 13) * 32) + 12288;
            }
            for (int smolloop = 0; smolloop < 1024;)
            {
                for (int chunkx = 0; chunkx < 32; chunkx++)
                {                   
                    smolloop++;
                   // tiletype=PerlinInterpolates.ZoneSubTypes(typesperlin[cstart+chunkx], biomesperlin[cstart + chunkx],false);//Returns "GrassT~GrassyPlain" or something similiar
                    ZoneTypeObjectMethodRedirect(tiletype);
                }
                cstart += 128;
            }
        }
    }

    public static void ZoneTypeObjectMethodRedirect(string tiletype)
    {



    }

}