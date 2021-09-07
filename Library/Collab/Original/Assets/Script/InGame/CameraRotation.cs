using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera thiscam;
    public GameObject player;
    public PlayerAnim panim;
    public IEnumerator Rotate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i=0;i<15;i++) {
                player.transform.eulerAngles = new Vector3(
                    player.transform.eulerAngles.x,
                    player.transform.eulerAngles.y + 6,
                    player.transform.eulerAngles.z);
                if (i==8)
                {
                    panim.RotateStateCheck(1);
                }
                yield return null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < 15; i++)
            {
                player.transform.eulerAngles = new Vector3(
                    player.transform.eulerAngles.x,
                    player.transform.eulerAngles.y - 6,
                    player.transform.eulerAngles.z);
                if (i == 8)
                {
                    panim.RotateStateCheck(-1);
                }
                yield return null;
            }
        }
        yield return null;
    }

}
