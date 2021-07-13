public class PerlinInterpolates
// this is the class for converting specific float entries, obtained from perlin gen, to strings.
{
    public static float sealevel = .15f;

    public static int ZoneSubTypes(float subtypenum,float biomenum)
    { //the processes required for this is so dense that i just put it in its own class
        int newint;
        string biometype = BiomeNames(biomenum);
        newint = ZoneSubTypePerlinInterpolator(biometype, subtypenum);
        return newint;
    }


    public static int BiomeTiles(float perlinnum) //this method is specifically for biome types
    {
        int tile = -1;

        if (perlinnum > .5f)
        {
            tile = 17;//GrassBiome
        }
        if (perlinnum <=.5f)
        {
            tile = 157;//OceanBiome
        }

        return tile;
    }
    public static string BiomeNames(float perlinnum) //this method is specifically for biome types
    {
        string tile = null;

        if (perlinnum > .5f)
        {
            tile = "Grass_Plain";
        }
        if (perlinnum <= .5f)
        {
            tile = "Ocean_Default";
        }



        return tile;
    }
    public static string ZoneSubTypeNames(string biometype, float zsubtype)
    {
        string tile = null;

        if (biometype.Contains("Grass"))
        {
            //this is where we determine the subtypes, we can return any kind of tile from here;
            if (zsubtype <= .2f)//Forest
            {
                tile = "Forest";

            }
            if (zsubtype > .2f)//GrassyPlain
            {
                tile = "GrassyPlain";

            }


        }

        if (biometype.Contains("Ocean"))
        {
            if (zsubtype > 0)
            {
                tile = "Default";

            }
        }

        return tile;
    }

    public static string Elevations(float perlinnum)
    {
        string tile = null;

        if (perlinnum < sealevel)//water
        {
            tile = "157";
        }
        else
        {
            tile = "-1";
        }

        return tile;
    }

    public static int ZoneSubTypePerlinInterpolator(string biometype,float zsubtype)
    {//this compares the biome data to determine what subtype the zsubtype float will end up becoming. 
        int tile=-1;

        if (biometype.Contains("Grass"))
        {
            //this is where we determine the subtypes, we can return any kind of tile from here;
            if (zsubtype<=.4f)//Forest
            {
                tile =22;

            }
            if (zsubtype > .4f)//GrassyPlain
            {
                tile = -1;

            }


        }

        if (biometype.Contains("Ocean"))
        {
            if (zsubtype>0)
            {
                tile = -1;
            }
        }

            return tile;
    }
}
