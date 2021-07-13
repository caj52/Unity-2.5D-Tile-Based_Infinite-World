using System;
public class WaterTRules
{
    // this method returns an array of tilekey referneces. it obtains these references by comparing tilescanner data against a list of
    //comperators. Basically if the tiles surrounding center tile meet certain conditions, it adds a new tilekey reference to the choices array. it will
    //log them in an array even if there is only one potential choice. but many comperators will log multiple choices within the array.
    public static string[] Mod(string biometobuild,string[] scanresults, string[] thischunk, int chunknum, int centerinarray)
    {
        string[] newarray = thischunk;
        double[] localscan = PlayerPrefsX.ConvertArrayStringToDouble(scanresults); //converting scanresults backinto their keycode equivalents. IE "grass_1"-->"165" also converted them from strings to doubles
        double[,] choices = null;

        bool done = false;
        while (done == false)
        {

            if (localscan[1] == -1)
            {
                choices = new double[,] {
                                       {62,63 },//tilekey
                                       {50,50 }//%chancetospawn
                };
                done = true;
            }

            /*[  ][-1/-1][  ]
              [  ][62/63][  ]
              [  ][     ][  ]   
            */


            if ((localscan[3] == -1 || localscan[3] == -1) && (localscan[1] == -1) && (localscan[5] == 157))
            {
                choices = new double[,] {
                                       {61},//tilekey
                                       {100 }//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]
              [     ][     ][     ]   
            */


            if ((localscan[1] == 61 || localscan[1] == 65 || localscan[1] == 66) && (localscan[3] == 61 || localscan[3] == 62 || localscan[3] == 63))
            {
                choices = new double[,] {
                                       {76},//tilekey
                                       {100 }//%chancetospawn
                };
                done = true;
            }

            /*[        ][61/66/65][        ] 
              [61/62/63][   76   ][        ]
              [        ][        ][        ]   
            */



            if ((localscan[1] == 61 || localscan[1] == 65 || localscan[1] == 74 || localscan[1] == 66) && (localscan[3] == -1) && localscan[7] == 157)
            {
                choices = new double[,] {
                                       {65,66},//tilekey
                                       {50,50}//%chancetospawn
                };
                done = true;
            }

            /*[     ][61/65/74][     ]
              [-1/-1][ 65/66  ][     ]   CSCORE: 6
              [     ][   157  ][     ]   
            */



            if ((localscan[3] == -1) && (localscan[7] == -1) ||
                    ((localscan[3] == -1) && (localscan[6] == -1) && (localscan[7] == -1)))
            {
                choices = new double[,] {
                                       {69},//tilekey
                                       {100}//%chancetospawn
                };
                done = true;
            }





            if ((localscan[3] == 69 || localscan[3] == 70 || localscan[3] == 71) && (localscan[7] == 157))
            {
                choices = new double[,] {
                                       {74},//tilekey
                                       {100}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */


            if (((localscan[3] == 61) && (localscan[1] == -1) && (localscan[5] == -1)) ||
                   ((localscan[1] == -1) && (localscan[5] == -1)))
            {
                choices = new double[,] {
                                       {64},//tilekey
                                       {100}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */


            if ((localscan[1] == 64 && localscan[5] == 157) || ((localscan[1] == 68 || localscan[1] == 67) && localscan[5] == 157))
            {
                choices = new double[,] {
                                       {75},//tilekey
                                       {100}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */


            if ((localscan[1] == 64 || localscan[1] == 67 || localscan[1] == 68 || localscan[1] == 73) && (localscan[5] == -1) && (localscan[7] != -1))
            {
                choices = new double[,] {
                                       {67,68},//tilekey
                                       {50,50}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */

            if (localscan[5] == 157 && localscan[7] == 157 && (localscan[8] == -1))
            {
                choices = new double[,] {
                                       {73},//tilekey
                                       {100}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */

            if (((localscan[3] == 73) && (localscan[5] == -1)) ||
                 ((localscan[5] == -1) && (localscan[7] == -1)))
            {
                choices = new double[,] {
                                       {72},//tilekey
                                       {100}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */


            if ((localscan[1] != -1) && localscan[5] == 157 && (localscan[7] == -1) && (localscan[3] != -1))

            {
                choices = new double[,] {
                                       {70,71},//tilekey
                                       {50,50}//%chancetospawn
                };
                done = true;
            }

            /*[     ][-1/-1][     ]
              [-1/-1][  61 ][     ]   CSCORE: 6
              [     ][     ][     ]   
            */






            done = true;
        }

        if (choices != null)
        {
            newarray[centerinarray] = Convert.ToString(RandomManager.Pick(choices));
        }


        return newarray;
    }
}

