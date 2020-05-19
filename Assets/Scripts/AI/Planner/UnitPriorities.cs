using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitPriorities
{
    public Dictionary<UnitType, float> priorities;
    public readonly float totalPriority;
    
    public UnitPriorities()
    {
        priorities = new Dictionary<UnitType, float>();
        SetToDefault();

        totalPriority = 3f;
    }

    public UnitPriorities(float swordsmanPriority, float archerPriority, float wizardPriority)
    {
        priorities = new Dictionary<UnitType, float>();
        SetToValues(swordsmanPriority, archerPriority, wizardPriority);

        totalPriority = 3f;
    }

    private void SetToDefault()
    {
        foreach (UnitType type in Enum.GetNames(typeof(UnitType)).Cast<UnitType>())
        {
            priorities.Add(type, 1);
        }
    }
    
    public void SetToValues(float swordsmanPriority, float archerPriority, float wizardPriority)
    {
        if (swordsmanPriority + archerPriority + wizardPriority == 3f)
        {
            priorities[UnitType.SWORDSMAN] = swordsmanPriority;
            priorities[UnitType.ARCHER] = archerPriority;
            priorities[UnitType.WIZARD] = wizardPriority;
        }
        else
        {
            Debug.LogError("Bad unit Priority values (sum != 3)");
        }
    }

    // Increases priority of {toIncrease} by {value}, decreases {toDecrease} by {value}
    public void IncreasePriority(UnitType toIncrease, UnitType toDecrease, float value)
    {
        priorities[toIncrease] += value;
        priorities[toDecrease] -= value;

        if (!CheckSum())
        {
            Debug.LogError("Bad unit Priority values (sum != 3)");
        }
    }

    // Increases priority of {toIncrease} by {totalValue}, splits decrease evenly between {toDecrease1} and {toDecrease2}
    public void IncreasePriority(UnitType toIncrease, UnitType toDecrease1, UnitType toDecrease2, float totalValue)
    {
        priorities[toIncrease] += totalValue;

        float decreaseValue1 = totalValue / 2f;
        float decreaseValue2 = totalValue - decreaseValue1;

        priorities[toDecrease1] -= decreaseValue1;
        priorities[toDecrease2] -= decreaseValue2;

        if (!CheckSum())
        {
            Debug.LogError("Bad unit Priority values (sum != 3)");
        }
    }

    public bool CheckSum()
    {
        float total = 0;
        foreach (float num in priorities.Values)
        {
            total += num;
        }

        return total == totalPriority;
    }

    public float Get(UnitType type)
    {
        return priorities[type];
    }
}
