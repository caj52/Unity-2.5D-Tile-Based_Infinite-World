using UnityEngine;
public class TilesGen
{
    public static string[] localarray=new string[1025];
    public static string[] localarray2;
    public static int cstart;
    public static int smolloop;
    public static int chunkx;
    public static int chunky;
    public static string[] chunkarray;
    public static string[] newarray;
    public static string[] readarray;

    public static void TilesArray(string biometobuild)  /*This creates arrays for each chunk in a biome. Ie: Biome00c1, Biome00c2, up to 16.
                                                        each array contains 256 tile names to be later used by the drawing() method
                                                        these arrays then get stored in playerprefs.*/

    { 
        float[] owperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.OverWorld(biometobuild)));
        cstart=0;
        for (int bigloop=1;bigloop<17;bigloop++)
        {
            if (bigloop>=1&& bigloop < 5)
            {
                cstart = (bigloop - 1) * 32;
            }
            else if (bigloop >= 5 && bigloop < 9)
            {
                cstart = ((bigloop - 5) * 32) + 4096;
            }
            else if (bigloop >= 9 && bigloop < 13)
            {
                cstart= ((bigloop - 9) * 32) + 8192;
            }
            else if (bigloop >= 13 && bigloop <17)
            {
                cstart = ((bigloop - 13) * 32) + 12288;
            }
            smolloop = 0;
            while (smolloop < 1024)
            {
                chunkx = 0;
                while (chunkx < 32)
                {
                    localarray[smolloop] = PerlinInterpolates.Overworld(owperlin[cstart + chunkx]);
                    chunkx++;
                    smolloop++;
                }
                cstart += 128;
            }
            localarray[1024] = biometobuild+"c"+bigloop;
            BData.WriteBData(biometobuild,"CTiles"+bigloop,localarray,null);
        }
    }
    public static void RulesRewrite(string biometobuild)
    {
        for (int bloop=1; bloop<=16; bloop++) {
            chunkarray = BData.ReadBData("CTiles"+bloop);
            newarray=null;
            for (int cloop = 0; cloop < 2048; cloop++)
            {
                if (cloop == 1024)
                {
                    cloop++;
                }
                    newarray=TRulesRedirect.Pick(biometobuild,chunkarray, bloop, cloop);
            }
            BData.WriteBData(biometobuild,"CTiles"+bloop,newarray,null);
        }       
    }
    public static void ElevationsRewrite(string biometobuild)
    {
        float[] owperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.Elevations(biometobuild)));
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
            localarray2 = BData.ReadBData("CTiles" + bigloop);
            for (int smolloop = 0; smolloop < 1024;)
            {
                for (int chunkx=0; chunkx<32;chunkx++)
                {
                    if (PerlinInterpolates.Elevations(owperlin[cstart + chunkx]) != "-1")
                    {
                        localarray2[smolloop] = PerlinInterpolates.Elevations(owperlin[cstart + chunkx]);
                    }
                    smolloop++;
                }
                cstart += 128;
            }
            localarray2[1024] = biometobuild + "c" + bigloop;
            BData.WriteBData(biometobuild,"CTiles"+bigloop,localarray2,null);
        }
    }
}
