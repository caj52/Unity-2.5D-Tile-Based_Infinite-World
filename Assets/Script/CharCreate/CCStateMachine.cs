using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the "state changes" within the character creator. Mainly,
 * the different steps of the character creation process. Eyes, Hair, Body, Etc.
 * IT does this by taking gameobjects as variables from within the inspector.
 * Its various classes all pertain to changing the states and disabling preset 
 * gameobjects that pertain to those various states. It also stores the current 
 * state as a variable, and allows it to be accessed by other classes.
 */
public class CCStateMachine : MonoBehaviour
{
    string currentstate = "Gender";
    public GameObject button_boy;
    public GameObject button_girl;
    public GameObject text_boy;
    public GameObject text_girl;
    public GameObject text_skin_tone_slider;
    public GameObject text_eye_color;
    public GameObject skin_slider;
    public GameObject eye_color_wheel;
    public GameObject rotation_arrows;
    public GameObject noses;
    public GameObject hair;
    public GameObject clothes;
    public bool nosepicked = false;
    public string selection;
    public static bool in_box;
    MoveSelectionArrow mov;
    CCDraw cdraw;
    public CCSpriteCompiler ccsprite;
    private void Update()
    {
        StepsCheck();
    }

    private void Start()
    {
        cdraw = GameObject.Find("CreationMaster").GetComponent<CCDraw>();
    }
    public void setbool(bool value)
    {
        in_box = value;
    }
    public void setstate(string state)
    {
        currentstate = state;
    }
    public bool getbool()
    {
        return in_box;
    }
    public void resetSprites()
    {
        text_skin_tone_slider.SetActive(false);
        eye_color_wheel.SetActive(false);
        text_eye_color.SetActive(false);
        noses.SetActive(false);
        clothes.SetActive(false);
        hair.SetActive(false);
        button_boy.SetActive(false);
        button_girl.SetActive(false);
        text_boy.SetActive(false);
        text_girl.SetActive(false);       
    }

    void StepsCheck()
    {
        //reconfigures UI sprites based on current game state
        mov = GameObject.Find(currentstate).GetComponent<MoveSelectionArrow>();
        mov.AutoMove();
        switch (currentstate)
        {
            case "Gender":
                resetSprites();
                skin_slider.SetActive(false);
                button_boy.SetActive(true);
                button_girl.SetActive(true);
                text_boy.SetActive(true);
                text_girl.SetActive(true);
                break;
            case "Body":
                resetSprites();
                rotation_arrows.SetActive(true);
                text_skin_tone_slider.SetActive(true);
                skin_slider.SetActive(true);
                break;
            case "Eyes":
                resetSprites();
                skin_slider.SetActive(false);

                eye_color_wheel.SetActive(true);
                text_eye_color.SetActive(true);
                break;
            case "Nose":
                resetSprites();
                skin_slider.SetActive(false);

                noses.SetActive(true);
                cdraw.Icons("Nose");
                if (!nosepicked)
                {
                    selection = "Button Nose";
                }
                noses.transform.Find(selection).transform.Find("SelectBox").gameObject.SetActive(true);
                break;
            case "Hair":
                resetSprites();
                skin_slider.SetActive(false);

                hair.SetActive(true);
                break;
            case "Clothes":
                resetSprites();
                skin_slider.SetActive(false);
                clothes.SetActive(true);
                break;
            case "Finished":
                ccsprite.CreateSheet();
                //MAIN GAME REDIRECT
                break;
        }
    }


}
