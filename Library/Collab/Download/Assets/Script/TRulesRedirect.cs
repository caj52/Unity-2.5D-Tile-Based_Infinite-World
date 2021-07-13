
using UnityEngine;

public class TRulesRedirect
{
    //this method redirects to the appropriate tilerules class based on the string identifier obtained from TileRules
    public static string[] Pick(string biometobuild,string[] thischunk,int chunknum,int centerinarray)
    {
        string[] newarray =thischunk;
        if (thischunk[centerinarray] == "157")//water
        {
           string[] scanresults = ArrayScanner.Tiles(thischunk, Mathf.FloorToInt(centerinarray / 257), centerinarray, true);
           newarray = WaterTRules.Mod(biometobuild,scanresults, thischunk, chunknum, centerinarray);
        }
        
        return newarray;

    }
}
