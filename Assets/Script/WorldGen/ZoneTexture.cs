using UnityEngine;
using UnityEditor;
using System;
public class ZoneTexture : MonoBehaviour
{
    public static int spriteindex;
    public static int lastindex;
    public static int pixx;
    public static int pixy;
    public static int chunksqft = 1024;
    public static int[] thiszone;
    public static Color[] throwpix = null;
    public static Rect throwloc;
    public static Sprite[] spriteSheetSprites = Resources.LoadAll<Sprite>("OverworldTex\\Grassland@128x128");
    public static int[] tkeykey = TileKeys.TileKey();
    public static string[] tkeypath = TileKeys.TilePaths();
    public static Texture CreateTexture(int chunknum,int[] zonedata)
    {
           Texture2D chunktex = new Texture2D(4096, 4096);
           thiszone = zonedata;
            for (int chunkx = 1; chunkx <= 32; chunkx++)
            {
                for (int chunky = 1; chunky <= 32; chunky++)
                {
                    pixx =(chunkx - 1) * 128;
                    spriteindex = KeyFind.SpritesheetKeysFind(thiszone[chunkx - 1 + ((chunky - 1) * 32) + ((chunknum - 1) * chunksqft)], tkeykey, tkeypath);
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
