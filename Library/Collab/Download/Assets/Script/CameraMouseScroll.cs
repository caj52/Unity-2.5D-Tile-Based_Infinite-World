using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseScroll : MonoBehaviour
{
    public Camera thiscam;
    public GameObject player;
    float direction;
    public static float nullbox = 60;
    public static float scrollspeed = 1f;
    public void Rotate()
    {
        Vector3 playerpos = player.transform.position;
        if (Input.GetMouseButtonDown(1))
        {
            direction = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x > (direction + nullbox))
            {
                player.transform.Rotate(0, scrollspeed, 0, Space.Self);
            }
            if (Input.mousePosition.x < (direction - nullbox))
            {
                player.transform.Rotate(0, -scrollspeed, 0, Space.Self);
            }
        }
    }
}
