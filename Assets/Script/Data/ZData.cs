using UnityEngine;
using System.IO;
      [System.Serializable]
public class ZData//this is a json reader/writer for zonedata files.
{
    public static int[] zonetiles;
    public static ZData jsondata = new ZData();
    public static int lastinarray;
    public static void InitData()
    {
        File.WriteAllText(Application.streamingAssetsPath + "\\BuildHelper.json","");
        zonetiles = new int[262144];
        lastinarray = 0;
    }
    public static void CommitToBuildHelper(int[] newcommit)
    {//If you use this method in the improper order, you will break the world.
        string jsonstring;
        jsonstring = File.ReadAllText(Application.streamingAssetsPath + "\\BuildHelper.json");
        JsonUtility.FromJsonOverwrite(jsonstring, jsondata);
        for (int i=0;i<newcommit.Length;i++)
        {
            zonetiles[lastinarray] = newcommit[i];
            lastinarray++;
        }
        jsonstring = JsonUtility.ToJson(jsondata);
        File.WriteAllText(Application.streamingAssetsPath + "\\BuildHelper.json", jsonstring);
    }

    public static int[] ReadBuildHelper()
    {
        int[] returnint;

        string jsonstring;
        jsonstring = File.ReadAllText(Application.streamingAssetsPath + "\\BuildHelper.json");
        JsonUtility.FromJsonOverwrite(jsonstring, jsondata);
        returnint = zonetiles;
        return returnint;
    }
    public static void DumpBuildHelper()
    {
        File.Delete(Application.streamingAssetsPath + "\\BuildHelper.json");
    }

    public static bool Exists(string ZDatafile)
    {
        bool exists = false;
        if (File.Exists(Application.streamingAssetsPath + ZDatafile))
        {
            exists = true;
        }

        return exists;
    }


}