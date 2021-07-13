using UnityEngine;
using System.IO;
      [System.Serializable]
public class BData//this is a json reader/writer for biomedata files.
{
    public string BName;
    public  string BType;
    public  string[] CTypes;
    public  string[] CTiles1;
    public  string[] CTiles2;
    public  string[] CTiles3;
    public  string[] CTiles4;
    public  string[] CTiles5;
    public  string[] CTiles6;
    public  string[] CTiles7;
    public  string[] CTiles8;
    public  string[] CTiles9;
    public  string[] CTiles10;
    public  string[] CTiles11;
    public  string[] CTiles12;
    public  string[] CTiles13;
    public  string[] CTiles14;
    public  string[] CTiles15;
    public  string[] CTiles16;
    public static BData jsondata = new BData();
    public static void WriteBData(string biomename,string valuetomod,string[]newvalue,string biometype)
    {
        string jsonstring;

        if (!Exists("\\BuildHelper.json"))
        {
            jsonstring = JsonUtility.ToJson(jsondata);
            File.WriteAllText(Application.streamingAssetsPath + "\\BuildHelper.json", jsonstring);
        }
        ClearLocalVars();
        jsondata.BName = biomename;
        int biomex = BDataInterpolate.Interpolate(biomename,"biomecoords").x;
        int biomey = BDataInterpolate.Interpolate(biomename, "biomecoords").y;
        jsonstring = File.ReadAllText(Application.streamingAssetsPath +"\\BuildHelper.json");
        JsonUtility.FromJsonOverwrite(jsonstring, jsondata);

        if (valuetomod == "BName")
        {
            jsondata.BName = biomename;
        }
        else if (valuetomod == "BType")
        {
            jsondata.BType=biometype;
        }

        if (valuetomod == "CTypes")
        {
            jsondata.CTypes=newvalue;
        }
        else if (valuetomod == "CTiles1")
        {
            jsondata.CTiles1 = newvalue;
        }
        else if (valuetomod == "CTiles2")
        {
            jsondata.CTiles2 = newvalue;
        }
        else if (valuetomod == "CTiles3")
        {
            jsondata.CTiles3 = newvalue;
        }
        else if (valuetomod == "CTiles4")
        {
            jsondata.CTiles4 = newvalue;
        }
        else if (valuetomod == "CTiles5")
        {
            jsondata.CTiles5 = newvalue;
        }
        else if (valuetomod == "CTiles6")
        {
            jsondata.CTiles6 = newvalue;
        }
        else if (valuetomod == "CTiles7")
        {
            jsondata.CTiles7 = newvalue;
        }
        else if (valuetomod == "CTiles8")
        {
            jsondata.CTiles8 = newvalue;
        }
        else if (valuetomod == "CTiles9")
        {
            jsondata.CTiles9 = newvalue;
        }
        else if (valuetomod == "CTiles10")
        {
            jsondata.CTiles10 = newvalue;
        }
        else if (valuetomod == "CTiles11")
        {
            jsondata.CTiles11 = newvalue;
        }
        else if (valuetomod == "CTiles12")
        {
            jsondata.CTiles12 = newvalue;
        }
        else if (valuetomod == "CTiles13")
        {
            jsondata.CTiles13 = newvalue;
        }
        else if (valuetomod == "CTiles14")
        {
            jsondata.CTiles14 = newvalue;
        }
        else if (valuetomod == "CTiles15")
        {
            jsondata.CTiles15 = newvalue;
        }
        else if (valuetomod == "CTiles16")
        {
            jsondata.CTiles16 = newvalue;
        }

        jsonstring = JsonUtility.ToJson(jsondata);
        File.WriteAllText(Application.streamingAssetsPath + "\\BuildHelper.json", jsonstring);
        ClearLocalVars();
    }



    public static string[] ReadBData(string variabletoreturn)
    {
        string[] localarray = null;
        string jsonstring = File.ReadAllText(Application.streamingAssetsPath + "\\BuildHelper.json");
        JsonUtility.FromJsonOverwrite(jsonstring, jsondata);



        if (variabletoreturn=="CTypes")
        {
            localarray = jsondata.CTypes;
        }
       else if (variabletoreturn == "CTiles1")
        {
            localarray = jsondata.CTiles1;
        }
        else if (variabletoreturn == "CTiles2")
        {
            localarray = jsondata.CTiles2;
        }
        else if (variabletoreturn == "CTiles3")
        {
            localarray = jsondata.CTiles3;
        }
        else if (variabletoreturn == "CTiles4")
        {
            localarray = jsondata.CTiles4;
        }
        else if (variabletoreturn == "CTiles5")
        {
            localarray = jsondata.CTiles5;
        }
        else if (variabletoreturn == "CTiles6")
        {
            localarray = jsondata.CTiles6;
        }
        else if (variabletoreturn == "CTiles7")
        {
            localarray = jsondata.CTiles7;
        }
        else if (variabletoreturn == "CTiles8")
        {
            localarray = jsondata.CTiles8;
        }
        else if (variabletoreturn == "CTiles9")
        {
            localarray = jsondata.CTiles9;
        }
        else if (variabletoreturn == "CTiles10")
        {
            localarray = jsondata.CTiles10;
        }
        else if (variabletoreturn == "CTiles11")
        {
            localarray = jsondata.CTiles11;
        }
        else if (variabletoreturn == "CTiles12")
        {
            localarray = jsondata.CTiles12;
        }
        else if (variabletoreturn == "CTiles13")
        {
            localarray = jsondata.CTiles13;
        }
        else if (variabletoreturn == "CTiles14")
        {
            localarray = jsondata.CTiles14;
        }
        else if (variabletoreturn == "CTiles15")
        {
            localarray = jsondata.CTiles15;
        }
        else if (variabletoreturn == "CTiles16")
        {
            localarray = jsondata.CTiles16;
        }
        else if (variabletoreturn == "BType")
        {
            localarray = new string[1];
            localarray[0] = jsondata.BType;
        }
        ClearLocalVars();

        return localarray;
    }



    public static bool Exists(string bdatafile)
    {
        bool exists = false;
        if (File.Exists(Application.streamingAssetsPath + bdatafile))
        {
            exists = true;
        }

        return exists;
    }

    public static void ClearBHelper()
    {
        ClearLocalVars();
        string jsonstring = JsonUtility.ToJson(jsondata);
        File.WriteAllText(Application.streamingAssetsPath + "\\BuildHelper.json", jsonstring);
    }


    /*  public static void CompressAll()
      {
          string[] files = Directory.GetFiles(Application.streamingAssetsPath + "\\S1");
          for (int count =0;count<files.Length-1;count++)
          {
              string jsonstring = File.ReadAllText(files[count]);
              byte[] jsonbytes = System.Text.Encoding.UTF8.GetBytes(jsonstring);
              jsonstring = System.Text.Encoding.UTF8.GetString(DataCompressor.Compress(jsonbytes));
              File.WriteAllText(files[count],jsonstring);
          }
      }
      */





    public static void ClearLocalVars()
    {
    jsondata.BName=null;
    jsondata.BType=null;
    jsondata.CTypes = null;
    jsondata.CTiles1 = null;
    jsondata.CTiles2 = null;
    jsondata.CTiles3 = null;
    jsondata.CTiles4 = null;
    jsondata.CTiles5 = null;
    jsondata.CTiles6 = null;
    jsondata.CTiles7 = null;
    jsondata.CTiles8 = null;
    jsondata.CTiles9 = null;
    jsondata.CTiles10 = null;
    jsondata.CTiles11 = null;
    jsondata.CTiles12 = null;
    jsondata.CTiles13 = null;
    jsondata.CTiles14 = null;
    jsondata.CTiles15 = null;
    jsondata.CTiles16 = null;
}


}