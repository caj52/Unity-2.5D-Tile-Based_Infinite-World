using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private InputTarget inputTarget;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        inputTarget.ProcessInput();
    }
    

    public void SetInputTarget(InputTarget newInputTarget)
    {
        inputTarget = newInputTarget;
    }
}
