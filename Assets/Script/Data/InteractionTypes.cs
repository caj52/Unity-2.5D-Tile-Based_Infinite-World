using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTypes : MonoBehaviour
{
    public enum Interaction
    {
        Examine, 
        Drop,
        Throw,
        Pick_Up,
        Eat
    }

    public static Dictionary<Interaction, float> executionSpeeds = new Dictionary<Interaction, float>()
    {
        { Interaction.Examine,1 },
        { Interaction.Drop,1 },
        { Interaction.Throw,1 },
        { Interaction.Pick_Up,1 },
        { Interaction.Eat,1 },
    };
}
