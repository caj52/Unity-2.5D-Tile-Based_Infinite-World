
using System.Collections;

using UnityEngine;

public class OverWorldObjectManager : MonoBehaviour
{
    public static OverWorldObjectManager Instance;
    public void Init()
    {
        Instance = this;
    }

    private void UpdatePlaceNewObjects()
    {
        var amountToShift = OverWorldMeshUtility.GetPositionChange();
        var meshSize = OverWorldMesh._meshSize;
        var zoneTypesPerlin = PerlinGen.Generate(PerlinArrays.GetZonesArray());
        OverWorldZone lastZone = OverWorldZone.None;
        float[,] zonePerlin = new float[meshSize,meshSize];

        for (int z = 0;z<meshSize;z++)
        {
            for (int x = 0;x<meshSize;x++)
            {
                var thisTile = new Vector2Int(x, z);
                var recalculate = OverWorldMeshUtility.ShouldTileBeRecalculated(amountToShift, thisTile);
                if (recalculate)
                {
                    var zoneType = ZoneTypes.GetZoneTypeFromPerlinData(zoneTypesPerlin[x, z]);
                
                
                    if (lastZone!=zoneType)
                    {
                        var zoneArray = PerlinArrays.GetZoneArrayFromZoneType(zoneType);
                        zonePerlin = PerlinGen.Generate(zoneArray);
                        lastZone = zoneType;
                    }
                
                    var objectToPlace = ObjectTypes.GetObjectTypeFromPerlinData(zonePerlin[x,z]);
                    if(objectToPlace==OverWorldObject.None)
                        continue;
                    
                    PlaceObjectAtTile(objectToPlace,thisTile);
                }
            }
                
        }
    }

    public IEnumerator PlaceOverWorldObjects()
    {
        Debug.Log("Place OverWorld Object Fired");
        var meshSize = OverWorldMesh._meshSize;
        var zoneTypesPerlin = PerlinGen.Generate(PerlinArrays.GetZonesArray());
        OverWorldZone lastZone = OverWorldZone.None;
        float[,] zonePerlin = new float[meshSize,meshSize];

        for(int y=0;y<meshSize;y++)
        {
            for(int x=0;x<meshSize;x++)
            {
                var zoneType = ZoneTypes.GetZoneTypeFromPerlinData(zoneTypesPerlin[x, y]);
                
                if (lastZone!=zoneType)
                {
                    var zoneArray = PerlinArrays.GetZoneArrayFromZoneType(zoneType);
                    zonePerlin = PerlinGen.Generate(zoneArray);
                    lastZone = zoneType;
                }
                
                var objectToPlace = ObjectTypes.GetObjectTypeFromPerlinData(zonePerlin[x,y]);
                if(objectToPlace==OverWorldObject.None)
                    continue;

                var tileCoordinate = new Vector2Int(x, y);
                
                PlaceObjectAtTile(objectToPlace,tileCoordinate);
            }
        }
        yield break;
    }

    public void PlaceObjectAtTile(OverWorldObject objectToPlace, Vector2Int tileCoordinate)
    {
        var gameObject = ObjectTypes.GetGameObjectFromOverWorldObject(objectToPlace);
        var objectRotation = new Quaternion();
        var worldPosition = OverWorldMeshUtility.GetWorldPositionFromTileCoordinates(tileCoordinate);
        var tileUnderwater = OverWorldMeshUtility.GetIfTileIsUnderWater(tileCoordinate);
        if(gameObject!=null && !tileUnderwater)
            Instantiate(gameObject,worldPosition,objectRotation,transform);

    }

    public void RemoveOutOfBoundsObjects()
    {
        var windowPosition = OverWorldMesh._worldWindow.transform.position;
        var halfSize = OverWorldMesh._meshSize / 2;
        for (int x =0; x<transform.childCount;x++)
        {
            var overworldObject = transform.GetChild(x).gameObject;
            var objectPosition = overworldObject.transform.position;

            bool leftBound = objectPosition.x < windowPosition.x - halfSize;
            bool rightBound = objectPosition.x > windowPosition.x + halfSize;
            bool topBound = objectPosition.z > windowPosition.z + halfSize;
            bool bottomBound = objectPosition.z < windowPosition.z - halfSize;
            
            if (leftBound||rightBound||topBound||bottomBound)
            {
                Destroy(overworldObject);
            }
            
        }
    }

    public void UpdateOverWorldObjects()
    {
        RemoveOutOfBoundsObjects();
        UpdatePlaceNewObjects();
    }
}
