using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar_Input : MonoBehaviour
{
    string toolnum;
    public GameObject arrow;
    void Update()
    {
        MoveArrow();
        
    }

    void MoveArrow()
    {
        if (Input.anyKeyDown)
        {
            toolnum = Input.inputString;
            try
            {
                arrow.transform.position = new Vector3(GameObject.Find(toolnum).transform.position.x, arrow.transform.position.y, arrow.transform.position.z);
            }
            catch
            {
            }
        }
    }
}
