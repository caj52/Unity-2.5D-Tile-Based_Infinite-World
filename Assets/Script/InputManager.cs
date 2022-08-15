using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private InputTarget inputTarget;
    public InputTarget previousInputTarget;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if(inputTarget != null)
            inputTarget.ProcessInput();
    }
    

    public void SetInputTarget(InputTarget newInputTarget)
    {
        UpdatePreviousInputTarget(inputTarget);
        inputTarget = newInputTarget;
    }
    public void ResetToPreviousInputTarget()
    {
       SetInputTarget(previousInputTarget);
    }
    private void UpdatePreviousInputTarget(InputTarget previous)
    {
        previousInputTarget = previous;
    }
}
