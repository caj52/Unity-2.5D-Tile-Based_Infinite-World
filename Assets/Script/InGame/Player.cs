using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public Creature creature;
    private void Start()
    {
        UpdateWorldWindowPosition();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var moved = false;
        if (Input.GetKey(KeyCode.W))
        {
            creature.Move(transform.forward);
            moved = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            creature.Move(-transform.forward);
            moved = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            creature.Move(transform.right);
            moved = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            creature.Move(-transform.right);
            moved = true;
        }
        if(moved)
            UpdateWorldWindowPosition();
    }

    public void UpdateWorldWindowPosition()
    {
        OverWorldMesh.Instance.SetWorldWindowPosition(transform.position);
    }
}
