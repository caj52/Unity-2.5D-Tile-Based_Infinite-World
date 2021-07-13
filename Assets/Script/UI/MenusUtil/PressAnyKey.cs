using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject disableonpress;
    public GameObject enableonpress;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            disableonpress.SetActive(false);
            enableonpress.SetActive(true);
        }
    }
}
