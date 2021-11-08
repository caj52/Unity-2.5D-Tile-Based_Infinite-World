using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class TilesManager
{
    public static OverWorldTile GetTileTypeFromXAndYCoordinate(Vector2 tileCoordinates)
    {
        var tilePosition = GetWorldPositionFromTileCoordinates(tileCoordinates);

        var zoneType = ZoneManager.GetZoneFromWorldPosition(tilePosition);

        var returnTile =  TileTypes.GetTileFromZoneType(zoneType);
        
        return returnTile;
    }

    private static Vector3 GetWorldPositionFromTileCoordinates(Vector2 tileCoordinates)
    {
        var windowPosition = OverWorldMesh.Instance.GetWorldWindowPosition();
        windowPosition.x += tileCoordinates.x;
        windowPosition.z += tileCoordinates.y;
        return windowPosition;
    }
}
