using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject thiscamera;
    public CameraRotation camrotate;
    public CameraSceneTransition camzish;
    void Update()
    {
        camzish.BindToPlayer();
        StartCoroutine(camrotate.Rotate());
    }
}
