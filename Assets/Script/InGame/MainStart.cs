using UnityEngine;
public class MainStart : MonoBehaviour
{
    public GameObject loadman;
    public GameObject startscreen;
    public void Start()
    {
        loadman.SetActive(false);
        PlayerPrefs.DeleteAll();//resetting all playerprefs for testing purposes
        PlayerPrefsX.SetBool("ingame", false);
        PlayerPrefs.SetFloat("seed", Random.Range(1, 10000));
        PlayerPrefs.SetFloat("timeslave", Time.time);

    }
    void Update()
    {
        loadman.GetComponent<LoadScreen>().LoadScreenInit();
        
    }
}
