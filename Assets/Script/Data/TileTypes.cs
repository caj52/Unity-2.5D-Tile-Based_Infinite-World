using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OverWorldTile
{
    Grass,
    Sand,
    CliffBottom_1,
    CliffBottom_2,
    CliffFace,
    CliffTop_1,
    CliffTop_2
}

public static class TileTypes
{
    private static readonly Dictionary<OverWorldZone, OverWorldTile> TileZoneCorrelations = new Dictionary<OverWorldZone, OverWorldTile>
    {
        {OverWorldZone.Sand,OverWorldTile.Sand},
        {OverWorldZone.Forest,OverWorldTile.Grass}
    };
    public static OverWorldTile GetTileFromZoneType(OverWorldZone zone)
    {
        OverWorldTile returnTile;
        TileZoneCorrelations.TryGetValue(zone, out returnTile);
        return returnTile;
    }
    
}
