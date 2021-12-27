using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHUDButtonPress : MonoBehaviour
{
    [SerializeField]private Transform button;
    [SerializeField] private Vector3 pressedPosition;
    private Vector3 buttonInitPosition;
    private bool pressed;
    private void Awake()
    {
        buttonInitPosition = button.localPosition;
    }
    
    public void Press()
    {
        if (!pressed)
        {
            pressed = true;
            button.localPosition = pressedPosition;
            var dif = button.localPosition - pressedPosition;
        }
    }
    public void Release()
    {
        if (pressed)
        {
            pressed = false;
            button.localPosition = buttonInitPosition;
           var dif = button.localPosition - buttonInitPosition;
        }
    }

    public void QuickAccessInventoryPress(int toolbarnum)
    {
       Player.Instance.ExecuteToolBarInputLogic(toolbarnum);
    }
}
