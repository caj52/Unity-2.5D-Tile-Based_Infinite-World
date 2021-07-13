using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class operates the eye color selection color wheen. It takes one
 * gameobject as a variable. They "Eyes" character gameobject. This
 * script attaches to the eye selection color wheel. When the mouse scrolls over
 * the attached collider, it takes a picture of the screen and begins
 * tracking the mouse position. When a click occurs, it retrieves a single pixel
 * from the picture using the current mouse coordinates. This allows the player
 * to select a color from the color wheel simply by clicking it.
 */
public class EyeColorWheel : MonoBehaviour
{
    Vector3 mousepos;
    Texture2D screen;
    Color newcol;
    public GameObject eyes;
    void Start()
    {
        screen = ScreenCapture.CaptureScreenshotAsTexture();
    }

    void OnMouseOver()
    {
        screen = ScreenCapture.CaptureScreenshotAsTexture();
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
            newcol = screen.GetPixel(Mathf.RoundToInt(mousepos.x),Mathf.RoundToInt(mousepos.y));
            eyes.GetComponent<SpriteRenderer>().color=newcol;
        }

    }
}
