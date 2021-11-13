using Unity.Mathematics;
using UnityEngine;

public class OverWorldMeshUtility
{
    private static GameObject _worldWindow { get => OverWorldMesh._worldWindow; }
    private static int meshSize{ get => OverWorldMesh._meshSize; }
    public static Vector2Int GetPositionChange()
    {
        var worldWindowPosition = _worldWindow.transform.position;
        var worldWindowLastPosition = OverWorldMesh.worldWindowLastPosition;
        var positionOffset = worldWindowPosition - worldWindowLastPosition;

        Vector2Int positionChange = new Vector2Int((int)positionOffset.x, (int)positionOffset.z);
        return positionChange;
    }
    public static int GetStartingVertexFromLocalTileCoordinates(Vector2Int tileCoordinates)
    {
        var totalVertsOnBottom = meshSize * 2;
        var totalVertsInMiddleLayers = meshSize * 4;
        var layerOffset = 2;
        var firstIndexAfterBottomLayer = totalVertsOnBottom + layerOffset;
        var xOffset = tileCoordinates.x * 4;
        var indexOfVertex = firstIndexAfterBottomLayer + xOffset+((tileCoordinates.y - 1) * totalVertsInMiddleLayers)-1;
       
        if(tileCoordinates.y==0)
            indexOfVertex = tileCoordinates.x * 2;
        
        return indexOfVertex;
    }
    public static int GetVertOperationIdentifier(int x, int z)
    {
        if (z==meshSize-1) 
            return 2;
        if (z == 0) 
            return 1;
        return 0;
    }
    public static Vector4 GetTileTrianglesVertices(int x, int z)
    {
        Vector4 trianglesVertices = new Vector4();
        var startingVert = GetStartingVertexFromLocalTileCoordinates(new Vector2Int(x, z));
        switch (GetVertOperationIdentifier(x, z))
        {
            case 0: //surrounded on all sides
                trianglesVertices[0] = startingVert;
                trianglesVertices[1] = startingVert + (meshSize * 4) - 1;
                trianglesVertices[2] = startingVert + 2;
                trianglesVertices[3] = startingVert + (meshSize * 4) + 1;
                break;
            case 1: //bottom edge
                trianglesVertices[0] = startingVert;
                trianglesVertices[1] = startingVert + (meshSize * 2) + (2 * x) ;
                trianglesVertices[2] = startingVert + 1;
                trianglesVertices[3] = startingVert + (meshSize * 2) + (2 * x) + 2;
                break;
            case 2: //top row
                trianglesVertices[0] = startingVert;
                trianglesVertices[1] = startingVert + (meshSize * 4) - (2 * x) - 1 ;
                trianglesVertices[2] = startingVert + 2;
                trianglesVertices[3] = startingVert + (meshSize * 4) - (2 * x);
                break;
        }
        return trianglesVertices;
    }
    public static Vector4 GetVertexHeightsFromTile(Vector2Int tileCoordinates)
    {
        return OverWorldMesh.tileHeights[tileCoordinates.x, tileCoordinates.y];
    }
    
    public static bool GetIfTileIsUnderWater(Vector2Int tileCoordinates)
    {
        float seaLevel = OceanManager.Instance.seaLevel;
        Vector4 tileVertexHeights = GetVertexHeightsFromTile(tileCoordinates);
        for (int x=0; x<4;x++)
        {
            if (tileVertexHeights[x] <= seaLevel)
                return true;
        }

        return false;
    }
    public static bool HasPositionChanged()
    {
        Vector2Int positionChanged = GetPositionChange();
       
        if (positionChanged != Vector2Int.zero)
            return true;
        return false;
    }
    
    public static Vector2 GetLowestAndHighestPointsInTileVertices(Vector2Int tileCoordinates)
    {
        var heights = GetVertexHeightsFromTile(tileCoordinates);
        
        float highestValue=0;
        float lowestValue= HeightMapManager.WorldMaxHeightMultiplier;
        
        for (int x=0;x<4;x++)
        {
            if (heights[x] < lowestValue)
                lowestValue = heights[x];
            if (heights[x] > highestValue)
                highestValue = heights[x];
        }

        return new Vector2(lowestValue, highestValue);
    }
    public static float GetAverageHeightInTile(Vector2Int tileCoordinates)
    {
        var points = GetLowestAndHighestPointsInTileVertices(tileCoordinates);

        return Mathf.Lerp(points[0], points[1], .5f);
    }
    public static void RoundWorldWindowPosition()
    {
        var roundedWindowPosition = new Vector3Int();
        roundedWindowPosition.x = Mathf.RoundToInt(_worldWindow.transform.position.x);
        roundedWindowPosition.z = Mathf.RoundToInt(_worldWindow.transform.position.z);
        _worldWindow.transform.position = roundedWindowPosition;
    }
    public static int CheckIfVertexEdgeCase(int x, int z)
    {
        ////corners////
        if (x==0&&z==0)
            return 1;
        if (z==0&&x==meshSize)
            return 1;
        if(x==0&&z==meshSize)
            return 1;
        if(x==meshSize&&z==meshSize)
            return 1;
        ////calculating tris only////
       
        ////////////////////////////
        ///non-corner edges////
        if (x == 0 || z == 0)
            return 2;
        if (x == meshSize || z == meshSize)
            return 2;
        /////surrounded on all sides/////
        return 0;
    }
    public static Vector3 GetWorldPositionFromTileCoordinates(Vector2Int tilecoordinates)
    {
        var halfMeshSize = new Vector3(meshSize / 2,0,meshSize / 2);
        
        var worldWindowPosition = OverWorldMesh.Instance.GetWorldWindowPosition()-halfMeshSize;
        
        var tileHeightAverage = GetAverageHeightInTile(tilecoordinates);

        var centerOffset = new Vector2(.5f, .5f);
        var vec3TileCoordinate = new Vector3(tilecoordinates.x+centerOffset.x,tileHeightAverage , tilecoordinates.y+centerOffset.y);
        var tilePosition = worldWindowPosition + vec3TileCoordinate;

        return tilePosition;
    }
}
