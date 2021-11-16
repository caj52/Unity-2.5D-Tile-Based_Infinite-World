using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum OverWorldObject
{
    None,
    Tree,
    Rock,
    Flowers
}
public static class ObjectTypes
{

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
        returnObject = GetVariantObject(objectType);
        return returnObject;
    }

    private static GameObject GetVariantObject(OverWorldObject objectType)
    {
        GameObject returnObject = null;
        switch (objectType)
        {
            case OverWorldObject.Tree:
                returnObject = GetPineTreeVariant();
                break;
        }
        return returnObject;
    }

    private static GameObject GetPineTreeVariant()
    {
        //implement seed based off position here
        var randomVariant = UnityEngine.Random.Range(1, 38);
        string directoryString;
        
        TreePrefabDirectories.PineTreeVariants.TryGetValue(randomVariant,out directoryString);
        return Resources.Load<GameObject>(directoryString);
    }
}