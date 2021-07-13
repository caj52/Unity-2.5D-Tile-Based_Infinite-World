using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class LoadScreen : MonoBehaviour
{
    bool gen=true;
    public GameObject startscreen;
    public GameObject lman;
    public GameObject loadbar;
    public GameObject loadbar2;

    public void LoadScreenInit()
    {
        BiomeMaster bmaster = GameObject.Find("BiomeManager").GetComponent<BiomeMaster>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gen) {


                /*if (Directory.Exists(Application.streamingAssetsPath + "\\S1"))
                {
                    Directory.Delete(Application.streamingAssetsPath + "\\S1", true);
                }
                Directory.CreateDirectory(Application.streamingAssetsPath + "\\S1");
                */
                //not sure why this is here. Need to relocate this to somewhere that makes more sense. Probably in
                //the main menu code.

                PlayerPrefsX.SetBool("loading",true);
                gen = false;
                startscreen.SetActive(false);
                lman.SetActive(true);
                StartCoroutine(bmaster.Init());
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (gen)
            {
                PlayerPrefsX.SetBool("loading", true);
                gen = false;
                startscreen.SetActive(false);
                lman.SetActive(true);
                StartCoroutine(bmaster.LoadGame());
            }
        }

    }
    
    public void LoadBar(string loadtext)
    {
        loadbar.GetComponent<Image>().fillAmount += .1f;
        loadbar2.GetComponent<Text>().text = loadtext;
        if (loadbar.GetComponent<Image>().fillAmount >= 1f)
        {
            lman.SetActive(false);
            PlayerPrefsX.SetBool("ingame",true);
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled=true;
        }
    }

}
