using UnityEngine;
public class PlayerInit : MonoBehaviour
{
    public GameObject thisobject;
    bool set = false;
    public PlayerControls pcontrols;
    string pspriteloc;
    public GameObject hud;
    public void Start()
    {
        pspriteloc = "CCSprites\\Player\\PlayerSprite";
        thisobject.GetComponent<SpriteRenderer>().sprite= Resources.LoadAll<Sprite>(pspriteloc)[65];
    }
    void Update()
    {
        OnLoad();
        pcontrols.Movement();
    }



    void OnLoad()
    {
        if (!set)
        {
            if (PlayerPrefsX.GetBool("ingame"))
            {
                set = true;
                hud.SetActive(true);
                thisobject.GetComponent<SpriteRenderer>().enabled = true;
                thisobject.GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }
}
