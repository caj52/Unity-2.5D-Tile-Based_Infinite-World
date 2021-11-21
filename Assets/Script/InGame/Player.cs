using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public Creature creature;

    public void Init()
    {
        UpdateWorldWindowPosition();
    }
    private void Update()
    {
        
        HandleInput();
    }

    private void HandleInput()
    {
        var wDown = Input.GetKey(KeyCode.W);
        var aDown = Input.GetKey(KeyCode.A);
        var sDown = Input.GetKey(KeyCode.S);
        var dDown = Input.GetKey(KeyCode.D);
        var qDown = Input.GetKey(KeyCode.Q);
        var eDown = Input.GetKey(KeyCode.E);
        var wUp = Input.GetKeyUp(KeyCode.W);
        var aUp = Input.GetKeyUp(KeyCode.A);
        var sUp = Input.GetKeyUp(KeyCode.S);
        var dUp = Input.GetKeyUp(KeyCode.D);
        var moved = false;
        if (wDown)
        {
            creature.Move(transform.forward);
            moved = true;
        }
        if (sDown)
        {
            creature.Move(-transform.forward);
            moved = true;
        }
        if (dDown)
        {
            creature.Move(transform.right);
            moved = true;
        }
        if (aDown)
        {
            creature.Move(-transform.right);
            moved = true;
        }
        if(wUp||aUp||sUp||dUp)
            creature.StopMoveImmediate();
        if(eDown)
            transform.Rotate(0.0f, 2.0f, 0.0f, Space.Self);
        if(qDown)
            transform.Rotate(0.0f, -2.0f, 0.0f, Space.Self);
        if(moved)
            UpdateWorldWindowPosition();
    }
    
    public void UpdateWorldWindowPosition()
    {
        OverWorldMesh.Instance.SetWorldWindowPosition(transform.position);
    }
}
