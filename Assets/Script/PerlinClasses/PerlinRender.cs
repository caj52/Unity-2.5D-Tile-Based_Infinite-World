using UnityEngine;
public class PerlinRender : MonoBehaviour 
    /*this class is a debug and testing utility. It uses perlingen() as a parameter and renders it to the middle of the screen. Just so i can see what
     * a specific perlin map looks like before i impliment it into a feature.
     */



{
    public GameObject me;
    public Shader shader;
    public int pixWidth = 128;
    public int pixHeight = 128;
    public float scale = 10.0F;
    public float xOrg;
    public float yOrg;
    public float frequency;
    public float lacunarity;
    public float persistence;
    public int octaves;
    public float minrange;
    public float maxrange;
    public bool showrange;
    public bool threedimensional;
    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;
    float[] perlindata = new float[9];
    Texture2D perlincheck;
    int mousex;
    int mousey;
    public void Start()
    {
        rend = GetComponent<Renderer>();
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
        rend.material.shader = shader;
    }


    void Change(){
        int xsize = ((PerlinGen.Generate(perlindata).Length) / pixHeight);
        int ysize = ((PerlinGen.Generate(perlindata).Length) / pixWidth);
        float [,]perlinarray = PerlinGen.Generate(perlindata);
        for (int loopy = 0; loopy < xsize; loopy++)
        {
            for (int loopx = 0; loopx < ysize; loopx++)
            {
                float sample = perlinarray[loopy, loopx];
                if (showrange) {
                    if (sample < minrange || sample > maxrange)
                    {
                        sample = 0f;
                    }
                    else
                    {
                        sample = 1f;
                    }
                }
                pix[loopy * noiseTex.width + loopx] = new Color(sample, sample, sample);
            }
        }

        noiseTex.SetPixels(pix);

        noiseTex.Apply();
        if (threedimensional)
        {
            Vector3[] vertices = new Vector3[(pixWidth + 1) * (pixHeight + 1)];
            int[] triangles = new int[pixWidth * pixHeight * 6];
            Mesh thismesh;
            thismesh = new Mesh();
            float[,] biome = PerlinGen.Generate(perlindata);
            me.GetComponent<MeshFilter>().mesh = thismesh;
            for (int x = 0, i = 0; x <= pixWidth; x++)
            {
                for (int z = 0; z >= -pixHeight; z--)
                {
                    float y;

                    if (x == 64 && z == -64)
                    {
                        y = biome[-z - 1, x - 1];
                    }
                    else if (x == 64)
                    {
                        y = biome[-z, x - 1];
                    }
                    else if (z == -64)
                    {
                        y = biome[-z - 1, x];
                    }
                    else
                    {
                        y = biome[-z, x];
                    }
                    vertices[i] = new Vector3(x, y * 5, z);
                    i++;
                }
            }

            int vert = 0;
            int tris = 0;

            for (int z = 0; z < pixHeight; z++)
            {
                for (int x = 0; x < pixWidth; x++)
                {
                    triangles[tris] = vert;
                    triangles[tris + 1] = vert + pixWidth + 1;
                    triangles[tris + 2] = vert + 1;
                    triangles[tris + 3] = vert + 1;
                    triangles[tris + 4] = vert + pixWidth + 1;
                    triangles[tris + 5] = vert + pixWidth + 2;
                    tris += 6;
                    vert++;
                }
                vert++;
            }
            thismesh.vertices = vertices;
            thismesh.triangles = triangles;
        }

    }



    void Update()
    {
        perlindata[0] = pixWidth;
        perlindata[1] = pixHeight;
        perlindata[2] = scale;
        perlindata[3] = xOrg;
        perlindata[4] = yOrg;
        perlindata[5] = frequency;
        perlindata[6] = lacunarity;
        perlindata[7] = persistence;
        perlindata[8] = octaves;

        
        mousex = Mathf.FloorToInt(Input.mousePosition.x);
        mousey = Mathf.FloorToInt(Input.mousePosition.y);

        Change();

    }






    private void OnMouseDrag()
    {
        perlincheck = ScreenCapture.CaptureScreenshotAsTexture();//saves a screen shot as a texture.
        print("Float value of this pixel is: "+perlincheck.GetPixel(mousex,mousey).r); //returns the float color of the pixel at the mouse position
    }



}