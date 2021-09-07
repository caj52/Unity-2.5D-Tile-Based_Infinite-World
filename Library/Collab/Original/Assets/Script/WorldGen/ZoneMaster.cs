using System.Collections;
using UnityEngine;
public class ZoneMaster : MonoBehaviour
{    public IEnumerator Init()//this method is run the first time the main game is run
    {
        ZoneGen zgen = GameObject.Find("ZoneManager").GetComponent<ZoneGen>();
        LoadScreen lsc = GameObject.Find("LoadManager").GetComponent<LoadScreen>();
                lsc.LoadBar("Creating: ZoneX0,Y0");
                yield return null;
                zgen.Builder("ZoneX0,Y0");
        //ZoneMesh.CombineTrees();
        lsc.LoadBar("Done");
        yield return null;
    }

    public IEnumerator LoadGame()
    {


        return null;
    }


}
