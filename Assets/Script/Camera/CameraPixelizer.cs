using System;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraPixelizer : MonoBehaviour
{
    public Material pixelizerMaterial;
    private RenderTexture buffer;
    
    private void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;
    }


    void OnRenderImage (RenderTexture source, RenderTexture destination)
    {
        buffer = RenderTexture.GetTemporary(source.width, source.height, 24);
        var i = source;

        Graphics.Blit( source,buffer,pixelizerMaterial,1);//gets the depth and assigns it to i
        Graphics.Blit( buffer,i,pixelizerMaterial,0);//assigns i to the 
        Graphics.Blit(i, destination);
       
    }

    private void OnPostRender()
    {
        RenderTexture.ReleaseTemporary(buffer);
    }
}
