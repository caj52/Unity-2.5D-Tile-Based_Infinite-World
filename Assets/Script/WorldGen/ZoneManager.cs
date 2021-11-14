using UnityEngine;
public static class ZoneManager
{
    private static float[] zonePerlinArray;
    private static float[,] zonesPerlin;
    public static OverWorldZone GetZoneFromWorldPosition(Vector3 tileWorldPosition)
    {
        var windowPosition = OverWorldMesh.Instance.GetWorldWindowPosition();
        
        var perlinX = Mathf.RoundToInt(tileWorldPosition.x - windowPosition.x);
        var perlinZ = Mathf.RoundToInt(tileWorldPosition.z - windowPosition.z);

        float zoneFloat;
        try
        {
             zoneFloat = zonesPerlin[perlinX, perlinZ];
        }
        catch
        {
            GenerateNewZonePerlin();
            zoneFloat = zonesPerlin[perlinX, perlinZ];
        }

        return ZoneTypes.GetZoneTypeFromPerlinData(zoneFloat);
    }

    public static void GenerateNewZonePerlinIfPositionChanged()
    {
        if (OverWorldMeshUtility.HasPositionChanged()||zonesPerlin==null)
        {
            GenerateNewZonePerlin();
        }
    }
    private static void UpdateZonesPerlinPosition()
    {
        var meshPosition = OverWorldMesh.Instance.GetWorldWindowPosition();
        PerlinArrays.AdjustZonesPerlinCoordinates(meshPosition);

    }

    private static void GenerateNewZonePerlin()
    {
        UpdateZonesPerlinPosition();
        zonePerlinArray = PerlinArrays.GetZonesArray();
        zonesPerlin = PerlinGen.Generate(zonePerlinArray);
    }
}
