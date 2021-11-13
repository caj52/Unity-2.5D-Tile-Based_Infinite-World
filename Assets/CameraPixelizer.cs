using UnityEngine;
public class CameraPixelizer : MonoBehaviour
{
    public Material pixelizerMaterial;
    private void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;
    }
    void OnRenderImage (RenderTexture source, RenderTexture destination) 
    {
        Graphics.Blit(source, destination, pixelizerMaterial);
    }
}
