using UnityEngine;
public class PressButtonUI : MonoBehaviour
{
    //Simple utility class that handles the appearance of abuttone being pressed
    public GameObject box = null;
    public GameObject boxtext = null;
    string boxstr;
    private void OnMouseDown()
    {
        box.transform.localPosition += new Vector3(.02f, 0, .02f);
        if (boxtext != null)
        {
            boxtext.transform.localPosition += new Vector3(.02f, 0, .02f);
        }
    }
    private void OnMouseUp()
    {
        box.transform.localPosition -= new Vector3(.02f, 0, .02f);
        if (boxtext != null)
        {
            boxtext.transform.localPosition -= new Vector3(.02f, 0, .02f);
        }
    }
}