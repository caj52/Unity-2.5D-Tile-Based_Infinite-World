using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ToolBarSelectionHand : MonoBehaviour
{
    public static ToolBarSelectionHand Instance;
    private QuickAccessInventory _quickAccessInventory;
    public int currentlySelected { get; private set; }

    public void Init()
    {
        Instance = this;
        _quickAccessInventory = transform.parent.GetComponentInChildren<QuickAccessInventory>();
        SetPositionFromToolbarNumber(6);
        SetEnabled(false);
    }
    
    public void SetPositionFromToolbarNumber(int toolBarNumber)
    {
        SetEnabled(true);
        Vector3 newPosition = Vector3.zero;

        newPosition = _quickAccessInventory.transform.GetChild(toolBarNumber - 6).localPosition;
        newPosition.x -= 50;
        newPosition.y -= 60;
        newPosition.z = 0;
        transform.localPosition = newPosition;
    }

    public void Unselect()
    {
        currentlySelected = 0;
        SetEnabled(false);
    }
    public void SetEnabled(bool state)
    {
        gameObject.SetActive(state);
    }

    public InventoryObjectType.InventoryObject GetObjectFromKeyInput(int keyPressed)
    {
        return Player.Instance.quickAccess[keyPressed - 6];
    }

    public void SetCurrentlySelected(int newSelection)
    {
        currentlySelected = newSelection;
    }
}
