using UnityEngine;
public class CameraPixelizer : MonoBehaviour
{
    public Material pixelizerMaterial;
    private void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;
        Camera.main.targetTexture.format = RenderTextureFormat.ARGBHalf;
    }
    void OnRenderImage (RenderTexture source, RenderTexture destination) 
    {
        RenderTexture buffer = RenderTexture.GetTemporary(source.width, source.height, 24);
        Graphics.Blit(source, buffer, pixelizerMaterial);  
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
}
