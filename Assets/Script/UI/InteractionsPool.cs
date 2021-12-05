using System.Collections;
using System.Collections.Generic;
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
    public GameObject interactionsPoolObjectName;
    [HideInInspector]public Dictionary<string,int> interactionPool = new Dictionary<string, int>();
    [HideInInspector]public List<InteractableObject> interactionPoolObjectReferences;

    public void Init()
    {
        Instance = this;
        interactionsPoolText = interactionsPoolTextObject.GetComponent<Text>();
        interactionsPoolTitle = interactionsPoolObjectName.GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        UpdateInteractionsPool();
        if(!inCoroutine) 
            StartCoroutine(CheckUnHeldExecutionBars());
    }

    public void ExecuteInteractionOption(int interactionToExecute)
    {
        
    }
    public void AddOptionsToPool(Dictionary<string,int> interactionsToAdd, InteractableObject objectReference)
    {
        var counter = 0;
        foreach (var keyValuePair in interactionsToAdd)
        {
            
            interactionPool.Add(keyValuePair.Key, keyValuePair.Value);
            
            interactionPoolObjectReferences.Add(objectReference);
            
            var newBar = Instantiate(executionBar);
            newBar.transform.parent = executionBars.transform;
            counter++;
        } 
    }
    public void RemoveOptionsFromPool(InteractableObject objectToRemove)
    {
        int counter=0;
        string[] keysToRemove = new string[interactionPool.Count];
        foreach (var keyValuePair in interactionPool)
        {
            if (interactionPoolObjectReferences[counter] == objectToRemove)
                keysToRemove[counter] = keyValuePair.Key;
            counter++;
        }

        for (int x =0, objectIndex =0; x < keysToRemove.Length ;x++)
        {
            if(keysToRemove[x] == null)
                continue;
            interactionPoolObjectReferences.RemoveAt(x + objectIndex);
            interactionPool.Remove(keysToRemove[x]);
            objectIndex -= 1;
        }
        
        var difference = executionBars.transform.childCount - interactionPoolObjectReferences.Count;
        var lastChildIndex = executionBars.transform.childCount - 1;
        for (int x =0;x<difference;x++)
        {
            Destroy(executionBars.transform.GetChild(lastChildIndex-x).gameObject);
        }
        
    }

    private void UpdateExecutionBars()
    {
        var execBar = executionBars.transform;
        var offset = new Vector3(0,10,0);
        for (int x=0;x<executionBars.transform.childCount;x++)
        {
           var thisBar =  executionBars.transform.GetChild(x);
           var newPosition = execBar.localPosition + offset;
           newPosition.y = newPosition.y - (25f * x);
           thisBar.localPosition = newPosition;

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
    }
    public void FillOptionExecutionBar(int option)
    {
        var newBar = executionBars.transform.GetChild(option).GetChild(1);
        var barImage = newBar.GetComponent<Image>();
        barImage.fillAmount +=.01f;
    }
    private void UpdateInteractionsPool()
    {
        string interactionsString = "";
        string interactionObjectName = "";
        var interactionCount = 0;
        
        if (interactionPoolObjectReferences.Count>=1)
            interactionObjectName = interactionPoolObjectReferences[0].name;
        
        foreach (var keyValuePair in interactionPool)
        {
            var thisOption = keyValuePair.Key;
            interactionsString += $"\n{interactionCount}";
            if (interactionCount == 1)
                interactionsString += "/RMB";
            interactionsString +=  $": {thisOption}";

            
            
            interactionCount++;
        }

        UpdateInteractionsPoolBottom();
        UpdateInteractionsPoolMask();
        UpdateExecutionBars();
        interactionsPoolText.text = interactionsString;
        interactionsPoolTitle.text = interactionObjectName;
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
}
