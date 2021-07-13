
using UnityEngine;

public class CameraSceneTransition : MonoBehaviour
{
    bool set = false;
    public Transform player;
    public GameObject thiscamera;
    public void BindToPlayer()
    {
        if (set)
        {
            thiscamera.transform.position = player.transform.position - (player.transform.forward*4);
            thiscamera.transform.LookAt(player);
            thiscamera.transform.eulerAngles = new Vector3(30, thiscamera.transform.eulerAngles.y, thiscamera.transform.eulerAngles.z);
            thiscamera.transform.position = new Vector3(thiscamera.transform.position.x, thiscamera.transform.position.y+3, thiscamera.transform.position.z);
        }
        else
        {
            if (PlayerPrefsX.GetBool("ingame"))
            {
                thiscamera.transform.SetParent(player);
                set = true;
            }
        }
    }

}
