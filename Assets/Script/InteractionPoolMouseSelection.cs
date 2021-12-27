using UnityEngine;
public class InteractionPoolMouseSelection : MonoBehaviour
{
    public static InteractionPoolMouseSelection Instance;
    [HideInInspector]public int scrollBarTracker;
    private int trueState;
    private bool tempMode;
    

    public void Init()
    {
        Instance = this;
        scrollBarTracker = 0;
    }
    
    public void UpdatePosition()
    {
        var newPosition = transform.localPosition;
        newPosition.y = -14 - (22 * scrollBarTracker);
        transform.localPosition = newPosition;
    }

    private void UpdateTrueState()
    {
        if (!tempMode)
            trueState = scrollBarTracker;
    }
    public void IncrementScrollBarTrackerAndUpdatePosition(int amountToIncrement)
    {
        UpdateTrueState();
        tempMode = false;
        
        scrollBarTracker += amountToIncrement;
        ClampScrollBarTracker();
        UpdatePosition();
    }

    public void SetScrollBarTracker(int newValue)
    {
        UpdateTrueState();
        tempMode = false;
        
        if (newValue == scrollBarTracker)
            return;
        
        while (newValue != scrollBarTracker)
        {
            if (newValue > scrollBarTracker)
                scrollBarTracker++;
            else
                scrollBarTracker--;
        }
        ClampScrollBarTracker();
        UpdatePosition();
    }
    public void ExecuteCurrentSelection()
    {
        var interactionPool = InteractionsPool.Instance;
        interactionPool.SetCanExecute(false);
        var interactableObject = InteractionsPool.Instance.interactableObject;
        interactableObject.ExecuteInteraction(scrollBarTracker);
        interactionPool.ResetOptionExecutionBar(scrollBarTracker);
    }
    private void ClampScrollBarTracker()
    {
        var interactions = InteractionsPool.Instance.interactionPool.Count;
        if (scrollBarTracker < 0)
            scrollBarTracker = 0;
        if (scrollBarTracker > interactions-1)
            scrollBarTracker = interactions-1;
    }
    public void TemporarySelect(int tempIndex)
    {
        SetScrollBarTracker(tempIndex);
        tempMode = true;
    }

    public void ResetFromInitialTempSelect()
    {
        SetScrollBarTracker(trueState);
    }
}
