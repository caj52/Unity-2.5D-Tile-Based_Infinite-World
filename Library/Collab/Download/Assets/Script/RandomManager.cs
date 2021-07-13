using UnityEngine;                              //OPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZEOPTIMIZE
public class RandomManager //the class that deals with random generator math bullshit
{

    public static double Pick(double[,] choicearray)//this method takes a 2dimensional array where the top y layer represents
                                    //a tiles keycode (ex: "*tile*115") and the bottom y layer represents 
                                    //the percent chance of that tile being selected. all the entries must add up
                                    //to 100%, uses these percentages to pick one of the choices and it returns its selection in the form of the keycode int.
    {
        double rangeselection = (Random.Range(1,1000)/10);  // this gives us a double instead of a int as the spawn percent. 557-->55.7
        bool looprun = true;
        double loopcount = 0;
       double looprange = 0;
        int choicecount = 0;
        double choice=0;
        while (looprun == true)
        {
            loopcount +=choicearray[1,choicecount];

                if((rangeselection >= looprange && rangeselection < loopcount) || loopcount > 100)
            {
                choice = choicearray[0, choicecount];
                looprun = false;
            }
            looprange = loopcount;
            choicecount += 1;
        }

        return choice;
    }
    
}
