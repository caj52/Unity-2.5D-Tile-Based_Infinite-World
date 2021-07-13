using UnityEngine;
using System;
public class BDataInterpolate
{
    public static Vector3Int Interpolate(string biomedata,string returndata)
    {
        Vector3Int returnvector = new Vector3Int(0, 0, 0);
        string biomecoords = biomedata.Substring(5);
        string []bcoords = biomecoords.Split(',');
        int bcoordx = Convert.ToInt32(bcoords[0].Substring(1));
        int bcoordy = Convert.ToInt32(bcoords[1].Substring(1)); 
        int vectorx = (bcoordx*128);
        int vectory = (bcoordy*128);    
        Vector3Int startingcoord = new Vector3Int(vectorx,vectory,0);
        Vector3Int intbcoords = new Vector3Int(bcoordx, bcoordy, 0);

        if (returndata == "startingcoords")
        {
          returnvector= startingcoord;
        }

        if (returndata == "biomecoords")
        {
            returnvector= intbcoords;
        }

        return returnvector;
    }
}
