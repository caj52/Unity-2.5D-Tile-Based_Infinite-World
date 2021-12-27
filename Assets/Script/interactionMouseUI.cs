using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionMouseUI : MonoBehaviour
{
    public void SelectOption()
    {
        if (!Cursor.visible)
            return;
        
        
        var barNum = transform.GetSiblingIndex();
        InteractionPoolMouseSelection.Instance.SetScrollBarTracker(barNum);
    }

    public void SetTemporarySelection()
    {
        if (!Cursor.visible)
            return;
        
        
        var barNum = transform.GetSiblingIndex();
        
        InteractionPoolMouseSelection.Instance.TemporarySelect(barNum);
    }
    public void ReleaseTemporarySelection()
    {
        if (!Cursor.visible)
            return;
        
        
        InteractionPoolMouseSelection.Instance.ResetFromInitialTempSelect();
    }
}
