using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Set : MonoBehaviour
{
    public Texture2D cursorTexture;
    Vector2 hotspot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture,hotspot,CursorMode.Auto);
    }
}


