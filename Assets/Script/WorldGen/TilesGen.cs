using UnityEngine;
public class TilesGen
{
    public static int[] localarray = new int[16384];
    public static int cstart;
    public static int smolloop;
    public static int chunkx;
    public static int chunky;
    public static string[] chunkarray;
    public static string[] newarray;
    public static string[] readarray;

    public static int[] InitZoneBase(string zonetobuild)  /*This creates arrays for each chunk in a zone. Ie: zone00c1, zone00c2, up to 16.
                                                        each array contains 256 tile names to be later used by the drawing() method
                                                        these arrays then get logged to ZData.*/
    {
        float[] biomeperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.ZoneBiomes(zonetobuild)));
        float[] subtypeperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.ZoneSubTypes(zonetobuild)));
        int tempnum;
        cstart =0;
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
                    localarray[smolloop] = PerlinInterpolates.BiomeTiles(biomeperlin[cstart + chunkx]);
                    tempnum = PerlinInterpolates.ZoneSubTypes(subtypeperlin[cstart + chunkx], localarray[cstart + chunkx]);
                    if (tempnum!=-1)//this prevents redundant changes from being made, as -1 is set when there is no change in this instance.
                    {//this is not to be confused with a -1 in the buildhelper, which indicates a null entry.
                        localarray[smolloop] = PerlinInterpolates.ZoneSubTypes(subtypeperlin[cstart + chunkx], localarray[cstart + chunkx]);
                    }
                    chunkx++;
                    smolloop++;
                }
                cstart += 128;
            }
            //ZData.CommitToBuildHelper(localarray);
        }
        return localarray;
    }
  /*  public static void RulesRewrite(string zonetobuild)
    {
        for (int bloop=1; bloop<=16; bloop++) {
            chunkarray = ZData.ReadZData("CTiles"+bloop);
            newarray=null;
            for (int cloop = 0; cloop < 2048; cloop++)
            {
                if (cloop == 1024)
                {
                    cloop++;
                }
                    newarray=TRulesRedirect.Pick(zonetobuild,chunkarray, bloop, cloop);
            }
            ZData.WriteZData(zonetobuild,"CTiles"+bloop,newarray,null);
        }       
    }
   /* public static void ElevationsRewrite(string zonetobuild)
    {
        float[] owperlin = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.Elevations(zonetobuild)));
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
            localarray2 = ZData.ReadZData("CTiles" + bigloop);
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
            localarray2[1024] = zonetobuild + "c" + bigloop;
            ZData.WriteZData(zonetobuild,"CTiles"+bigloop,localarray2,null);
        }
    }
   */
}
