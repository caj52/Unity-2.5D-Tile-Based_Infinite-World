using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTextBox : MonoBehaviour, InputTarget
{
    public static HUDTextBox Instance;
    private Text text;
    private float writingSpeed = 9;
    private bool writing;
    public void Init()
    {
        Instance = this;
        text = GetComponentInChildren<Text>();
    }

    public void ShowText(string textToWrite)
    {
        gameObject.SetActive(true);
        StartCoroutine(WriteText(textToWrite));
        InputManager.Instance.SetInputTarget(this);
    }
    private IEnumerator WriteText(string fullText)
    {
        writing = true;
        float speed = Mathf.Abs((writingSpeed - 10)*.01f);
        
        var textInProgress = String.Empty;
        for (int x =0;x<fullText.Length;x++)
        {
            textInProgress += fullText[x];
            text.text = textInProgress;
            yield return new WaitForSeconds(speed);
        }
        writing = false;
    }

    private void HandleWritingSpeed()
    {
        if (Input.anyKey)
            writingSpeed = 9;
        else
            writingSpeed = 6;
    }

    private void HandleCloseConditions()
    { 
        if (InputActions.anyKey||InputActions.lmbDown)
            if(!writing)
                CloseText();
    }
    public void ProcessInput()
    {
        HandleWritingSpeed();
        HandleCloseConditions();
    }

    private void CloseText()
    {
        gameObject.SetActive(false);
        InputManager.Instance.ResetToPreviousInputTarget();
    }
}
