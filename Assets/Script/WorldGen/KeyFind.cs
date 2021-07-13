using System;                    //OPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZE
using UnityEngine;
public class KeyFind
{
    public static int SpritesheetKeysFind(int keyvalue, int[] idindex,string[] pathindex) 
    {
        int numinsheet=0;

        for (int i=0; i < idindex.Length-1; i++)
        {
            if (keyvalue == idindex[i])
            {
                numinsheet = Convert.ToInt32(pathindex[idindex[i]].Substring(18));
            }
        }
        return numinsheet;
    }



    public static double ReverseKeysFind(string keyname, string[,] keyindex) //same as above but backwards. It starts with the string and converts it back into its keycode.
    {
        int loopcount = 0;
        bool looprun = true;
        string keyvalue = null;


        while (looprun == true)
        {
            if (keyname == keyindex[1, loopcount])
            {
                keyvalue = keyindex[0, loopcount];
                looprun = false;
            }
            loopcount += 1;

        }
        return Convert.ToDouble(keyvalue);
    }

    public static string StringKeysFind(string keyvalue, string[,] keyindex) //same as the method above but it takes a string variable as its first argument
    {
        int loopcount = 0;
        bool looprun = true;
        string keyname = null;


        while (looprun == true)
        {
            if (keyvalue == (keyindex[0, loopcount]))
            {
                keyname = keyindex[1, loopcount];
                looprun = false;
            }
            loopcount += 1;

        }
        return keyname;
    }


    public static bool DubArrayContains(double  key, double[,] dubarray)    //this method checks an int array to see if it contains a certain key in the top layer. Then returns true or false
    {
        bool contains = false;
        if (dubarray!=null) {
            for (int arraycheckloop = 0; arraycheckloop < (dubarray.Length / 2); arraycheckloop++)
            {
                if (dubarray[0, arraycheckloop] == key)
                {
                    contains = true;
                }

            }
        }







        return contains;
    }



    public static int DubArrayIndexOf(double key, double[,] dubarray)  //returns the x value of a specific top layer key within a 2d array
    {
        int index = -1;

        for (int arraycheckloop = 0; arraycheckloop < (dubarray.Length/2); arraycheckloop++)
        {
            if (dubarray[0, arraycheckloop] == key)
            {
                index =arraycheckloop;
            }
        }







        return index;
    }


    
}