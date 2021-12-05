using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    private int damageDealt = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Creature creature))
           StartCoroutine(creature.TakeDamage(damageDealt));
    }
}
