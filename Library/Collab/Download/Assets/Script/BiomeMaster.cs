using System.Collections;
using UnityEngine;
public class BiomeMaster : MonoBehaviour
{    public IEnumerator Init()//this method is run the first time the main game is run
    {
        BiomeGen bgen = GameObject.Find("BiomeManager").GetComponent<BiomeGen>();
        LoadScreen lsc = GameObject.Find("LoadManager").GetComponent<LoadScreen>();
        for (int x =-1;x<2;x++) {
            for (int y =-1;y<2;y++) {
                lsc.LoadBar("Creating: BiomeX" + x + ",Y" + y);
                yield return null;
               if(x==0&&y==0){
                    bgen.Builder("BiomeX" + x + ",Y" + y);
                }
               // if (x == 0 && y == 1)
               // {
              //      bgen.Builder("BiomeX" + x + ",Y" + y);
             //   }
                
            }
        }
        
        lsc.LoadBar("Done");
        yield return null;
    }

    public IEnumerator LoadGame()
    {


        return null;
    }


}
