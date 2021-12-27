using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Creature : MonoBehaviour
{
    public int totalHealth { get; private set; }
    public int currentHealth{ get; private set; }
    public int speed{ get; private set; }
    [HideInInspector]public Rigidbody rigidbody;
    [HideInInspector]public SpriteRenderer renderer;
    public Dictionary<StatType, int> stats{ get; private set; }
    public StatusNumbers statusNumbers;
    private bool inUpdateMethod;
    public InventoryObjectType.InventoryObject heldObject { get; private set; }

    public Dictionary<NeedsTypes.Need, int> needsValue = new Dictionary<NeedsTypes.Need, int>()
    {
        {NeedsTypes.Need.Hunger,100},
        {NeedsTypes.Need.Sleep,100}
    };
    public Dictionary<NeedsTypes.Need, int> needsDepreciation = new Dictionary<NeedsTypes.Need, int>()
    {
        {NeedsTypes.Need.Hunger,1},
        {NeedsTypes.Need.Sleep,1}
    };
    

    private void Update()
    {
        if (!inUpdateMethod)
            StartCoroutine(DeppreciateNeeds());
    }

    public void Init()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<SpriteRenderer>();
        stats = StatsUtility.GetDefaultStats(); 
        
        SetTotalHealth();
        SetSpeed();
        SetNeedsDepreciation();
        SetHeldObject(InventoryObjectType.InventoryObject.None);
    }

    public void Move(Vector3 direction)
    {
        rigidbody.velocity += direction;
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity,speed);
    }
    public void StopMoveImmediate()
    {
        rigidbody.velocity =Vector3.zero;
    }

    private void SetTotalHealth()
    {
        totalHealth = StatsUtility.GetTotalHealth(stats);
        currentHealth = totalHealth;
        PlayerHealth.Instance.UpdateTotalHealth();
    }
    private void SetSpeed()
    {
        speed = StatsUtility.GetSpeed(stats);
    }

    private void SetNeedsDepreciation()
    {
        needsDepreciation = StatsUtility.GetNeedsDepreciation(stats);
    }
    public void SetHeldObject(InventoryObjectType.InventoryObject newObject)
    {
        heldObject = newObject;
    }
    public IEnumerator TakeDamage(int totalDamage)
    {
        var finalDamage = StatsUtility.CalculateDamageMitigated(stats, totalDamage);
        var player = GetComponent<Player>();

        AppendCurrentHealth(-finalDamage);
        
        StopMoveImmediate();
        
        player.SetFreezeInput(true); //TODO Add functionality to ignore input when in air instead of doing it as part of take damage
        
        KnockBack(finalDamage*2);
        
        PlayerHealth.Instance.UpdateHealthPoints();
        
        statusNumbers.DisplayDamage(finalDamage);
        StartCoroutine(FlashColor(Color.red, .1f));
        
        yield return new WaitForSeconds(.5f);
        
        player.SetFreezeInput(false);
    }

    private void KnockBack(int knockbackStrength)
    {
        var direction = StatsUtility.CalculateKnockbackVelocity(stats, this,knockbackStrength);
        rigidbody.velocity = direction;
    }

    private IEnumerator FlashColor(Color color, float secondsDuration)
    {
        var initColor = renderer.color;
        renderer.color = color;
        yield return new WaitForSeconds(secondsDuration);
        renderer.color = initColor;
    }

    private void AppendCurrentHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;
    }

    private IEnumerator DeppreciateNeeds()
    {
        inUpdateMethod = true;

        yield return new WaitForSeconds(30);
        
        var newNeeds = new Dictionary<NeedsTypes.Need, int>();
        foreach (var entry in needsValue)
        {
            needsDepreciation.TryGetValue(entry.Key, out var depreciationValue);
            var newValue = entry.Value - depreciationValue;
            newNeeds.Add(entry.Key,newValue);
        }
        
        needsValue = newNeeds;

        if (TryGetComponent<Player>(out var player))
            player.UpdateNeedsIcons();
        
        inUpdateMethod = false;
    }

    public void Eat(InteractableObject consumable)
    {
        
    }
}
