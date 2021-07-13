using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class handles the bouncing arrow next to the different 
 * steps of the creation process. It takes 2 gameobjects, the pre
 * animated arrow, and the box this script is attached to, the box
 * the arrow will be bouncing next to. When the mouse scrolls over
 * the box, it moves to that box to illustrate the players current 
 * mouse position.
 */
public class MoveSelectionArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject box;
    public CCStateMachine cstate;
    public void Start()
    {
        cstate = GameObject.Find("Steps").GetComponent<CCStateMachine>();
    }
    void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) == false)
        {
            arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x, box.transform.localPosition.y, arrow.transform.localPosition.z);
            cstate.setbool(true);
            
        }
    }

    public void OnMouseExit()
    {   
        cstate.setbool(false);
    }

    public void AutoMove()
    {

        if (!cstate.getbool())
        {
            arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x, box.transform.localPosition.y, arrow.transform.localPosition.z);
        }

    }
}
