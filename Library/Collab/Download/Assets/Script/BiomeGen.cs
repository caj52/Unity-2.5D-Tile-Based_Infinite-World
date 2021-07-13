using UnityEngine;

public class BiomeGen : MonoBehaviour
{
    string thisbiometype;
    float[] fchunktypes;
    string[] schunktypes;
    public void Builder(string biometobuild)//acts as the manager, redirecting to different biome building classes.
    {
        //NullBiomesCheck.CreateNullBiomes(biometobuild);
        BData.WriteBData(biometobuild, "BType", null, BiomeTypeGen.BiomeTypePick(biometobuild));
        thisbiometype = BData.ReadBData("BType")[0];
        fchunktypes = PlayerPrefsX.TwoDimArraytoArray(PerlinGen.Generate(PerlinArrays.ChunkTypes(biometobuild)));                                                                                                                     
        schunktypes = ChunkTypeGen.ChunkPick(fchunktypes);
        BData.WriteBData(biometobuild, "CTypes", schunktypes, null);
        TilesGen.TilesArray(biometobuild);
        //TilesGen.ElevationsRewrite(biometobuild);
        //TilesGen.RulesRewrite(biometobuild);  
        BiomeMesh.CreateMesh(biometobuild);
        //BData.ClearBHelper();
    }

    public void Loader()
    {

    }
}
