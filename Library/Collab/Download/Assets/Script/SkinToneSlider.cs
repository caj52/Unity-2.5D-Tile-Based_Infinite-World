using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class handles the color transition that occurs
 * when the player slides the skin tone slider. It takes
 * 3 game objects. The characters light skin model,
 * the slider object, and the "Skin Tone" text.
 * It uses the value variable of the slider (this is the 
 * variable that is modified when the player slides the 
 * slider) and sets the transparency of the character sprite
 * equalk to this value. The result is the increasing and
 * decreasing transparency of the character sprite in
 * relation to the players inputs. By drawing a dark
 * skin model of the same character sprite behind the
 * light skin model that it being modified, it creates
 * the appearance of a smooth and gradual transition to 
 * different skin tones as the player slider the tone slider.
 */

public class SkinToneSlider : MonoBehaviour
{
    public GameObject character;
    public GameObject slider;
    public GameObject thistext;
    public GameObject nose;
    public GameObject noseicons;
    UnityEngine.UI.Slider slidercom;
    void Start()
    {
        thistext.SetActive(true);
        slidercom = slider.GetComponent<UnityEngine.UI.Slider>();
        slidercom.value = .5f;
    }
    void Update()
    {
        ColorUpdate();
    }

    void ColorUpdate()
    {
        character.GetComponent<SpriteRenderer>().color = new Vector4(1,1,1,slidercom.value);
        nose.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, slidercom.value);
       // noseicons.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, slidercom.value);

    }
}
