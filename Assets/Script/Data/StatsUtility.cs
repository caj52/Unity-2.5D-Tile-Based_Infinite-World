using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    Might,
    Will,
    Reflex,
    Wit,
    Fortitude,
    Endurance
}

public static class StatsUtility
{
    public static int maxStatValue = 20;
    public static Dictionary<StatType,int> GetDefaultStats()
    {

        return new Dictionary<StatType, int>()
        {
            {StatType.Might, 5},
            {StatType.Will, 5},
            {StatType.Reflex, 5},
            {StatType.Wit, 5},
            {StatType.Fortitude, 5},
            {StatType.Endurance, 5},
        };
    }
    public static int GetStat(Dictionary<StatType,int> stats,StatType stat)
    {
        stats.TryGetValue(stat, out int value);
        return value;
    }
    public static int GetTotalHealth(Dictionary<StatType,int> stats)
    {
        float fortitude = GetStat(stats, StatType.Fortitude);
        float might = GetStat(stats, StatType.Might);
        float endurance = GetStat(stats, StatType.Endurance);

        return Mathf.RoundToInt(((fortitude * 2) + endurance+(might/2))/2);
    }
    public static int GetSpeed(Dictionary<StatType,int> stats)
    {
        float reflex = GetStat(stats, StatType.Reflex);
        float might = GetStat(stats, StatType.Might);

        return Mathf.RoundToInt(((reflex * 2) + (might/2))/2);
    }
    public static int CalculateDamageMitigated(Dictionary<StatType,int> stats, float damage)
    {
        float randomFloat = ((float)Random.Range(0, 60) / 100);
        
        float fortitude = randomFloat * ((damage/GetStat(stats, StatType.Fortitude))/2);
        float endurance = randomFloat * ((damage/GetStat(stats, StatType.Endurance))/2);
        float might = randomFloat * ((damage/GetStat(stats, StatType.Might))/2);
        float reflex = randomFloat * ((damage/GetStat(stats, StatType.Reflex))/2);

        float damageMitigated = fortitude + endurance + might + reflex;
        
        if (damage - damageMitigated < 0)
            return 0;
        
        return Mathf.RoundToInt(damage - damageMitigated);
    }
    public static Dictionary<NeedsTypes.Need, int> GetNeedsDepreciation(Dictionary<StatType,int> stats)
    {
        Dictionary<NeedsTypes.Need,int> newValues = new Dictionary<NeedsTypes.Need,int>();
        
        stats.TryGetValue(StatType.Endurance, out var endurance);
        int hungerDepreciation = Mathf.Abs(endurance - maxStatValue) / 2;
        
        stats.TryGetValue(StatType.Will, out var will);
        int sleepDepreciation = Mathf.Abs(  ( (endurance+will) /2 ) - maxStatValue) / 2;
        
        newValues.Add(NeedsTypes.Need.Hunger,hungerDepreciation);
        newValues.Add(NeedsTypes.Need.Sleep,sleepDepreciation);

        return newValues;
    }
    public static Vector3 CalculateKnockbackVelocity(Dictionary<StatType,int> stats,Creature creature ,float knockBackStrength)
    {
        var creatureTransform = creature.transform;
        var might = GetStat(stats, StatType.Might);
        var direction = -creatureTransform.forward+(creatureTransform.up/might);
        direction *= (knockBackStrength/6);
        return direction;
    }
}
