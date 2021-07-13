public class PerlinInterpolates
{
    public static float sealevel = .15f;
    // this is the class for converting specific float entries, obtained from perlin gen, to strings.

    public static string BiomeTypes(float perlinnum){ //this method is specifically for biometypes.
        string type = null;

        if (perlinnum > 0 && perlinnum < 1)
        {
            type = "grass";
        }
        return type;
        }


    public static string ChunkTypes(float perlinnum) //this method is specifically for chunk types
    {
        string type = null;

        if (perlinnum > 0 && perlinnum < 1)
        {
            type = "plain";
        }



        return type;
    }


    public static string Overworld(float perlinnum)
    {
        string tile= null;

        if (perlinnum < .4f)
        {
            tile = "19";//lightgrass3
        }
        else 
        {
            tile = "17";//lightgrass1
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
}
