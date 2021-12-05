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
        var fortitude = GetStat(stats, StatType.Fortitude);
        var might = GetStat(stats, StatType.Might);
        var endurance = GetStat(stats, StatType.Endurance);

        return Mathf.RoundToInt(((fortitude * 2) + endurance+(might/2))/2);
    }
    public static int GetSpeed(Dictionary<StatType,int> stats)
    {
        var reflex = GetStat(stats, StatType.Reflex);
        var might = GetStat(stats, StatType.Might);

        return Mathf.RoundToInt(((reflex * 2) + (might/2))/2);
    }
    public static int CalculateDamageMitigated(Dictionary<StatType,int> stats, int damage)
    {
        float randomFloat = ((float)Random.Range(0, 60) / 100);
        
        var fortitude = randomFloat * ((damage/GetStat(stats, StatType.Fortitude))/2);
        var endurance = randomFloat * ((damage/GetStat(stats, StatType.Endurance))/2);
        var might = randomFloat * ((damage/GetStat(stats, StatType.Might))/2);
        var reflex = randomFloat * ((damage/GetStat(stats, StatType.Reflex))/2);

        var damageMitigated = fortitude + endurance + might + reflex;
        
        if (damage - damageMitigated < 0)
            return 0;
        
        return Mathf.RoundToInt(damage - damageMitigated);
    }

    public static Vector3 CalculateKnockbackVelocity(Dictionary<StatType,int> stats,Creature creature ,int knockBackStrength)
    {
        var might = GetStat(stats, StatType.Might);
        var direction = -creature.transform.forward+(creature.transform.up/might);
        direction *= (knockBackStrength/6);
        return direction;
    }
}
