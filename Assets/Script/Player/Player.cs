using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour, InputTarget
{
    public static Creature creature;
    public static Player Instance;
    private bool inputFrozen;
    private bool continuousMouseHold;
    public InventoryObjectType.InventoryObject[] quickAccess = new InventoryObjectType.InventoryObject[5];
    public void Init()
    {
        UpdateWorldWindowPosition();

        creature = GetComponent<Creature>();
        creature.Init();
        
        InputManager.Instance.SetInputTarget(this);
        Instance = this;
        
        QuickAccessInventory.Instance.UpdateInventoryImages();
    }
    
    public void UpdateWorldWindowPosition()
    {
        OverWorldMesh.Instance.SetWorldWindowPosition(transform.position);
    }
    

    #region Interactions
    private void OnTriggerEnter(Collider other)
    {
        if (creature.heldObject == InventoryObjectType.InventoryObject.None)
        {
            if (other.TryGetComponent(out InteractableObject interactableObject))
            {
                AddInteractionsToPool(interactableObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out InteractableObject interactableObject))
        {
            var interactionsPool = InteractionsPool.Instance;
            interactionsPool.RemoveOptionsFromPool(interactableObject);
        }
    }
    private void AddInteractionsToPool(InteractableObject interactableObject)
    {
        var interactionsPool = InteractionsPool.Instance;
        interactionsPool.SetInteractableObject(interactableObject);
        interactionsPool.AddOptionsToPool();
    }
    private void ResetInteractionsSystem()
    {
        ToolBarSelectionHand.Instance.Unselect();
        creature.SetHeldObject(InventoryObjectType.InventoryObject.None);
        InteractionsPool.Instance.SetInteractionsColliderActive(true);
        InteractionsPool.Instance.ClearAndUpdateInteractionPool();
    }
    #endregion
    #region InputFunctions
    public virtual void ProcessInput()
    {
        if(inputFrozen)
            return;
        
        HandleMovement();
        HandleRotation();
        HandleNumbersInput();
        HandleKeysInput();
        HandleScrollBar();
        HandleMouseInput();
    }
    private void HandleMovement()
    {
        var moved = false;
        if (InputActions.wDown)
        {
            creature.Move(transform.forward);
            moved = true;
        }
        if (InputActions.sDown)
        {
            creature.Move(-transform.forward);
            moved = true;
        }
        if (InputActions.dDown)
        {
            creature.Move(transform.right);
            moved = true;
        }
        if (InputActions.aDown)
        {
            creature.Move(-transform.right);
            moved = true;
        }
        if(InputActions.aUp||InputActions.wUp||InputActions.sUp||InputActions.dUp)
            creature.StopMoveImmediate();
        if(moved)
            UpdateWorldWindowPosition();
    }
    private void HandleRotation()
    {
        if (!Cursor.visible)
        {
            float rotateHorizontal = Input.GetAxis("Mouse X");
            transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * -2f);
        }
    }
    private void HandleNumbersInput()
    {
        var numberPressed = InputActions.GetNumberPressed();

        if (numberPressed == 6 || numberPressed == 7 || numberPressed == 8 || numberPressed == 9 || numberPressed == 0)
            ExecuteToolBarInputLogic(numberPressed);
    }

    private void HandleKeysInput()
    {
        if (InputActions.shiftDown)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }
    private void HandleScrollBar()
    {
        var scrollIncrement = Mathf.RoundToInt(-InputActions.ScrollWheelDelta.y);
        
        if(scrollIncrement!=0)
            InteractionPoolMouseSelection.Instance.IncrementScrollBarTrackerAndUpdatePosition(scrollIncrement);
    }
   
    private void HandleMouseInput()
    {
        var currentChoice = InteractionPoolMouseSelection.Instance.scrollBarTracker;
        if (InputActions.lmbDown)
            if(InteractionsPool.Instance.interactionPool.Count>0)
                if (!Cursor.visible&&!continuousMouseHold)
                {
                    if (InteractionsPool.Instance.canExecute)
                    {
                        InteractionPoolMouseSelection.Instance.ExecuteCurrentSelection();
                        continuousMouseHold = true;
                    }
                    InteractionsPool.Instance.FillOptionExecutionBar(currentChoice);
                }

        if (InputActions.lmbReleased)
            continuousMouseHold = false;
    }
    public void ExecuteToolBarInputLogic(int numberPressed)
    {
        if (numberPressed == 0)
            numberPressed = 10;
        
        if (numberPressed == ToolBarSelectionHand.Instance.currentlySelected)
        {
            ResetInteractionsSystem();
        }
        else
        {
            var objectAtNumber = ToolBarSelectionHand.Instance.GetObjectFromKeyInput(numberPressed);


            if (objectAtNumber == InventoryObjectType.InventoryObject.None)
                return;
            
            ToolBarSelectionHand.Instance.Select(numberPressed);
            
            InteractionsPool.Instance.SetInteractionsColliderActive(false);
            creature.SetHeldObject(objectAtNumber);
            
             var interactableObject = InventoryObjectType.GetInteractableObjectFromInventoryObject(objectAtNumber);
             
            InteractionsPool.Instance.ClearAndUpdateInteractionPool();

            AddInteractionsToPool(interactableObject);
        }
    }

    public void UpdateNeedsIcons()
    {
        creature.needsValue.TryGetValue(NeedsTypes.Need.Hunger, out var currentHunger);
        HungerIcon.Instance.UpdateHungerIcon(currentHunger);
    }
    public void SetFreezeInput(bool state)
    {
        inputFrozen = state;
    }
    #endregion
    

}
