using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InteractionPoolMouseSelection : MonoBehaviour
{
    public static InteractionPoolMouseSelection Instance;
    [HideInInspector]public int scrollBarTracker;

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

    public void IncrementScrollBarTrackerAndUpdatePosition(int amountToIncrement)
    {
        var interactions = InteractionsPool.Instance.interactionPool.Count;
        scrollBarTracker += amountToIncrement;
        UpdatePosition();
        if (scrollBarTracker < 0)
            scrollBarTracker = 0;
        if (scrollBarTracker > interactions-1)
            scrollBarTracker = interactions-1;
    }
}
