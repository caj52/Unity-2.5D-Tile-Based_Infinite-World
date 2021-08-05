using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ZoneMesh : MonoBehaviour
{
    /*
     * this class handles the instantiation of zone mesh creation. It also redirects to the classes and methods responsible for texture creation
     * shader assigning, and pretty much anything to do with the physical rendering of zone meshes
     */
    public static int meshx = 32;
    public static int meshy = 32;//this is the size of the chunk meshes
    public static int intensity = 50;//temporary value for adjusting the "hilliness"
    public static Vector3[] vertices = new Vector3[(meshx + 1) * (meshy + 1)];
    public static int[] triangles = new int[meshx * meshy * 6];
    public static Vector2[] uvs = new Vector2[vertices.Length];
    public static Vector3Int startcoords;
    public static Vector3Int localcoord;
    public static GameObject bmanager;
    public static GameObject thiszone;
    public static GameObject thischunk;
    public BendManager bend;
    public static float[,] zoneelev;
    public static BoxCollider chunkcollider;
    public static MeshRenderer ren;
    public static MeshFilter fil;
    public static Collider col;
    public static BoxCollider drawdistancecol;
    public static int vert;
    public static int tris;
    public static string zonetobuild;

    bool ingame;
    public void setzone(string zone)
    {
        zonetobuild = zone;
    }

    public IEnumerator CreateMesh(int[] zonedata)
    {
        ingame = PlayerPrefsX.GetBool("ingame");
        startcoords = ZDataInterpolate.Interpolate(zonetobuild, "startingcoords");
        localcoord = ZDataInterpolate.Interpolate(zonetobuild, "zonecoords");
        bmanager = GameObject.Find("ZoneManager");
        thiszone = new GameObject(zonetobuild);
        thiszone.tag = "Terrain_Mesh";
        zoneelev = ZoneElevationsCalculator.GenElevation(zonetobuild);
        thiszone.transform.SetParent(bmanager.transform);
        thiszone.AddComponent<Rigidbody>();
        thiszone.GetComponent<Rigidbody>().isKinematic = true;
        drawdistancecol =thiszone.AddComponent<BoxCollider>();
        drawdistancecol.center = new Vector3(64,-10,-64);
        drawdistancecol.size = new Vector3(128,1,128);

        thiszone.transform.position = new Vector3(localcoord.x * 128, 0, localcoord.y * 128);

        for (int chunky = 1, chunknum = 1; chunky < 5; chunky++)
        {
            for (int chunkx = 1; chunkx < 5; chunkx++, chunknum++)
            {
                int difx = (chunkx - 1) * meshx;
                int dify = (chunky - 1) * meshy;
                thischunk = new GameObject("Chunk X" + chunkx + "Y" + (-chunky));
                thischunk.transform.SetParent(thiszone.transform);
                ren = thischunk.AddComponent<MeshRenderer>();
                fil = thischunk.AddComponent<MeshFilter>();
                ren.material.shader = bend.BendWorld(ren.material);
                ren.material.SetTexture("Texture2D_8FA3A0D6", ZoneTexture.CreateTexture(chunknum,zonedata));//this assigns the texture through the shader
                //by default, unity makes me use Texture2D_8FA3A0D6 as the name.
                Mesh thismesh = new Mesh();
                fil.mesh = thismesh;
                col = thischunk.AddComponent<MeshCollider>();
                for (int x = 0, i = 0; x <= meshx; x++)
                {
                    for (int z = 0; z >= -meshy; z--)
                    {
                        float y = zoneelev[-z + dify, x + difx];
                        vertices[i] = new Vector3(startcoords.x + difx + x, y * intensity, startcoords.y - dify + z);
                        uvs[i] = new Vector2((float)x / meshx, (float)z / -meshy);
                        i++;
                    }
                    if (ingame) {
                        yield return null;
                    }
                }
                vert = 0;
                tris = 0;
                for (int x = 0; x < meshy; x++)
                {
                    for (int z = 0; z < meshx; z++)
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
                    if (ingame)
                    {
                        yield return null;
                    }
                }
                thismesh.vertices = vertices;
                thismesh.triangles = triangles;
                thismesh.uv = uvs;
                thismesh.RecalculateNormals();
            }
        }
        thiszone.SetActive(false);
        thiszone.SetActive(true);
        yield return null;
    }

    public void MeshStitcher()
    {

    }

    public static void CombineTrees()
    {
        //Lists that holds mesh data that belongs to each submesh
        List<CombineInstance> renderedzones = new List<CombineInstance>();
        GameObject[] thislist = GameObject.FindGameObjectsWithTag("Terrain_Mesh");
        //Loop through the array with trees
        for (int i = 0; i < thislist.Length; i++)
        {
            GameObject currentTree = thislist[i];

            //Deactivate the tree 
            currentTree.SetActive(false);

            //Get all meshfilters from this tree, true to also find deactivated children
            MeshFilter[] meshFilters = currentTree.GetComponentsInChildren<MeshFilter>(true);

            //Loop through all children
            for (int j = 0; j < meshFilters.Length; j++)
            {
                MeshFilter meshFilter = meshFilters[j];

                CombineInstance combine = new CombineInstance();

                combine.mesh = meshFilter.mesh;
                combine.transform = meshFilter.transform.localToWorldMatrix;

                //Add it to the list of leaf mesh data
                renderedzones.Add(combine);
            }
        }
    }
}