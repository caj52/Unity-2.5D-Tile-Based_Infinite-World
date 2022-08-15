using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeedGenerationManager : MonoBehaviour
{
    private static string inputSeed = String.Empty;
    public static int seed { get; private set; }

    public static void Init()
    {
        if(inputSeed == String.Empty)
            seed = Random.Range(0, 100000);
        else
            SetSeedFromInputSeed();
        Debug.Log("Seed is " + seed);
    }

    private static void SetSeedFromInputSeed()
    {
        var finalString = string.Empty;
        var generatedNumbers = new List<int>();
        for (int x = 0; x < inputSeed.Length; x++)
        {
            if (x != 0 && x % 2 == 0)//appends 2 numbers together, then starts a new number
            {
                generatedNumbers.Add((int)Convert.ToInt64(finalString));
                finalString = String.Empty;
            }

            var character = inputSeed[x];
            int number = Convert.ToInt32(character);     
            var numEquivalent = Convert.ToString(number);
            finalString += numEquivalent;
        }
        generatedNumbers.Add((int)Convert.ToInt64(finalString));

        var finalSeed = 0;
        foreach (var num in generatedNumbers)
            finalSeed += num;
        seed = finalSeed;
    }
    public static void SetInputSeed(string newSeed)
    {
        inputSeed = newSeed;
    }
}
