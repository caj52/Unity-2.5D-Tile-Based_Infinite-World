
using System;
public class NullBiomesCheck       //OPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZE
{
    // Start is called before the first frame update
    public static void CreateNullBiomes(string biometobuild) //this method checks to see if there is biome data in the game files for the biomes surrounding "biometobuild". if there is not, it creates null data. 
        //basically, this is so array scanner doesnt return errors if it tries to read nonexistent biomes later.
    {


        string biomecoords = biometobuild.Substring(5);
        string[] bcoords = biomecoords.Split(',');
        int bcoordx = Convert.ToInt32(bcoords[0].Substring(1));
        int bcoordy = Convert.ToInt32(bcoords[1].Substring(1));
        string[] localarray = new string[513];
        string thisbiome = null;

        BData.WriteBData(biometobuild, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
            localarray[256] = biometobuild + "c" + cloop;
            BData.WriteBData(biometobuild,"CTiles"+cloop,localarray,null);
            }


        if (BData.Exists("BiomeX" + (bcoordx - 1) + ",Y" + (bcoordy + 1))==false)
        {
            thisbiome = "BiomeX" + (bcoordx - 1) + ",Y" + (bcoordy + 1);
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop=1; cloop<17;cloop++) {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }




        if (BData.Exists("BiomeX" + bcoordx + ",Y" + (bcoordy + 1)) == false)
        {
            thisbiome = "BiomeX" + bcoordx + ",Y" + (bcoordy + 1);
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }

        if (BData.Exists("BiomeX" + (bcoordx + 1) + ",Y" + (bcoordy + 1)) == false)
        {
            thisbiome = "BiomeX" + (bcoordx +1) + ",Y" + (bcoordy + 1);
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }

        if (BData.Exists("BiomeX" + (bcoordx - 1) + ",Y" + bcoordy) == false)
        {
            thisbiome = "BiomeX" + (bcoordx - 1) + ",Y" + bcoordy;
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }
        if (BData.Exists("BiomeX" + (bcoordx + 1) + ",Y" + bcoordy) == false)
        {
            thisbiome = "BiomeX" + (bcoordx + 1) + ",Y" + bcoordy;
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }
        if (BData.Exists("BiomeX" + (bcoordx - 1) + ",Y" + (bcoordy - 1)) == false)
        {
            thisbiome = "BiomeX" + (bcoordx - 1) + ",Y" + (bcoordy - 1);
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }
        if (BData.Exists("BiomeX" + bcoordx + ",Y" + (bcoordy - 1)) == false)
        {
            thisbiome = "BiomeX" + bcoordx + ",Y" + (bcoordy - 1);
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }
        if (BData.Exists("BiomeX" + (bcoordx + 1) + ",Y" + (bcoordy - 1)) == false)
        {
            thisbiome = "BiomeX" + (bcoordx + 1) + ",Y" + (bcoordy - 1);
            BData.WriteBData(thisbiome, "BType", null, null);
            for (int cloop = 1; cloop < 17; cloop++)
            {
                for (int cloop2 = 0; cloop2 < 513; cloop2++)
                {
                    localarray[cloop2] = "-1";
                }
                localarray[256] = biometobuild + "c" + cloop;
                BData.WriteBData(thisbiome,"CTiles"+cloop,localarray,null);
            }
        }


    }

}
