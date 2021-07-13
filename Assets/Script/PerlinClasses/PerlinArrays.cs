using UnityEngine;

public class PerlinArrays
{
    // this class contains float arrays to be used as the main parameter by the perlingen class.
    //{width,height,scale,xcoord,ycoord,frequency,lacunarity,persistence,octaves}
    public static float offsetnum;


    public static float[] ZoneSubTypes(string zonetobuild)  //this is specifically for generating zonetypes
    {
        float seed = PlayerPrefs.GetFloat("seed");
        offsetnum = .1f;
        Vector3Int zonecoords = ZDataInterpolate.Interpolate(zonetobuild, "zonecoords");
        int zonex = zonecoords.x;
        int zoney = zonecoords.y;
        float perlinx = zonex* offsetnum + seed;
        float perliny = zoney*offsetnum + seed;
        //this is setting the x and y coordinate values for the perlin generator based on the zone coords, Ex zoneX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] zonetypes = new float[] { 128, 128, .11f, perlinx, perliny, 1, 1, .5f, 1 };    //the gen data for zonetypes.
        return zonetypes;

    }
    public static float[] ZoneBiomes(string zonetobuild)  //this is specifically for generating chunktypes. Only difference for this data is the size of
        //the float array its returning
    {
        float seed = PlayerPrefs.GetFloat("seed");
        offsetnum = .1f;
        Vector3Int zonecoords = ZDataInterpolate.Interpolate(zonetobuild, "zonecoords");
        int zonex = zonecoords.x;
        int zoney = zonecoords.y;
        float perlinx = zonex * offsetnum+seed;
        float perliny = zoney * offsetnum+seed;
        //this is setting the x and y coordinate values for the perlin generator based on the zone coords, Ex zoneX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] chunktypes = new float[] { 128, 128, .1f, perlinx, perliny, .03f, 1, -1.85f, 5 };    //the gen data for chunktypes.
        return chunktypes;

    }


    public static float[] OverWorld(string zonetobuild)
    {
        float seed = PlayerPrefs.GetFloat("seed");
        Vector3Int zonecoords = ZDataInterpolate.Interpolate(zonetobuild, "zonecoords");
        int zonex = zonecoords.x;
        int zoney = zonecoords.y;
        offsetnum = 16.64f; //this number is exqual to the array size, 128, multiplied by the scale, 1.3. then divided by 10.
        float perlinx = (zonex * offsetnum) +seed;
        float perliny = (zoney * -offsetnum) +seed;
        //this is setting the x and y coordinate values for the perlin generator based on the zone coords, Ex zoneX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] overworld = new float[] { 128, 128, 1.3f, perlinx, perliny, .5f, 1, .5f, 1 };    //the gen data for overworld generation.
        return overworld;
    }



    public static float[] Elevations(string zonetobuild)
    {
        float seed = PlayerPrefs.GetFloat("seed");
        Vector3Int zonecoords = ZDataInterpolate.Interpolate(zonetobuild, "zonecoords");
        int zonex = zonecoords.x;
        int zoney = zonecoords.y;
        offsetnum = 10.32f;
        float perlinx = (zonex * offsetnum) +seed;
        float perliny = (zoney * -offsetnum) +seed;
        //this is setting the x and y coordinate values for the perlin generator based on the zone coords, Ex zoneX0Y1
        //would result in a perlin x coordinate of 0 and a y coordinate of .1.

        float[] elevations = new float[] { 129, 129, .1f, perlinx, perliny, .3f, 1, .5f, 2 };    //the gen data for overworld generation.
        //the x and y size values are 129 instead of 128 because this will be used to generate elevation values. When assigining these 
        //calues to our mesh vertices, there are 129 vertices to assign instead of 128.
        return elevations;
    }



}
