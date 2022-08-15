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
  public static Dictionary<InventoryObject, string> examineDescriptions= new Dictionary<InventoryObject, string>()
  {
    {InventoryObject.None, "If you're reading this... the programmer messed up"},
    {InventoryObject.Apple, "Its an Apple! Red, Juicy and Delicious"}
  };
  public static Dictionary<InventoryObject, bool> consumableTypes= new Dictionary<InventoryObject, bool>()
  {
    {InventoryObject.None, false},
    {InventoryObject.Apple, true}
  };
  public static InteractableObject GetInteractableObjectFromInventoryObject(InventoryObject inventoryObject)
  {
    var newObject = new InteractableObject();
    objectNameStrings.TryGetValue(inventoryObject, out var objectName);
    examineDescriptions.TryGetValue(inventoryObject, out var objectDescription);
    consumableTypes.TryGetValue(inventoryObject, out var _isConsumable);
    newObject.name = objectName;
    newObject.isConsumable = _isConsumable;
    newObject.beingHeld = true;
    newObject.examineDescription = objectDescription;
    
    newObject.InitUniqueObjectVariables();
    
    return newObject;
  }
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
