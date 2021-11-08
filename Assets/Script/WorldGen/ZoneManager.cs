using UnityEngine;
public static class ZoneManager
{
    private static float[] zonePerlinArray;
    private static float[,] zonesPerlin;
    public static OverWorldZone GetZoneFromWorldPosition(Vector3 tileWorldPosition)
    {
        GenerateNewZonePerlinIfPositionChanged();
        
        var windowPosition = OverWorldMesh.Instance.GetWorldWindowPosition();
        
        var perlinX = Mathf.RoundToInt(tileWorldPosition.x - windowPosition.x);
        var perlinZ = Mathf.RoundToInt(tileWorldPosition.z - windowPosition.z);

        float zoneFloat = zonesPerlin[perlinX, perlinZ];

        return ZoneTypes.GetZoneTypeFromPerlinData(zoneFloat);
    }

    private static void GenerateNewZonePerlinIfPositionChanged()
    {
        if (OverWorldMeshUtility.HasPositionChanged()||zonesPerlin==null)
        {
            UpdateZonesPerlinPosition();
            zonePerlinArray = PerlinArrays.GetZonesArray();
            zonesPerlin = PerlinGen.Generate(zonePerlinArray);
            OverWorldMesh.Instance.SetCurrentWorldWindowPosition();
        }
    }
    private static void UpdateZonesPerlinPosition()
    {
        var meshPosition = OverWorldMesh.Instance.GetWorldWindowPosition();
        PerlinArrays.AdjustZonesPerlinCoordinates(meshPosition);

    }
}
