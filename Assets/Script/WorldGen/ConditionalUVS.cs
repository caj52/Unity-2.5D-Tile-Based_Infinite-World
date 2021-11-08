using UnityEngine;

public class ConditionalUVS
{
    public static Vector2 ModifyTileIfHeightDiscrepancies(Vector2Int tileCoordinate)
    {
        var newUV = ModifyUVBasedOnVertexHeights(tileCoordinate);
        return newUV;
    }

    private static Vector2 ModifyUVBasedOnVertexHeights(Vector2Int tileCoordinates)
    {
        var returnVector = new Vector2();

        var newUV = GetUVIfTileIsUnderWater(tileCoordinates);
        if (newUV != Vector2.zero)
            returnVector = newUV;
        
        newUV = GetUVIfTileIsCliffFace(tileCoordinates);
        if (newUV != Vector2.zero)
            returnVector = newUV;
        
        
        return returnVector;
    }

    private static Vector2 GetUVIfTileIsCliffFace(Vector2Int tileCoordinates)
    {
        var heightPoints = OverWorldMeshUtility.GetLowestAndHighestPointsInTileVertices(tileCoordinates);
        
        float maxTileHeight = 1/HeightMapManager.WorldMaxHeightMultiplier;
        var returnVector = new Vector2();

        if ((heightPoints[1]-heightPoints[0])>maxTileHeight)
        {
            returnVector = TileUVs.GetTileUV(OverWorldTile.CliffFace);
        }

        return returnVector;
    }
    private static Vector2 GetUVIfTileIsUnderWater(Vector2Int tileCoordinates)
    {
        var isUnderwater = OverWorldMeshUtility.GetIfTileIsUnderWater(tileCoordinates);
        if(isUnderwater)
            return TileUVs.GetTileUV(OverWorldTile.Sand);
        
        return Vector2.zero;
    }
}
