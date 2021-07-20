using UnityEngine;
/*
 * This is the character drawing class. This class handles sprite
 * retrieval and rendering for the character being created.
 * It does this by storing the appropriate base gender spritesheets as
 * arrays, then accessing the array entry required for that particular
 * rendering. Since the spritesheets for all character additions are
 * placed using the exact same layouts, you can access any of their 
 * arrays with the same number and all of the resulting sprites will stack 
 * appropriately. EX. Accessing entry [78] of the girl spritesheet will 
 * draw a base female sprite. Accessing[78] of the girl eyes spritesheet
 * draw the eyes for that base sprite. Thanks to this formatting, rotation
 * and drawing are very simple function. This class also handles rotation
 * by gathering datate from the RotateState class.
 */
public class CCDraw : MonoBehaviour
{
    string[] layervalues = new string[4];
    public GameObject charbaseL;
    public GameObject charbaseD;
    public GameObject chareyes;
    public GameObject charnoseL;
    public GameObject charnoseD;
    public GameObject chartorso;
    public GameObject charpants;
    public GameObject charhair;
    public GameObject noseicons;
    Sprite spritetodraw;
    Sprite[] basesheetL;
    Sprite[] basesheetD;
    Sprite[] eyesheet;
    Sprite[] nosesheetL;
    Sprite[] nosesheetD;
    Sprite[] hairsheet;
    Sprite[] clothessheetT;
    Sprite[] clothessheetP;
    Sprite[] throwsheetL;
    Sprite[] throwsheetD;
    int spritenum = 78;
    public string localgender;
    public void Character(int layertomod, string newvalue, string gender)
    {
        layervalues[layertomod] = newvalue;
        if (layertomod==0)
        {
            basesheetD = Resources.LoadAll<Sprite>("CCSprites\\Player\\Base_" + gender + "_Dark");
            spritetodraw = basesheetD[spritenum];
            charbaseD.GetComponent<SpriteRenderer>().sprite = spritetodraw;
            basesheetL = Resources.LoadAll<Sprite>("CCSprites\\Player\\Base_" + gender+"_Light");
            spritetodraw = basesheetL[spritenum];
            charbaseL.GetComponent<SpriteRenderer>().sprite = spritetodraw;
            eyesheet = Resources.LoadAll<Sprite>("CCSprites\\Player\\Eyes_" + gender);
            spritetodraw = eyesheet[spritenum];
            chareyes.GetComponent<SpriteRenderer>().sprite = spritetodraw;
            nosesheetL = Resources.LoadAll<Sprite>("CCSprites\\Noses\\buttonnose_" + gender+"_light");
            spritetodraw = nosesheetL[spritenum];
            charnoseL.GetComponent<SpriteRenderer>().sprite = spritetodraw;
            nosesheetD = Resources.LoadAll<Sprite>("CCSprites\\Noses\\buttonnose_" + gender + "_dark");
            spritetodraw = nosesheetD[spritenum];
            charnoseD.GetComponent<SpriteRenderer>().sprite = spritetodraw;

            hairsheet = Resources.LoadAll<Sprite>("CCSprites\\Hair\\"+ gender + "\\xlong");
            spritetodraw = hairsheet[spritenum];
            charhair.GetComponent<SpriteRenderer>().sprite = spritetodraw;
            charhair.SetActive(false);

            clothessheetT = Resources.LoadAll<Sprite>("CCSprites\\Clothes\\Torso\\" + gender +"_white_longsleeve");
            spritetodraw = clothessheetT[spritenum];
            chartorso.GetComponent<SpriteRenderer>().sprite = spritetodraw;
            clothessheetP = Resources.LoadAll<Sprite>("CCSprites\\Clothes\\Legs\\" + gender + "_white_pants");
            spritetodraw = clothessheetP[spritenum];
            charpants.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        }
        localgender = gender;
    }
    public void NoseUp(string nosetype)
    {
        nosesheetL = Resources.LoadAll<Sprite>("CCSprites\\Noses\\"+nosetype+"_" + localgender + "_light");
        spritetodraw = nosesheetL[spritenum];
        charnoseL.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        nosesheetD = Resources.LoadAll<Sprite>("CCSprites\\Noses\\"+nosetype+"_" + localgender + "_dark");
        spritetodraw = nosesheetD[spritenum];
        charnoseD.GetComponent<SpriteRenderer>().sprite = spritetodraw;
    }
    public void hairDraw(string hairtype)
    {
        if (hairtype == "nada")
        {
            charhair.SetActive(false);
        }
        else
        {
            charhair.SetActive(true);
            hairsheet = Resources.LoadAll<Sprite>("CCSprites\\Hair\\" + localgender + "\\" + hairtype);
            spritetodraw = hairsheet[spritenum];
            charhair.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        }
    }
    public void Icons(string state)
    {
        if (state=="Nose")
        {
            throwsheetD = nosesheetD;
            throwsheetL = nosesheetL;
            ////////////////////////////////RT_BIGNOSE////////////////////////////////////////////
            nosesheetD = Resources.LoadAll<Sprite>("CCSprites\\Noses\\bignose_" + localgender + "_dark");
            spritetodraw = nosesheetD[78];
            noseicons.transform.Find("Big Nose").transform.Find("Nose_Icon_Dark").GetComponent<SpriteRenderer>().sprite = spritetodraw;

            nosesheetL = Resources.LoadAll<Sprite>("CCSprites\\Noses\\bignose_" + localgender + "_light");
            spritetodraw = nosesheetL[78];
            noseicons.transform.Find("Big Nose").transform.Find("Nose_Icon_Light").GetComponent<SpriteRenderer>().sprite = spritetodraw;
            ////////////////////////////////////////////END_BIGNOSE//////////////////////////////////////////

            ///////////////////////////////////START_BUTTONNOSE//////////////////////////////////////////
            nosesheetD = Resources.LoadAll<Sprite>("CCSprites\\Noses\\buttonnose_" + localgender + "_dark");
            spritetodraw = nosesheetD[78];
            noseicons.transform.Find("Button Nose").transform.Find("Nose_Icon_Dark").GetComponent<SpriteRenderer>().sprite = spritetodraw;

            nosesheetL = Resources.LoadAll<Sprite>("CCSprites\\Noses\\buttonnose_" + localgender + "_light");
            spritetodraw = nosesheetL[78];
            noseicons.transform.Find("Button Nose").transform.Find("Nose_Icon_Light").GetComponent<SpriteRenderer>().sprite = spritetodraw;
            ////////////////////////////////////END_BUTTONNOSE////////////////////////////////////////

            /////////////////////////////////////START_STRAIGHTNOSE/////////////////////////////////////////
            nosesheetD = Resources.LoadAll<Sprite>("CCSprites\\Noses\\straightnose_" + localgender + "_dark");
            spritetodraw = nosesheetD[78];
            noseicons.transform.Find("Straight Nose").transform.Find("Nose_Icon_Dark").GetComponent<SpriteRenderer>().sprite = spritetodraw;

            nosesheetL = Resources.LoadAll<Sprite>("CCSprites\\Noses\\straightnose_" + localgender + "_light");
            spritetodraw = nosesheetL[78];
            noseicons.transform.Find("Straight Nose").transform.Find("Nose_Icon_Light").GetComponent<SpriteRenderer>().sprite = spritetodraw;
            /////////////////////////////////////END_STRAIGHTNOSE////////////////////////////////////////////
            nosesheetD = throwsheetD;
            nosesheetL = throwsheetL;
        }


    }
    public void Rotate() {

        int direction = RotationButton.rotatestate;
        switch (direction)
        {//determines sprite number to use based direction variable
            case 1:
                spritenum = 87;
                break;
            case 2:
                spritenum = 60;
                break;
            case 3:
                spritenum = 69;
                break;
            default:
                spritenum = 78;
                break;
        }

        spritetodraw = basesheetD[spritenum];
        charbaseD.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = basesheetL[spritenum];
        charbaseL.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = eyesheet[spritenum];
        chareyes.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = nosesheetL[spritenum];
        charnoseL.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = nosesheetD[spritenum];
        charnoseD.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = hairsheet[spritenum];
        charhair.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = clothessheetT[spritenum];
        chartorso.GetComponent<SpriteRenderer>().sprite = spritetodraw;
        spritetodraw = clothessheetP[spritenum];
        charpants.GetComponent<SpriteRenderer>().sprite = spritetodraw;
    }

}
