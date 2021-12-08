using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectType : MonoBehaviour
{
  public enum InventoryObject
  {
    None,
    Apple
  }

  public static Dictionary<InventoryObject, string> objectURLReferences = new Dictionary<InventoryObject, string>()
  {
    {InventoryObject.None, "inventoryObjects/transparent"},
    {InventoryObject.Apple, "inventoryObjects/food_21"}
  };
  public static Dictionary<InventoryObject, string> objectNameStrings= new Dictionary<InventoryObject, string>()
  {
    {InventoryObject.None, "None"},
    {InventoryObject.Apple, "Apple"}
  };

  public static Dictionary<InventoryObject, Dictionary<string, int>> InventoryObjectInteractions =
    new Dictionary<InventoryObject, Dictionary<string, int>>()
    {
      /*Object/ReferenceCombos*/
      {
        InventoryObject.Apple, new Dictionary<string, int>()
        {
          /*Interactions*/ {"Examine", 0}, {"Eat", 1}, {"Throw", 2} /*End Interactions*/
        }
      }
      /*Object/ReferenceCombos End*/
    };


public static string[] ParseGetBaseReferenceAndIndexNumber(string URLReference)
  {
    var lastIndex = URLReference.LastIndexOf("_");
    
    if(lastIndex==-1)
      return  new [] {URLReference,"0"};
    
    var spriteIndex = URLReference.Substring(lastIndex+1);
    var baseReference = URLReference.Remove(lastIndex);
    
    string[] returnArray = new string[] {baseReference,spriteIndex };
    return returnArray;
  }
}
