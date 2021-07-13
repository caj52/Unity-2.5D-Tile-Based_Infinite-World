using UnityEngine;

public class ZoneGen : MonoBehaviour
{
    public ZoneMesh zmesh;
    public int[] zonedata;
    public void Builder(string zonetobuild)//acts as the manager, redirecting to different zone building classes.
    {
        zonedata = new int[16384];
        //ZData.InitData();
        zonedata = TilesGen.InitZoneBase(zonetobuild);
        //TilesGen.ElevationsRewrite(zonetobuild);
        //TilesGen.RulesRewrite(zonetobuild);  
        zmesh.setzone(zonetobuild);
        StartCoroutine(zmesh.CreateMesh(zonedata));
       // WorldStuff.Objects_ZoneSubTypes(zonetobuild);
        //ZData.DumpBuildHelper();
    }

    public void Loader()
    {

    }
}
