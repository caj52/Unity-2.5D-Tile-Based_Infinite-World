using System;

public class CliffTRules
{
    public static string[] Mod(string biometobuild,string[] scanresults,string[] thischunk,int chunknum,int centerinarray)
    {
        string[] newarray = thischunk;
        double [] localscan = PlayerPrefsX.ConvertArrayStringToDouble(scanresults);                                                                 //converting scanresults backinto their keycode equivalents. IE "grass_1"-->"165" also converted them from strings to doubles
        double[,] choices = null;
        bool done = false;
        while (done == false)
        {





            if (localscan[0]==-1&&localscan[1]==-1&&localscan[2]==-1&&
                localscan[3]==-1&&localscan[5]!=-1&&localscan[6]!=-1&&localscan[7]!=-1)
            {
                choices = new double[,] {
                                       {84},//tilekey
                                       {100 }//%chancetospawn
                };
                done = true;

            }           


            done = true;
        }




        done = false;


        if(choices!=null)
        {
            newarray[centerinarray] = Convert.ToString(RandomManager.Pick(choices));          
        }


        return newarray;



    }
}
