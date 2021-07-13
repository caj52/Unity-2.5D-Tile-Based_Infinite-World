public class BiomeTypeGen
{
    
    public static string BiomeTypePick(string biometobuild) //runs a variety of different classes to procedurally generate a "Biome Type" for the biome given as a parameter.
    {
        string biomepick="null";

        float[] perlindata = PerlinArrays.BiomeTypes(biometobuild);
        float perlinreturn = PerlinGen.Generate(perlindata)[0,0];
        biomepick=PerlinInterpolates.BiomeTypes(perlinreturn);




        return biomepick;
    }
}
