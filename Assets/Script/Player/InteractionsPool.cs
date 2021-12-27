using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsPool : MonoBehaviour
{
    private bool fillingBar;
    public static InteractionsPool Instance;
    public GameObject poolBottom;
    public GameObject interactionsPoolTextObject;
    public GameObject executionBar;
    public GameObject executionBars;
    public RectMask2D interactionsPoolMask;
    private Text interactionsPoolText;
    private Text interactionsPoolTitle;
    private bool inCoroutine;
    private BoxCollider _boxCollider;
    public bool canExecute { get; private set; }
    public InteractableObject interactableObject { get; private set; }
    public GameObject interactionsPoolObjectName;
    public GameObject areaRect;
    [HideInInspector]public List<InteractionTypes.Interaction> interactionPool = new List<InteractionTypes.Interaction>();
    [HideInInspector]public List<InteractableObject> interactionPoolObjectReferences;

    public void Init()
    {
        Instance = this;
        interactionsPoolText = interactionsPoolTextObject.GetComponent<Text>();
        interactionsPoolTitle = interactionsPoolObjectName.GetComponent<Text>();
        _boxCollider = Player.Instance.GetComponent<BoxCollider>();
    }
    private void FixedUpdate()
    {
        if(!inCoroutine) 
            StartCoroutine(CheckUnHeldExecutionBars());
    }
    public void AddOptionsToPool()
    {
        var interactionsToAdd = interactableObject.GetCurrentInteractions();
        var objectReference = interactableObject;
        
        var counter = 0;
        foreach (var interaction in interactionsToAdd)
        {
            
            interactionPool.Add(interaction);
            
            interactionPoolObjectReferences.Add(objectReference);
            
            var newBar = Instantiate(executionBar);
            newBar.transform.parent = executionBars.transform;
            counter++;
        } 
        UpdateInteractionsPool();
    }
    public void RemoveOptionsFromPool(InteractableObject objectToRemove)
    {
        int counter=0;
        InteractionTypes.Interaction[] interactionsToRemove = new InteractionTypes.Interaction[interactionPool.Count];
        foreach (var interaction in interactionPool)
        {
            if (interactionPoolObjectReferences[counter] == objectToRemove)
                interactionsToRemove[counter] = interaction;
            counter++;
        }

        for (int x =0, objectIndex =0; x < interactionsToRemove.Length ;x++)
        {
            interactionPoolObjectReferences.RemoveAt(x + objectIndex);
            interactionPool.Remove(interactionsToRemove[x]);
            objectIndex -= 1;
        }
        UpdateInteractionsPool();
        UpdateExecutionBars();
    }

    public void SetInteractableObject(InteractableObject _interactableObject)
    {
        interactableObject = _interactableObject;
    }
    public void ClearAndUpdateInteractionPool()
    {
        interactionPool.Clear();
        interactionPoolObjectReferences.Clear();
        UpdateInteractionsPool();
        UpdateInteractionsPoolBottom();
        UpdateInteractionsPoolMask();
        UpdateExecutionBars();
    }

    private void UpdateExecutionBars()
    {
        var execBar = executionBars.transform;
        var offset = new Vector3(0,10,0);
        for (int x=0;x<executionBars.transform.childCount;x++)
        {
            var amntOfBars = executionBars.transform.childCount;
            var amntOfInteractions = interactionPool.Count;
            
            if (amntOfBars<=amntOfInteractions)
            {
                var thisBar = executionBars.transform.GetChild(x);
                var newPosition = execBar.localPosition + offset;
                newPosition.y = newPosition.y - (25f * x);
                thisBar.localPosition = newPosition;
            }
            else
            {
                for (int i = amntOfBars; i > amntOfInteractions; i--)
                { 
                    Destroy(executionBars.transform.GetChild(x).gameObject);
                }
            }

        }
    }
    private void UpdateInteractionsPoolBottom()
    {
        var newPosition = poolBottom.transform.localPosition;
        newPosition.y = -(interactionPool.Count * 30);
        poolBottom.transform.localPosition = newPosition;
    }
    private void UpdateInteractionsPoolMask()
    {
        var newValue = 475;
        newValue = newValue - (interactionPool.Count * 30);
        var newPadding = interactionsPoolMask.padding;
        newPadding.y = newValue;
        interactionsPoolMask.padding = newPadding;
    }
    public void EmptyOptionExecutionBar(int option)
    {
        var newBar = executionBars.transform.GetChild(option).GetChild(1);
        var barImage = newBar.GetComponent<Image>();
        barImage.fillAmount -=.01f;
        canExecute = false;
    }
    public void FillOptionExecutionBar(int option)
    {
        var interaction = interactableObject.Interactions[option];

        InteractionTypes.executionSpeeds.TryGetValue(interaction, out var interactionSpeed);
        
        var newBar = executionBars.transform.GetChild(option).GetChild(1);
        var barImage = newBar.GetComponent<Image>();
        
        if (barImage.fillAmount > .99f)
            canExecute = true;
        
        barImage.fillAmount +=(.01f*interactionSpeed);
    }
    public void ResetOptionExecutionBar(int option)
    {
        var newBar = executionBars.transform.GetChild(option).GetChild(1);
        var barImage = newBar.GetComponent<Image>();
        barImage.fillAmount =0;
        canExecute = false;
    }
    private void UpdateInteractionsPool()
    {
        string interactionsString = "";
        string interactionObjectName = "";
        var interactionCount = 0;
        
        if (interactionPoolObjectReferences.Count>=1)
            interactionObjectName = interactionPoolObjectReferences[0].name;
        
        foreach (var interaction in interactionPool)
        {
            var thisOption = interaction;
            interactionsString +=  $"\n{thisOption}";
            interactionCount++;
        }

        UpdateInteractionsPoolBottom();
        UpdateInteractionsPoolMask();
        UpdateAreaRect();
        UpdateExecutionBars();
        interactionsPoolText.text = interactionsString;
        interactionsPoolTitle.text = interactionObjectName;
        
        if(interactionsPoolText.text == "")
            InteractionPoolMouseSelection.Instance.gameObject.SetActive(false);
        else
            InteractionPoolMouseSelection.Instance.gameObject.SetActive(true);
    }

    private IEnumerator CheckUnHeldExecutionBars()
    {
        var amntOfBars = executionBars.transform.childCount;
        
        if (amntOfBars == 0)
            yield break;
        
        var pressedBar = InputActions.GetNumberPressed();
        for (int x = 0; x < amntOfBars; x++)
        {
            var bar = executionBars.transform.GetChild(x);
            if (pressedBar!=x)
                EmptyOptionExecutionBar(x);
        }

    }

    public void SetCanExecute(bool state)
    {
        canExecute = state;
    }
    private void UpdateAreaRect()
    {
        var newBottom = ((interactionPool.Count + 1) * -30);
        var newRect = areaRect.GetComponent<RectTransform>().rect;
        newRect.yMin = newBottom;
        areaRect.GetComponent<RectTransform>().rect.Set(newRect.x,newRect.y,newRect.width,newRect.height);
    }
    public void SetInteractionsColliderActive(bool state)
    {
        _boxCollider.enabled = state;
    }
}
