using System.Collections.Generic;
using UnityEngine;
public enum OverWorldObject
{
    None,
    Tree,
    Rock,
    Flowers
}
public static class ObjectTypes
{
    private static GameObject tree;
    private static GameObject rock;
    private static GameObject flowers;

    private static Dictionary<OverWorldObject, GameObject> OverWorldGameObjects;
    public static void Init()
    {
        tree = Resources.Load<GameObject>("Prefabs/EnviornmentalObjects/Tree");
        rock = Resources.Load<GameObject>("");
        flowers = Resources.Load<GameObject>("");

        OverWorldGameObjects = new Dictionary<OverWorldObject, GameObject>
        {
            {OverWorldObject.None,null},
            {OverWorldObject.Tree,tree},
            {OverWorldObject.Rock,rock}
        };
    }
    private static readonly Dictionary<float, OverWorldObject> ObjectProbabilities = new Dictionary<float, OverWorldObject>
    {
        {.1f,OverWorldObject.None},
        {.2f,OverWorldObject.Tree},
        {.3f,OverWorldObject.None},
        {.4f,OverWorldObject.None},
        {.5f,OverWorldObject.None}
    };
    public static OverWorldObject GetObjectTypeFromPerlinData(float perlinData)
    {
        OverWorldObject returnObject;
        var defaultObject = OverWorldObject.None;
        
        var flooredEntry = (Mathf.Round(perlinData * 10)) / 10;
        
        if (!ObjectProbabilities.TryGetValue(flooredEntry, out returnObject))
            returnObject = defaultObject;

        return returnObject;
    }

    public static GameObject GetGameObjectFromOverWorldObject(OverWorldObject objectType)
    {
        GameObject returnObject;
        OverWorldGameObjects.TryGetValue(objectType, out returnObject);
        return returnObject;
    }
    
}