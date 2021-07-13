using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCSpriteCompiler : MonoBehaviour
{
    public GameObject body1;
    public GameObject body2;
    public GameObject eyes;
    public GameObject hair;
    public GameObject torso;
    public GameObject legs;
    Texture2D newtex;
    public void CreateSheet()
    {
        newtex = new Texture2D(1,1);
        
    }
    
}
