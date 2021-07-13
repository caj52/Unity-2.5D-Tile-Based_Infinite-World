using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class handles the rotation state of the character. it attaches to 
 * each of the character rotation arrows. it contains
 * bool variables to determine whether or not it is 
 * attached to a right rotation button, or a left rotation 
 * button. It measures rotation state with an int. the int
 * represents different directions the character could be facing
 * only allowing for a total of 4 different directions
 * the class modifies this int appropriately upon
 * a detected click of the attached gameobject, according to
 * whether or not it was the left or right button.
 */
public class RotationButton : MonoBehaviour
{
    public static int rotatestate = 0;
    public bool leftbutton;
    public bool rightbutton;
    public GameObject cmas;
    CCDraw cdraw;
    private void Start()
    {
        cdraw = cmas.GetComponent<CCDraw>();
    }
    void OnMouseDown()
    {
        if (leftbutton)
        {
            rotatestate -= 1;
        }
        if (rightbutton)
        {
            rotatestate += 1;
        }
        if (rotatestate == -1)
        {
            rotatestate = 3;
        }
        if (rotatestate == 4)
        {
            rotatestate = 0;
        }
        cdraw.Rotate();
    }
}
