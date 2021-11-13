
using System.Collections.Generic;
using UnityEngine;
public enum OverWorldZone
{
    None,
    Forest,
    Sand
}

public static class ZoneTypes
{
    private static readonly Dictionary<float, OverWorldZone> ZoneProbabilities = new Dictionary<float, OverWorldZone>
    {
        {.1f,OverWorldZone.Sand},
        {.2f,OverWorldZone.Sand},
        {.3f,OverWorldZone.Sand},
        {.4f,OverWorldZone.Sand},
        {.5f,OverWorldZone.Forest}
    };
    public static OverWorldZone GetZoneTypeFromPerlinData(float perlinData)
    {
        OverWorldZone returnZone;
        var defaultZone = OverWorldZone.Forest;
        
        var flooredEntry = (Mathf.Round(perlinData * 10)) / 10;
        
        if (!ZoneProbabilities.TryGetValue(flooredEntry, out returnZone))
            returnZone = defaultZone;

        return returnZone;
    }
    
}
