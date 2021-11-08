
using UnityEngine;
public enum OverWorldZone
{
    None,
    Forest,
    Sand
}

public static class ZoneTypes
{
    public static OverWorldZone GetZoneTypeFromPerlinData(float perlinData)
    {
        OverWorldZone returnZone;
        
        if (perlinData<.5f)
        {
            returnZone = OverWorldZone.Sand;
        }
        else
        {
            returnZone = OverWorldZone.Forest;
        }
        

        return returnZone;
    }
    
}
