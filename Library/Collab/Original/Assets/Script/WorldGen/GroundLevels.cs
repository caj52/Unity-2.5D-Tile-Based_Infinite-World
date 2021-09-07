using System.Collections;
using UnityEngine;
    public class GroundLevels : MonoBehaviour
    {

    public static string[] newdata;

    public static float[,] Filter(float[,] elevationdata)
    {
        float[,] arraybot=elevationdata;
        float num = Mathf.Sqrt(arraybot.Length);
        for (int y=0;y< num;y++)
        {
            for(int x=0;x<num;x++){
                if (arraybot[y,x] <= .1f)
                {
                    arraybot[y,x] = 0f;

                }
                if (arraybot[y,x] <= .2f && arraybot[y,x] > .1f)
                {
                    arraybot[y,x] = .1f;

                }
                if (arraybot[y,x] <= .3f && arraybot[y,x] > .2f)
                {
                    arraybot[y,x] = .2f;

                }
                if (arraybot[y,x] <= .4f && arraybot[y,x] > .3f)
                {
                    arraybot[y,x] = .3f;

                }
                if (arraybot[y,x] <= .5f && arraybot[y,x] > .4f)
                {
                    arraybot[y,x] = .4f;

                }
                if (arraybot[y,x] <= .6f && arraybot[y,x] > .5f)
                {
                    arraybot[y,x] = .5f;

                }
                if (arraybot[y,x] <= .7f && arraybot[y,x] > .6f)
                {
                    arraybot[y,x] = .6f;

                }
               if (arraybot[y,x] <= .8f && arraybot[y,x] > .7f)
                {
                    arraybot[y,x] = .7f;

                }
                if (arraybot[y,x] <= .9f && arraybot[y,x] > .8f)
                {
                    arraybot[y,x] = .8f;

                }
                if(arraybot[y,x] <= 1f && arraybot[y, x] > .9f)
                {
                    arraybot[y, x] = .9f;

                }
            }

        }

        return arraybot;
    }



    }