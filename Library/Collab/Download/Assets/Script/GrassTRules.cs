using System;

public class GrassTRules
{
    public static double[,] Mod(string [] scanresults)
    {
        double[] localscan = PlayerPrefsX.ConvertArrayStringToDouble(scanresults); //converting scanresults backinto their keycode equivalents. IE "grass_1"-->"165" also converted them from strings to doubles
        double[,] choices = null;
        bool done = false;
         while (done == false){

            /*

            if (localscan[3] == 31)
            {   //[*][*][*][*][*][*]
                choices = new double[2, 1];
                 choices[0, 0] = 33;
                 choices[1, 0] = 100;
                 done = true;
             }

            //[  ][  ][  ]
            //[31][33][  ]   CSCORE: 10
            //[  ][  ][  ]
            */
            done = true;
         }
    



        done = false;
        /*[x-->X][x-->X][x-->X][x-->X][x-->X]  //for modifying the center tile. But only if its already been modified to a directional tile
          [x-->X][x-->X][x-->X][x-->X][x-->X]*/
        while (done == false)
        {
      /*      if (KeyFind.DubArrayContains(31,choices) && localscan[3] == 31)
            {
                print("d");
                choices = new double[2, 1];
                choices[0, 0] = 32;
                choices[1, 0] = 100;
                done = true;
            }
            //[  ][       ][  ]
            //[31][31-->32][--]   CSCORE: 12
            //[--][-------][--]
            */








            done = true;
        }

        if (choices == null)               //if no tiles are modified, it sets the choices array as a 100 percent chance to be the tile it already is.
        {
            choices = new double[2,1];
            choices[0, 0] = Convert.ToDouble(scanresults[4]);
            choices[1, 0] = 100;
        }

        return choices;
    }
}
