using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * just a little organization class that acts as a middleman between the
 * gender button press and the CCDraw class. It performs a CCDraw call,
 * providing the correct variables depending on which gender was
 * selected. it also makes a call to CCStatemachine to set the state to body.
 */ 
public class CCInstantiate : MonoBehaviour
{
    CCDraw ccdraw;
    CCStateMachine statemac;
    private void Start()
    {
        ccdraw = GameObject.Find("CreationMaster").GetComponent<CCDraw>();
        statemac = GameObject.Find("Steps").GetComponent<CCStateMachine>();
    }
    public void Girl()
    {
        ccdraw.Character(0,null ,"Girl");
        ccdraw.localgender = "girl";
        statemac.setstate("Body");
    }

    public void Boy()
    {
        ccdraw.Character(0, null, "Boy");
        ccdraw.localgender = "boy";
        statemac.setstate("Body");
    }
}
