using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This classes basically handles the button clicking effect that occurs
 * when the player clicks any button. It takes the button and its text object
 * as gameobject variables from within the inspector. When the player clicks 
 * the gameobject this script is attached to, it changes the z axis of the object
 * slightly, giving the effect of the object being clicked. It also moves the
 * text accordingly.
 * Also im disorganized so it also has some redirects to CCinstantiate (the initial
 * redirect to the character drawing call) if it detects the button text is the
 * "Boy" or "Girl" gender state buttons.
*/
public class ButtonClick : MonoBehaviour
{
    public GameObject box=null;
    public GameObject boxtext=null;
    public CCStateMachine cstate;
    CCInstantiate Cin;
    CCDraw cdraw; 
    string boxstr;
    public bool state;
    public void Start()
    {
        if (boxtext.TryGetComponent<UnityEngine.UI.Text>(out UnityEngine.UI.Text text))
        {
            boxstr = boxtext.GetComponent<UnityEngine.UI.Text>().text.Trim();
        }

        cstate = GameObject.Find("Steps").GetComponent<CCStateMachine>();
        Cin = GameObject.Find("CreationMaster").GetComponent<CCInstantiate>();
    }
    private void OnMouseDown()
    {
        box.transform.localPosition += new Vector3(0, 0, .02f);
        if (boxtext!=null) {
            boxtext.transform.localPosition += new Vector3(0, 0, .02f);
        }
        if (state) {
            string state = boxtext.GetComponent<UnityEngine.UI.Text>().text.Trim();
            cstate.setstate(state);
        }

    }
    private void OnMouseUp()
    {
        box.transform.localPosition -= new Vector3(0, 0, .02f);
        if (boxtext != null)
        {
            boxtext.transform.localPosition -= new Vector3(0, 0, .02f);
            if (boxstr == "Boy" || boxstr == "Girl")
            {
                box.GetComponent<SelectBox>().button.SetActive(false);
                if (boxstr == "Boy")
                {
                    Cin.Boy();
                }
                else
                {
                    Cin.Girl();
                }
            }
            if (box.transform.parent.name=="Noses")
            {
                cdraw = GameObject.Find("CreationMaster").GetComponent<CCDraw>();
                cstate.nosepicked = true;
                box.transform.parent.transform.Find(cstate.selection).transform.Find("SelectBox").gameObject.SetActive(false);
                cstate.selection = box.name;
                cdraw.NoseUp(box.name.Replace(" ","").ToLower());
            }
            if (box.transform.parent.name == "Hair")
            {
                cdraw = GameObject.Find("CreationMaster").GetComponent<CCDraw>();
                cdraw.hairDraw(box.name);
            }
        }
    }
}
