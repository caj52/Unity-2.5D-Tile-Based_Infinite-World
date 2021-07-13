using UnityEngine;
using System;
public class ZDataInterpolate
{
    public static Vector3Int Interpolate(string zonedata,string returndata)
    {
        Vector3Int returnvector = new Vector3Int(0, 0, 0);
        string zonecoords = zonedata.Substring(4);
        string []bcoords = zonecoords.Split(',');
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

        if (returndata == "zonecoords")
        {
            returnvector= intbcoords;
        }

        return returnvector;
    }

    public static string WhatZoneIsThis(Vector3 positiondata)
    {
        /*
         * this takes a vector 3 position value and converts it into zone Naming Space
         * for example. The Vector (0,0,0) would result in an output of the string
         * "zoneX0,Y0".
         */
        string zone;
        float zonex = positiondata.x;
        float zonez = positiondata.z;
            zonex = Mathf.FloorToInt(zonex / 128);
            zonez = Mathf.CeilToInt(zonez / 128);
        zone = "zoneX" + zonex + ",Y" + zonez;            
        return zone;
    }
}
