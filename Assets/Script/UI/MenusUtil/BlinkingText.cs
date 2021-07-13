using UnityEngine;
public class BlinkingText : MonoBehaviour
{
    public float flashinterval;
    public GameObject text;
    float timeslave=0;
    public void Update()
    {
        if ((timeslave + flashinterval) < Time.realtimeSinceStartup)      
        {
            timeslave = Time.realtimeSinceStartup;
            if (text.activeSelf)      
            {
                text.SetActive(false);
            }  
            else 
            {
                text.SetActive(true);
            }
        }
    }  
}
