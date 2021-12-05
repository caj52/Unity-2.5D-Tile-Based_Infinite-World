using System;
using System.Collections.Generic;
using UnityEngine;

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

        Cursor.visible = false;
        InputManager.Instance.SetInputTarget(this);
        Instance = this;
        
        InitializeQuickAccessInventory();
        QuickAccessInventory.Instance.UpdateInventoryImages();
    }

    private void InitializeQuickAccessInventory()
    {
        quickAccess[0] = InventoryObjectType.InventoryObject.Apple;
    }
    public void UpdateWorldWindowPosition()
    {
        OverWorldMesh.Instance.SetWorldWindowPosition(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractableObject interactableObject))
        {
            var interactions = interactableObject.GetCurrentInteractions();
            var interactionsPool = InteractionsPool.Instance;
            interactionsPool.AddOptionsToPool(interactions,interactableObject);
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
    public virtual void ProcessInput()
    {
        if(inputFrozen)
            return;
        
        HandleMovement();
        HandleRotation();
        HandleNumbersInput();
    }

    private void HandleNumbersInput()
    {
        var amntOfBars = InteractionsPool.Instance.executionBars.transform.childCount;
        var numberPressed = InputActions.GetNumberPressed();

        if (numberPressed>=0 && numberPressed<amntOfBars)
            if (InputActions.anyNumDown)
                InteractionsPool.Instance.FillOptionExecutionBar(numberPressed);
        if(InputActions.lmbDown && amntOfBars>0)
            InteractionsPool.Instance.FillOptionExecutionBar(1);
    }
    private void HandleRotation()
    {
        float rotateHorizontal = Input.GetAxis ("Mouse X");
        transform.RotateAround (transform.position, -Vector3.up, rotateHorizontal * -2f); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
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
    public void SetFreezeInput(bool state)
    {
        inputFrozen = state;
    }
}
