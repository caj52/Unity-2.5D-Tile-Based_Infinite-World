using System;
using UnityEngine;
public class PressButtonUI : MonoBehaviour
{
    //Simple utility class that handles the appearance of abuttone being pressed
    public GameObject shadow;
    public GameObject button;
    private Vector3 startingPosition;

    private void Awake()
    {
        startingPosition = button.transform.localPosition;
    }

    public void a()
    {
        Debug.Log("ahh");
        button.transform.localPosition = shadow.transform.localPosition;
    }
    private void OnMouseUp()
    {
        button.transform.localPosition = startingPosition;
    }
}