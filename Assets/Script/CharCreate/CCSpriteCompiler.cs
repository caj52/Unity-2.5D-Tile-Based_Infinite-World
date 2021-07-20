using UnityEngine;
using System.IO;

public class CCSpriteCompiler : MonoBehaviour
{
    public GameObject bodyD;
    public GameObject bodyL;
    public GameObject noseD;
    public GameObject noseL;
    public GameObject eyes;
    public GameObject hair;
    public GameObject torso;
    public GameObject legs;
    Texture2D newtex;
    Color[] pixthrow2;
    Color[] pixthrow;
    Color throwcol;
    Color rendercol;
    Color thispix;
    bool run;
    public SpriteCopy scopy;
    private void Start()
    {
        run = false;
    }

    public void CreateSheet()
    {

        if (!run)
        {
            //////////////////BODY_DARK/////////////////////////////
            //this sets the variable texture "newtex" equal to the Dark Body sprite
            newtex = new Texture2D(832, 1344);
            pixthrow = bodyD.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
            newtex.SetPixels(pixthrow);
            /////////////////END BODY_DARK//////////////////////////////

            ///////////////////////BODY_LIGHT/////////////////////////////
            float transp = bodyL.GetComponent<SpriteRenderer>().color.a;
            pixthrow2 = bodyL.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
            for (int y = 0; y < 1344; y++)
            {
                for (int x = 0; x < 832; x++)
                {
                    /*these for loops iterate through each individual pixel of the variable pixthrow, which has been
                     * set to the light body sprite. 
                    */
                    thispix = pixthrow2[x + (y * 832)];
                    if (thispix.a <= .1)
                    {
                        /*this snippet check to see if any individual pixel is nearly clear. if
                         * it detects one, it sets it to be completely clear instead.
                         */
                        thispix = Color.clear;
                    }

                    if (!thispix.Equals(Color.clear))
                    {
                        /*this snippet only runs if the particular pixel its looking at is not clear.
                         * It copies the pixel and pastes it onto the variable newtex, which will later be used to create
                         * our png spritesheet.
                         */
                        throwcol = Color.Lerp(pixthrow[x + (y * 832)], thispix, transp);
                        /*this "lerp" code creates the proper skin tone by iterating a pixel color somewhere between
                         * the light body sprite, and the dark body sprite
                        */
                        newtex.SetPixel(x, y, throwcol);
                    }
                }
            }

            //The following for loops execute similiar functions, varying slightly depending on which part is being iterated through.
            ////////////////////END BODY_LIGHT/////////////////////////////


            //////////////////////////NOSE_DARK////////////////////////////
            pixthrow = noseD.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
            for (int y = 0; y < 1344; y++)
            {
                for (int x = 0; x < 832; x++)
                {
                    thispix = pixthrow[x + (y * 832)];
                    if (thispix.a <= .1)
                    {
                        thispix = Color.clear;
                    }

                    if (!thispix.Equals(Color.clear))
                    {
                        throwcol = thispix;
                        newtex.SetPixel(x, y, throwcol);
                    }
                }
            }
            /////////////////////////////END NOSE_DARK/////////////////////////////////

            //////////////////////////////NOSE_LIGHT////////////////////////////////
            pixthrow2 = noseL.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
            for (int y = 0; y < 1344; y++)
            {
                for (int x = 0; x < 832; x++)
                {
                    thispix = pixthrow2[x + (y * 832)];
                    if (thispix.a <= .1)
                    {
                        thispix = Color.clear;
                    }

                    if (!thispix.Equals(Color.clear))
                    {
                        throwcol = Color.Lerp(pixthrow[x + (y * 832)], thispix, transp);
                        newtex.SetPixel(x, y, throwcol);
                    }
                }
            }
            //////////////////////////////END NOSE_LIGHT///////////////////////////////

            /////////////////////////////////EYES////////////////////////////////////
            if (eyes.activeInHierarchy)
            {
                pixthrow = eyes.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
                rendercol = eyes.GetComponent<SpriteRenderer>().color;
                for (int y = 0; y < 1344; y++)
                {
                    for (int x = 0; x < 832; x++)
                    {
                        thispix = pixthrow[x + (y * 832)];
                        if (pixthrow[x + (y * 832)].a <= .1)
                        {
                            pixthrow[x + (y * 832)] = Color.clear;
                        }

                        if (!pixthrow[x + (y * 832)].Equals(Color.clear))
                        {
                            throwcol = new Color(thispix.r * rendercol.r, thispix.g * rendercol.g, thispix.b * rendercol.b);
                            newtex.SetPixel(x, y, throwcol);
                        }
                    }
                }
            }
            ////////////////////////////////END EYES//////////////////////////////

            //////////////////////////////////TORSO////////////////////////////////
            pixthrow = torso.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
            rendercol = torso.GetComponent<SpriteRenderer>().color;
            for (int y = 0; y < 1344; y++)
            {
                for (int x = 0; x < 832; x++)
                {
                    thispix = pixthrow[x + (y * 832)];
                    if (thispix.a <= .1)
                    {
                        thispix = Color.clear;
                    }

                    if (!thispix.Equals(Color.clear))
                    {
                        throwcol = new Color(thispix.r * rendercol.r, thispix.g * rendercol.g, thispix.b * rendercol.b);
                        newtex.SetPixel(x, y, throwcol);
                    }
                }
            }
            //////////////////////////////////END TORSO////////////////////////////////////


            //////////////////////////////////////LEGS////////////////////////////////////
            pixthrow = legs.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
            rendercol = legs.GetComponent<SpriteRenderer>().color;
            for (int y = 0; y < 1344; y++)
            {
                for (int x = 0; x < 832; x++)
                {
                    thispix = pixthrow[x + (y * 832)];
                    if (thispix.a <= .1)
                    {
                        thispix = Color.clear;
                    }

                    if (!thispix.Equals(Color.clear))
                    {
                        throwcol = new Color(thispix.r * rendercol.r, thispix.g * rendercol.g, thispix.b * rendercol.b);
                        newtex.SetPixel(x, y, throwcol);
                    }
                }
            }
            ///////////////////////////////END LEGS////////////////////////////////////

            ////////////////////////////////HAIR////////////////////////////////////////
            if (hair.activeInHierarchy)
            {
                pixthrow = hair.GetComponent<SpriteRenderer>().sprite.texture.GetPixels();
                rendercol = hair.GetComponent<SpriteRenderer>().color;
                for (int y = 0; y < 1344; y++)
                {
                    for (int x = 0; x < 832; x++)
                    {
                        thispix = pixthrow[x + (y * 832)];
                        if (pixthrow[x + (y * 832)].a <= .1)
                        {
                            pixthrow[x + (y * 832)] = Color.clear;
                        }

                        if (!pixthrow[x + (y * 832)].Equals(Color.clear))
                        {
                            throwcol = new Color(thispix.r * rendercol.r, thispix.g * rendercol.g, thispix.b * rendercol.b);
                            newtex.SetPixel(x, y, throwcol);
                        }
                    }
                }
            }
            /////////////////////////////////////END HAIR/////////////////////////////////////////
            
            //This last bit encodes the texture varaiable weve been editing to a png and creates
            //a file from it within the game data. It also slices it for future use.
            byte[] throwbytes = newtex.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "//Resources//CCSprites//Player//PlayerSprite.png",throwbytes);
            Object throwobj = Resources.Load<Object>("CCSprites/Player/PlayerSprite");
            scopy.copyTo = throwobj;
            scopy.CopyPivotsAndSlices();

            run = true;
        }
    }
}
