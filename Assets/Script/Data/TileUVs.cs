using System.Collections.Generic;
using UnityEngine;
public static class TileUVs
{
    private static readonly Dictionary<OverWorldTile, Vector2> TileReference = new Dictionary<OverWorldTile, Vector2>
    {
        {OverWorldTile.Grass,new Vector2(6,11)},
        {OverWorldTile.Sand,new Vector2(1,12)},
        {OverWorldTile.CliffBottom_1,new Vector2(2,6)},
        {OverWorldTile.CliffBottom_2,new Vector2(3,6)},
        {OverWorldTile.CliffFace,new Vector2(6,6)},
        {OverWorldTile.CliffTop_1,new Vector2(2,7)},
        {OverWorldTile.CliffTop_2,new Vector2(3,7)}
        
    };
    public static Vector2 GetTileUV(OverWorldTile tile)
    {
        Vector2 tileUV;
        TileReference.TryGetValue(tile, out tileUV);
        return tileUV;
    }
}
