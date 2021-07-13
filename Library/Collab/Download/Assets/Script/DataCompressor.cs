using System;
using UnityEngine;

public class DataCompressor : MonoBehaviour
{
    public static byte[] newtext;
    public static byte com = System.Text.Encoding.UTF8.GetBytes(",")[0];
    public static byte obrack = System.Text.Encoding.UTF8.GetBytes("[")[0];
    public static byte clbrack = System.Text.Encoding.UTF8.GetBytes("]")[0];
    public static byte quot = System.Text.Encoding.UTF8.GetBytes("\"")[0];
    public static byte dwiggle = System.Text.Encoding.UTF8.GetBytes("~")[0]; //"decompression wiggle"-->dwiggle
    public static string scanstring="";
    public static string filestring;
    public static int instance;
    public static bool rundelete;

    public static byte[] Compress(byte[] filetext)
    {
        filestring = System.Text.Encoding.UTF8.GetString(filetext);
        newtext = filetext;
        for (int bytenum=0;bytenum<newtext.Length;bytenum++,scanstring="")
        {
            newtext = CompMethods(newtext,bytenum);
            if (scanstring.Length>0)
            {
                bytenum += scanstring.Length;
                if (instance>1)
                {
                    bytenum+=instance.ToString().Length+1;
                }
            }
        }
        return newtext;
    }



    public static byte[] Decompress(byte[] cfiletext)
    {
        filestring = System.Text.Encoding.UTF8.GetString(cfiletext);
        newtext = cfiletext;
        for (int bytenum = cfiletext.Length-1; bytenum >= 0; bytenum--, scanstring = "")
        {
            newtext = DeCompMethods(newtext, bytenum);
        }
        return newtext;
    }



    public static byte[] CompMethods(byte[] filetext, int bytenum)
    {
        if (filetext[bytenum]==quot)
        {
            scanstring = "\"";
            instance = 1;
            for (int num=bytenum+1;filetext[num]!=quot;num++)
            {
                scanstring += filestring.Substring(num,1);
            }
            scanstring += "\"";
            if (filestring.Substring(bytenum+scanstring.Length,1)==",")
            {
                rundelete = true;
                while (rundelete)
                {
                    if (bytenum < ((filestring.Length-2) - scanstring.Length))
                    {
                        if (filestring.IndexOf(scanstring, bytenum + scanstring.Length + 1, scanstring.Length) != -1)
                        {
                            filestring = filestring.Remove(bytenum + scanstring.Length, scanstring.Length + 1);
                            instance++;
                        }
                        else
                        {
                            rundelete = false;
                        }
                    }
                    else
                    {
                        rundelete = false;
                    }
                }
                if (instance>1)
                {
                    filestring = filestring.Insert(bytenum + scanstring.Length,"~"+instance);
                    filetext= System.Text.Encoding.UTF8.GetBytes(filestring);
                }                
            }
        }
        return filetext;
    }


    public static byte[] DeCompMethods(byte[] filetext,int bytenum)
    {
        if (filetext[bytenum] == dwiggle)
        {
            string newstring="";
            scanstring = "";

            for (int num = bytenum+1; filetext[num] != com && filetext[num]!=clbrack; num++)
            {
                scanstring += filestring.Substring(num, 1);
            }
            for (int num = bytenum-1; filetext[num] != com && filetext[num] != obrack; num--)
            {
                newstring += filestring.Substring(num, 1);
            }
            newstring += ",";
            byte[] slavearray = System.Text.Encoding.UTF8.GetBytes(newstring);
            Array.Reverse(slavearray);
            newstring = System.Text.Encoding.UTF8.GetString(slavearray);

            if (newstring == ",")
            {
                newstring = ",\"\"";
            }
            filestring = filestring.Remove(bytenum,scanstring.Length+1);
            int repcount = Convert.ToInt32(scanstring);
            for (int num=1;num<repcount;num++)
            {
                filestring = filestring.Insert(bytenum,newstring);                
            }

        }
        filetext= System.Text.Encoding.UTF8.GetBytes(filestring);
        return filetext;
    }
}
