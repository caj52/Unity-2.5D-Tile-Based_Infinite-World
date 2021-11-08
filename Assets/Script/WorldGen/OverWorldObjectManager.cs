using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class OverWorldObjectManager : MonoBehaviour
{
    public static OverWorldObjectManager Instance;
    public void Init()
    {
        Instance = this;
    }

    public IEnumerator PlaceOverWorldObjects()
    {
        Debug.Log("Place OverWorld Object Fired");
        var meshSize = OverWorldMesh._meshSize;
        var zoneTypesPerlin = PerlinGen.Generate(PerlinArrays.GetZonesArray());
        OverWorldZone lastZone = OverWorldZone.None;
        for(int y=0;y<meshSize;y++)
        {
            for(int x=0;x<meshSize;x++)
            {
                var zoneType = ZoneTypes.GetZoneTypeFromPerlinData(zoneTypesPerlin[x, y]);
                
                float[,] zonePerlin = new float[meshSize,meshSize];
                
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
}
