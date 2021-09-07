 using UnityEngine;
public class StartScreen : MonoBehaviour
{
    public float flashinterval;
    public GameObject startscreen;
    // Start is called before the first frame update
    public void PressStart()
    {

        if (PlayerPrefsX.GetBool("loading") != true)
        {


            if ((PlayerPrefs.GetFloat("timeslave") + flashinterval) < Time.time)
            {
                PlayerPrefs.SetFloat("timeslave", Time.time);
                if (startscreen.activeSelf)
                {
                    startscreen.SetActive(false);
                }
                else
                {
                    startscreen.SetActive(true);
                }


            }



        }
    }
}
