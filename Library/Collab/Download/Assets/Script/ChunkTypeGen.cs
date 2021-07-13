
public class ChunkTypeGen
{
    //this class takes an array of float values as a parameter. This float data comes from a perlin generator. This class then uses the Perlininterpolates class 
    //to convert each entry into its string equivalent. IE float=.7-->"plain". It logs these entries in an array and returns the new string array.
    public static string[] ChunkPick(float[] perlinvalues) {

        string[] localarray = new string[16];

        for (int chunkloop=0; chunkloop<16;chunkloop++)
        {
            localarray[chunkloop] = PerlinInterpolates.ChunkTypes(perlinvalues[chunkloop]);
        }


        
        return localarray;
    }
}
