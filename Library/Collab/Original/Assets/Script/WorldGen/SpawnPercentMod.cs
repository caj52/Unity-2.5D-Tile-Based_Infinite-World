
public class SpawnPercentMod
{
    // Start is called before the first frame update
    public static double[,] Augment(double[,] targetarray,double keytomod,double percenttomodby,bool increase) // this method takes an array with keys and spawn percents as a parameter
                                                                                         //it takes the key you want to modify as the 2nd parameter, the 3rd is the amount to modify it by
    {
        double[,] newarray = targetarray;                                                //the 4th parameter is wether to increase or decrease it by that amount. true==increase, false == decrease
        if (keytomod != -1)
        {  //-1 is the value for "null". This ensures augment()        this method is used to modify spawn chance on the fly. It will mostly be used by tile grouper and tile rules and will be the last function to modify
           //never adds a null key to the array                         spawn percentages before the array gets handed off to randommanager.pick();
           //this function will also modify all other values according to how much you modified the specified key. This is to ensure the values always add to 100.


            if (KeyFind.DubArrayContains(keytomod, newarray) == false)//checking if the array contains the key we are modifying, if not, it will add it.
            {
                newarray = PlayerPrefsX.AddTo2DubArray(newarray, keytomod, 0);
            }


            if (increase)    //if bool increase = true it increases the specified key by the specified percent and subtracts equal amounts from all other entries so the values
                             //still add up to 100.
            {
                double keyloc = KeyFind.DubArrayIndexOf(keytomod, newarray);
                double allelsemod = (percenttomodby / (newarray.Length - 1));

                for (int arrayloop = 0; arrayloop < (newarray.Length / 2); arrayloop++)
                {
                    if (arrayloop != keyloc)
                    {
                        newarray[1, arrayloop] -= allelsemod;

                    }

                    if (arrayloop == keyloc)
                    {
                        newarray[1, arrayloop] += percenttomodby;

                    }
                }







            }




            if (increase == false)//if bool increase = false it decreases the specified key by the specified percent and adds equal amounts to all other entries so the values
                                  //still add up to 100.
            {
                double keyloc = KeyFind.DubArrayIndexOf(keytomod, newarray);
                double allelsemod = (percenttomodby / (newarray.Length - 1));

                for (int arrayloop = 0; arrayloop < (newarray.Length + 1); arrayloop++)
                {
                    if (arrayloop != keyloc)
                    {
                        newarray[1, arrayloop] += allelsemod;

                    }

                    if (arrayloop == keyloc)
                    {
                        newarray[1, arrayloop] -= percenttomodby;

                    }
                }







            }







        }
            return newarray;
        

    }
}
