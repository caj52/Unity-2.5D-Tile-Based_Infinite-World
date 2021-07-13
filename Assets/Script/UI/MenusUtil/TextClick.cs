using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClick : MonoBehaviour
{
    public GameObject oldtext;
    public GameObject newtext;
    public GameObject blink;
    string playertext="";
    public bool firstclick = false;
    bool clicked = false;
    float starttime;
    void OnMouseDown()
    {
        if (firstclick==false) {
            oldtext.GetComponent<UnityEngine.UI.Text>().text = "|";
            firstclick = true;
            clicked = true;
        }
        blink.GetComponent<BlinkingText>().enabled=true;
        blink.GetComponent<BlinkingText>().text.SetActive(true);

    }

    private void Update()
    {
        if (clicked)
        {
            if (playertext.Length<=10&& Input.GetKey(KeyCode.Backspace)==false) {
                playertext += Input.inputString;
            }
            newtext.GetComponent<UnityEngine.UI.Text>().text = playertext;
            oldtext.transform.localPosition = new Vector3(newtext.gameObject.transform.localPosition.x+((newtext.GetComponent<UnityEngine.UI.Text>().preferredWidth)/100), 
            newtext.gameObject.transform.localPosition.y+.03f, newtext.gameObject.transform.localPosition.z);
            if (playertext.Length>=1) {
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    starttime = Time.time;
                    playertext = playertext.Remove(playertext.Length - 1, 1);
                }
                if (Input.GetKey(KeyCode.Backspace))
                {
                    if (starttime+.5f<=Time.time) {
                        playertext = playertext.Remove(playertext.Length - 1, 1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    blink.GetComponent<BlinkingText>().enabled = false;
                    blink.GetComponent<BlinkingText>().text.SetActive(false);
                }
            }
        }
    }
}
