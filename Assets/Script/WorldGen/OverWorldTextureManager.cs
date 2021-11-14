using System;
using UnityEngine;

public class OverWorldTextureManager : MonoBehaviour
{
    [SerializeField] private Texture2D overworldSpriteSheet;
    private const float spritesheetDimensions = 16;
    public static Vector2[] _GlobalBuildingUVS;
    public static OverWorldTextureManager Instance;
    private OverWorldMesh overworldMesh;

    private static int meshSize {get => OverWorldMesh._meshSize;}

    public void Init()
    {
        overworldMesh = OverWorldMesh.Instance;
        Instance = this;
    }
    
    public void UpdateUVS()
    {
        var amountToShift = OverWorldMeshUtility.GetPositionChange();
        var tilesToUpdate = ShiftGlobalBuildingUVSAndGetTilesToRecalculate(amountToShift);
        RecalculateTilesInGlobalBuildingUVS(tilesToUpdate);
        overworldMesh.SetOverWorldUVs();
    }
    public Vector2[] GetGlobalBuildingUVS()
    {
        return _GlobalBuildingUVS;
    }

       
    private void RecalculateTilesInGlobalBuildingUVS(Vector2Int[] tilesToRecalculate)
    {
        foreach (Vector2Int tile in tilesToRecalculate)
        {
            SetTileUV(tile);
        }
    }
    public void Assign_GlobalBuildingUVS()
    {
        _GlobalBuildingUVS = new Vector2[OverWorldMesh.vertices.Length];
        
        int sqrtOfTotalChunks = meshSize / 16;
        
        var startTime = Time.realtimeSinceStartupAsDouble;
        for (int z =0; z < sqrtOfTotalChunks; z++)
        { 
            for (int x = 0; x < sqrtOfTotalChunks; x++)
            {
                Vector2Int startingTile = new Vector2Int(x*16,z*16);
                Set16X16TilesInGlobalBuildingUVs(startingTile);
            }
        }
        overworldMesh.SetOverWorldUVs();
        overworldMesh.SetOverWorldTexture(overworldSpriteSheet);
    }
       
    private void Set16X16TilesInGlobalBuildingUVs(Vector2Int startingTile)
    {
        for (int z =0; z < 16; z++)
        {
            for (int x = 0; x < 16; x++)
            {
                Vector2Int currentTile = new Vector2Int(x,z) + startingTile;
               
                SetTileUV(currentTile);
            }
        }
    }
       
    private void SetTileUV(Vector2Int tileCoordinate)
    {
        var meshSizeUVMultiplier = meshSize / spritesheetDimensions;
        
        var tileType = TilesManager.GetTileTypeFromXAndYCoordinate(tileCoordinate);
        
        var tileSelection = TileUVs.GetTileUV(tileType);
        
        var newTile = ConditionalUVS.ModifyTileIfHeightDiscrepancies(tileCoordinate);
        if (newTile != Vector2.zero)
            tileSelection = newTile;
        
        
        tileSelection *= meshSizeUVMultiplier;
            
        var tileIndices = GetTileIndices(tileCoordinate);
        
        _GlobalBuildingUVS[(int)tileIndices[0]] = tileSelection / meshSize;
        _GlobalBuildingUVS[(int)tileIndices[1]] = (tileSelection + new Vector2(1, 0) * meshSizeUVMultiplier) / meshSize;
        _GlobalBuildingUVS[(int)tileIndices[2]] = (tileSelection + new Vector2(0, 1) * meshSizeUVMultiplier) / meshSize;
        _GlobalBuildingUVS[(int)tileIndices[3]] = (tileSelection + new Vector2(1, 1) * meshSizeUVMultiplier) / meshSize;
    }
    private Vector2Int[] ShiftGlobalBuildingUVSAndGetTilesToRecalculate(Vector2Int amountToShift)
    {
        var amountOfTilesToRecalculate = (meshSize * Math.Abs(amountToShift.x)) + (meshSize * Math.Abs(amountToShift.y));
        var recalculateIndexCounter = 0;
        Vector2Int[] tilesToRecalculate = new Vector2Int[amountOfTilesToRecalculate];

        var xMods = GetUVSLoopStartFinishAndAppendModifier(true, amountToShift);
        var zMods = GetUVSLoopStartFinishAndAppendModifier(false, amountToShift);
        
        for (int z = zMods[0]; z != zMods[1]; z+=zMods[2])
        {
            for (int x = xMods[0]; x != xMods[1]; x+=xMods[2])
            {
                var thisTile = new Vector2Int(x, z);
                var recalculate = OverWorldMeshUtility.ShouldTileBeRecalculated(amountToShift, thisTile);
                if (recalculate)
                {
                    tilesToRecalculate[recalculateIndexCounter] = thisTile;
                    recalculateIndexCounter++;
                    continue;
                }

                var tileIndices = GetTileIndices(thisTile);
                var newTileIndices = GetTileIndices(thisTile + amountToShift);
                _GlobalBuildingUVS[(int) tileIndices[0]] = _GlobalBuildingUVS[(int) newTileIndices[0]];
                _GlobalBuildingUVS[(int) tileIndices[1]] = _GlobalBuildingUVS[(int) newTileIndices[1]];
                _GlobalBuildingUVS[(int) tileIndices[2]] = _GlobalBuildingUVS[(int) newTileIndices[2]];
                _GlobalBuildingUVS[(int) tileIndices[3]] = _GlobalBuildingUVS[(int) newTileIndices[3]];
            }
                
        }
        return tilesToRecalculate;
    }

    private Vector3Int GetUVSLoopStartFinishAndAppendModifier(bool XORZ,Vector2Int amountToShift)
    {
        Vector3Int loopMods = new Vector3Int();
        if (XORZ)
        {
            loopMods[0] = 0;
            loopMods[1] = meshSize;
            loopMods[2] = 1;
            
            if (amountToShift.x<0)
            {
                loopMods[0] = meshSize-1;
                loopMods[1] = -1;
                loopMods[2] = -1;
            }
        }
        else
        {
            loopMods[0] = 0;
            loopMods[1] = meshSize;
            loopMods[2] = 1;
            
            if (amountToShift.y<0)
            {
                loopMods[0] = meshSize-1;
                loopMods[1] = -1;
                loopMods[2] = -1;
            }
        }
        return loopMods;
    }
    private Vector4 GetTileIndices(Vector2Int tileCoordinates)
    {
        var TileIndices = new Vector4();
        
        int startingVert = OverWorldMeshUtility.GetStartingVertexFromLocalTileCoordinates(tileCoordinates);
        int vertCase = OverWorldMeshUtility.GetVertOperationIdentifier(tileCoordinates.x,tileCoordinates.y);
        int x = tileCoordinates.x;
        switch (vertCase)
        {
            case 0: //surrounded on all sides
                TileIndices[0] = startingVert;
                TileIndices[1] = startingVert + 2;
                TileIndices[2] = startingVert + (meshSize * 4) - 1;
                TileIndices[3] = startingVert + (meshSize * 4) + 1;
                break;
            case 1: //bottom edge
                TileIndices[0] = startingVert;
                TileIndices[1] = startingVert + 1;
                TileIndices[2] = startingVert + (meshSize * 2) + (2 * x);
                TileIndices[3] = startingVert + (meshSize * 2) + (2 * x) + 2;
                break;
            case 2: //top row
                TileIndices[0] = startingVert;
                TileIndices[1] = startingVert + 2;
                TileIndices[2] = startingVert + (meshSize * 4) - (2 * x) - 1;
                TileIndices[3] = startingVert + (meshSize * 4) - (2 * x);
                break;
        }
        return TileIndices;
    }

   
}

