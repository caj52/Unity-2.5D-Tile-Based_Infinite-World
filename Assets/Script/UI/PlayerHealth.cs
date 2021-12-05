using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    private Creature player;
    public void Init()
    {
        Instance = this;
        
    }
    public void UpdateTotalHealth()
    {
        player = Player.creature;
        var totalHealth = Player.creature.totalHealth;
        var basePoint = transform.GetChild(0);
        ClearHealthPoints();
        for (int x =1; x<totalHealth;x++)
        {
            var newPoint = Instantiate(basePoint);
            newPoint.parent = transform;
            var newPosition = basePoint.position;
            newPosition.x += x*25;
            newPoint.transform.position = newPosition;
        }
    }

    public void ClearHealthPoints()
    {
        var totalChildren = transform.childCount;
        for (int x=1;x<totalChildren;x++)
        {
            Destroy(transform.GetChild(x));
        }
    }

    public void UpdateHealthPoints()
    {
        for (int x =0;x<transform.childCount;x++)
        {
            var healthPoint = transform.GetChild(x);
            if(x>=player.currentHealth)
                healthPoint.transform.GetChild(2).gameObject.SetActive(true);
            else
                healthPoint.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
