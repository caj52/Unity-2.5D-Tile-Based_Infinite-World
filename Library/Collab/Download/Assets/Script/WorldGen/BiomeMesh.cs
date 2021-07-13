using UnityEngine;

public class BiomeMesh : MonoBehaviour
{
    /*
     * this class handles the instantiation of biome mesh creation. It also redirects to the classes and methods responsible for texture creation
     * shader assigning, and pretty much anything to do with the physical rendering of biome meshes
     */
    public static int meshx = 32;
    public static int meshy = 32;//this is the size of the chunk meshes
    public static int intensity = 20;//temporary value for adjusting the "hilliness"
    public static Vector3[] vertices = new Vector3[(meshx + 1) * (meshy + 1)];
    public static int[] triangles = new int[meshx * meshy * 6];
    public static Vector2[] uvs = new Vector2[vertices.Length];
    public static Vector3Int startcoords;
    public static Vector3Int localcoord;
    public static GameObject bmanager;
    public static GameObject thisbiome;
    public static GameObject thischunk;
    public static BendManager bend = GameObject.Find("WorldBend").GetComponent<BendManager>();
    public static float[,] biome;
    public static BoxCollider chunkcollider;
    public static MeshRenderer ren;
    public static MeshFilter fil;
    public static Collider col;
    public static int vert;
    public static int tris;

    public static void CreateMesh(string biometobuild)
    {
        startcoords = BDataInterpolate.Interpolate(biometobuild, "startingcoords");
        localcoord = BDataInterpolate.Interpolate(biometobuild, "biomecoords");
        bmanager = GameObject.Find("BiomeManager");
        thisbiome = new GameObject(biometobuild);
        biome = PerlinGen.Generate(PerlinArrays.Elevations(biometobuild));
        thisbiome.transform.SetParent(bmanager.transform);
        thisbiome.transform.position = new Vector3(localcoord.x*128,0, localcoord.y * 128);


        //thisbiome.AddComponent<BiomeTrigger>();

        for (int chunky = 1,chunknum=1; chunky < 5; chunky++)
        {
            for (int chunkx = 1; chunkx < 5; chunkx++,chunknum++)
            {
                int difx = (chunkx - 1) * meshx;
                int dify = (chunky - 1) * meshy;
                thischunk = new GameObject("Chunk X"+chunkx+"Y"+(-chunky));
                thischunk.transform.SetParent(thisbiome.transform);
                ren = thischunk.AddComponent<MeshRenderer>();
                fil = thischunk.AddComponent<MeshFilter>();
                ren.material.shader = bend.BendWorld(ren.material);
                ren.material.SetTexture("Texture2D_8FA3A0D6", BiomeTexture.CreateTexture(biometobuild, chunknum));//this assigns the texture through the shader
                //by default, unity makes me use Texture2D_8FA3A0D6 as the name.
                Mesh thismesh = new Mesh();
                fil.mesh = thismesh;
                col = thischunk.AddComponent<MeshCollider>();
                for (int x = 0, i = 0; x <= meshx; x++)
                {
                    for (int z = 0; z >= -meshy; z--)
                    {
                        float y = biome[-z + dify, x + difx];
                        vertices[i] = new Vector3(startcoords.x + difx + x, y * intensity, startcoords.y - dify + z);
                        uvs[i] = new Vector2((float)x / meshx, (float)z / -meshy);
                        i++;
                    }
                }
                vert = 0;
                tris = 0;
                for (int z = 0; z < meshy; z++)
                {
                    for (int x = 0; x < meshx; x++)
                    {
                        triangles[tris] = vert;
                        triangles[tris + 1] = vert + meshx + 1;
                        triangles[tris + 2] = vert + 1;
                        triangles[tris + 3] = vert + 1;
                        triangles[tris + 4] = vert + meshx + 1;
                        triangles[tris + 5] = vert + meshx + 2;
                        tris += 6;
                        vert++;
                    }
                    vert++;
                }
                thismesh.vertices = vertices;
                thismesh.triangles = triangles;
                thismesh.uv = uvs;
                thismesh.RecalculateNormals();
            }
        }
        thisbiome.SetActive(false);
        thisbiome.SetActive(true);

    }
}