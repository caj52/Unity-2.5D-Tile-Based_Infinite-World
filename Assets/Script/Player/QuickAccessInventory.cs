using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickAccessInventory : MonoBehaviour
{
    public static QuickAccessInventory Instance;
    private GameObject[] objectImages = new GameObject[4];

    public void Init()
    {
        Instance = this;
    }
    public void UpdateInventoryImages()
    {
        for (int x =0;x<4;x++)
        {
            var parentObject = transform.GetChild(x);
            var lastIndex = parentObject.childCount;
            var images = parentObject.GetChild(lastIndex-1).gameObject;
            
            var image = images.GetComponent<Image>();
            var thisObject = Player.Instance.quickAccess[x];
            
            InventoryObjectType.objectURLReferences.TryGetValue(thisObject, out var reference);
            
            var baseReference = InventoryObjectType.ParseGetBaseReferenceAndIndexNumber(reference);
            var spriteIndex = Convert.ToInt32(baseReference[1]);
            var sprites = Resources.LoadAll<Sprite>(baseReference[0]);
            var sprite = sprites[spriteIndex];
            
            image.sprite = sprite;
        }
    }
}
