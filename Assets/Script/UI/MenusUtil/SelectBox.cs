using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class just sets a selection boxx outline active/or inactive
 * upon the mouse hovering over it.
 */
public class SelectBox : MonoBehaviour
{
    public GameObject button;
    void OnMouseOver()
    {
        button.SetActive(true);
    }
    void OnMouseExit()
    {
        button.SetActive(false);
    }
}
