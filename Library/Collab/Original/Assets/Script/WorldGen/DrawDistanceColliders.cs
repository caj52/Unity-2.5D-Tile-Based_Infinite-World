using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDistanceColliders : MonoBehaviour
{
    string objectname;
    string biometocheck;
    public GameObject thisscanner;
    public ZoneGen zgen;
    public GameObject player;
    float drawdistance = 32f;
    public void Update()
    {
        thisscanner.transform.position = player.transform.position+ (player.transform.forward*drawdistance);
        thisscanner.transform.position = new Vector3(thisscanner.transform.position.x, -10, thisscanner.transform.position.z);
    }
    public void OnTriggerExit(Collider collider)
    {
        objectname = collider.transform.name;
        if (objectname.Contains("Biome"))
        {
            biometocheck = ZDataInterpolate.WhatZoneIsThis(thisscanner.transform.position);
            print(biometocheck);
            print(thisscanner.transform.position);
            if (GameObject.Find(biometocheck)==null)
            {
                zgen.Builder(biometocheck);
            }
        }
    }
}
