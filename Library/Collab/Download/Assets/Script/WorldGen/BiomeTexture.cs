using UnityEngine;
using UnityEditor;
using System;
public class BiomeTexture : MonoBehaviour
{
    public static int spriteindex;
    public static int lastindex;
    public static int pixx;
    public static int pixy;
    public static string[] thischunk;
    public static Color[] throwpix = null;
    public static Rect throwloc;
    public static Sprite[] spriteSheetSprites = Resources.LoadAll<Sprite>("OverworldTex\\Grassland@128x128");
    public static Texture CreateTexture(string biometobuild,int chunknum)
    {
           Texture2D chunktex = new Texture2D(4096, 4096);
            thischunk = BData.ReadBData("CTiles" + chunknum);

            for (int chunkx = 1; chunkx <= 32; chunkx++)
            {
                for (int chunky = 1; chunky <= 32; chunky++)
                {
                    pixx =(chunkx - 1) * 128;
                    spriteindex = Convert.ToInt32(KeyFind.StringKeysFind(thischunk[chunkx - 1 + ((chunky - 1) * 32)], TileKeys.TileURLKeys()).Substring(18));
                    if (spriteindex!=lastindex)
                    {
                        throwloc = spriteSheetSprites[spriteindex].rect;
                        throwpix = spriteSheetSprites[spriteindex].texture.GetPixels(Convert.ToInt32(throwloc.x), Convert.ToInt32(throwloc.y), Convert.ToInt32(throwloc.width), Convert.ToInt32(throwloc.height));
                    }
                    pixy = (chunky-1) * 128;
                    chunktex.SetPixels(pixx, pixy, 128, 128, throwpix);
                    lastindex = spriteindex;
                }
                lastindex = -1;
            }
        chunktex.Apply();
        return chunktex;
    }
}
