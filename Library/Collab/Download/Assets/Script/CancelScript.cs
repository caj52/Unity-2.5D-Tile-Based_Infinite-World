using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelScript : MonoBehaviour
{
    public GameObject scriptholder;
    public GameObject otherholder;
    void OnMouseDown()
    {
        if (otherholder.GetComponent<TextClick>().firstclick) {
            scriptholder.GetComponent<BlinkingText>().enabled = false;
            scriptholder.GetComponent<BlinkingText>().text.SetActive(false);
        }
    }

}
