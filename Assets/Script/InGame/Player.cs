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
        var w = Input.GetKey(KeyCode.W);
        var a = Input.GetKey(KeyCode.A);
        var s = Input.GetKey(KeyCode.S);
        var d = Input.GetKey(KeyCode.D);
        var wUp = Input.GetKeyUp(KeyCode.W);
        var aUp = Input.GetKeyUp(KeyCode.A);
        var sUp = Input.GetKeyUp(KeyCode.S);
        var dUp = Input.GetKeyUp(KeyCode.D);
        var moved = false;
        if (w)
        {
            creature.Move(transform.forward);
            moved = true;
        }
        if (s)
        {
            creature.Move(-transform.forward);
            moved = true;
        }
        if (d)
        {
            creature.Move(transform.right);
            moved = true;
        }
        if (a)
        {
            creature.Move(-transform.right);
            moved = true;
        }
        if(wUp||aUp||sUp||dUp)
            creature.StopMoveImmediate();
        if(Input.GetMouseButton(1) && Input.mousePosition.x>Screen.width-(Screen.width/4))
            transform.Rotate(0.0f, 5.0f, 0.0f, Space.Self);
        if(Input.GetMouseButton(1) && Input.mousePosition.x<Screen.width/4)
            transform.Rotate(0.0f, -5.0f, 0.0f, Space.Self);
        if(moved)
            UpdateWorldWindowPosition();
    }
    
    public void UpdateWorldWindowPosition()
    {
        OverWorldMesh.Instance.SetWorldWindowPosition(transform.position);
    }
}
