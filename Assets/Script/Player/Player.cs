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
    public InventoryObjectType.InventoryObject[] quickAccess = new InventoryObjectType.InventoryObject[4];
    public void Init()
    {
        UpdateWorldWindowPosition();

        creature = GetComponent<Creature>();
        creature.Init();
        
        InputManager.Instance.SetInputTarget(this);
        Instance = this;
        
        InitializeQuickAccessInventory();
        QuickAccessInventory.Instance.UpdateInventoryImages();
    }

    private void InitializeQuickAccessInventory()
    {
        for (int x = 0; x < 3; x++)
            quickAccess[x] = InventoryObjectType.InventoryObject.None;
        
        
        quickAccess[0] = InventoryObjectType.InventoryObject.Apple;
    }
    public void UpdateWorldWindowPosition()
    {
        OverWorldMesh.Instance.SetWorldWindowPosition(transform.position);
    }

    private void OnTriggerStay(Collider other)
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
        var interactions = interactableObject.GetCurrentInteractions();
        var interactionsPool = InteractionsPool.Instance;
        interactionsPool.AddOptionsToPool(interactions,interactableObject);
    }
    public virtual void ProcessInput()
    {
        if(inputFrozen)
            return;
        
        HandleMovement();
        HandleRotation();
        HandleNumbersInput();
        HandleKeysInput();
        HandleScrollBar();
    }

    private void HandleScrollBar()
    {
        var scrollIncrement = Mathf.RoundToInt(-InputActions.ScrollWheelDelta.y);
        InteractionPoolMouseSelection.Instance.IncrementScrollBarTrackerAndUpdatePosition(scrollIncrement);
    }
    private void HandleKeysInput()
    {
        if (InputActions.shiftDown)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }
    private void HandleNumbersInput()
    {
        var numberPressed = InputActions.GetNumberPressed();

        if (numberPressed == 6 || numberPressed == 7 || numberPressed == 8 || numberPressed == 9)
            ExecuteToolBarInputLogic(numberPressed);
    }
    private void HandleRotation()
    {
        if (!Cursor.visible)
        {
            float rotateHorizontal = Input.GetAxis("Mouse X");
            transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * -2f);
        }
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
    
    private void ExecuteToolBarInputLogic(int numberPressed)
    {
        if (numberPressed == ToolBarSelectionHand.Instance.currentlySelected)
        {
            ToolBarSelectionHand.Instance.Unselect();
            creature.SetHeldObject(InventoryObjectType.InventoryObject.None);
            InteractionsPool.Instance.ClearAndUpdateInteractionPool();
        }
        else
        {

            ToolBarSelectionHand.Instance.SetCurrentlySelected(numberPressed);

            ToolBarSelectionHand.Instance.SetPositionFromToolbarNumber(numberPressed);

            var objectAtNumber = ToolBarSelectionHand.Instance.GetObjectFromKeyInput(numberPressed);
            creature.SetHeldObject(objectAtNumber);

            var heldObject = new InteractableObject();
            InventoryObjectType.InventoryObjectInteractions.TryGetValue(objectAtNumber, out var interactions);
            InventoryObjectType.objectNameStrings.TryGetValue(objectAtNumber, out var objectName);

            heldObject.name = objectName;
            heldObject.Interactions = interactions;
            InteractionsPool.Instance.ClearAndUpdateInteractionPool();
            AddInteractionsToPool(heldObject);
        }
    }
    public void SetFreezeInput(bool state)
    {
        inputFrozen = state;
    }
}
