using UnityEngine;

public class PerlinArrays
{
    // this class contains float arrays to be used as the main parameter by the perlingen class.
    //{width,height,scale,xcoord,ycoord,frequency,lacunarity,persistence,octaves}



    public static float[] BiomeTypes(string biometobuild)  //this is specifically for generating biometypes
    {
        Vector3Int biomecoords = BDataInterpolate.Interpolate(biometobuild, "biomecoords");
        int biomex = biomecoords.x;
        int biomey = biomecoords.y;
        float perlinx = biomex* .1f;
        float perliny = biomey*.1f;
        //this is setting the x and y coordinate values for the perlin generator based on the biome coords, Ex BiomeX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] biometypes = new float[] { 1, 1, 1, perlinx, perliny, 1, 1, .5f, 1 };    //the gen data for biometypes.
        return biometypes;

    }
    public static float[] ChunkTypes(string biometobuild)  //this is specifically for generating chunktypes. Only difference for this data is the size of
        //the float array its returning
    {
        Vector3Int biomecoords = BDataInterpolate.Interpolate(biometobuild, "biomecoords");
        int biomex = biomecoords.x;
        int biomey = biomecoords.y;
        float perlinx = biomex * .1f;
        float perliny = biomey * .1f;
        //this is setting the x and y coordinate values for the perlin generator based on the biome coords, Ex BiomeX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] chunktypes = new float[] { 4, 4, 1, perlinx, perliny, 1, 1, .5f, 1 };    //the gen data for chunktypes.
        return chunktypes;

    }


    public static float[] OverWorld(string biometobuild)
    {
        float seed = PlayerPrefs.GetFloat("seed");
        Vector3Int biomecoords = BDataInterpolate.Interpolate(biometobuild, "biomecoords");
        int biomex = biomecoords.x;
        int biomey = biomecoords.y;
        float perlinx = (biomex * 16.52f)+seed;
        float perliny = (biomey * -16.52f)+seed;
        //this is setting the x and y coordinate values for the perlin generator based on the biome coords, Ex BiomeX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] overworld = new float[] { 128, 128, 1.3f, perlinx, perliny, .5f, 1, .5f, 1 };    //the gen data for overworld generation.
        return overworld;
    }



    public static float[] Elevations(string biometobuild)
    {
        float seed = PlayerPrefs.GetFloat("seed");
        Vector3Int biomecoords = BDataInterpolate.Interpolate(biometobuild, "biomecoords");
        int biomex = biomecoords.x;
        int biomey = biomecoords.y;
        float perlinx = (biomex * 16.52f)+seed;
        float perliny = (biomey * -16.52f)+seed;
        //this is setting the x and y coordinate values for the perlin generator based on the biome coords, Ex BiomeX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] elevations = new float[] { 129, 129, .8f, perlinx, perliny, .3f, 1, .5f, 2 };    //the gen data for overworld generation.
        //the x and y size values are 129 instead of 128 because this will be used to generate elevation values. When assigining these 
        //calues to our mesh vertices, there are 129 vertices to assign instead of 128.
        return elevations;
    }



}
