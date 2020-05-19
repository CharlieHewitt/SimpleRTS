using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveUnits
{

    private HashSet<UnitType> activeUnitTypes;
    private UnitMap startingUnits;
    private UnitMap activeUnitNumbers;

    public ActiveUnits(UnitMap units)
    {
        activeUnitTypes = new HashSet<UnitType>();
        activeUnitNumbers = new UnitMap(units);
        startingUnits = new UnitMap(units);
        InitialiseActiveUnitTypes();
    }


    // Only to be called after combat to return "alive unit" to army
    public void AddUnit(UnitType type)
    {
        activeUnitNumbers.Add(type);
    }

    private void InitialiseActiveUnitTypes()
    {
        foreach (UnitType unitType in Enum.GetValues(typeof(UnitType)).Cast<UnitType>())
        {
            if (activeUnitNumbers.GetNumber(unitType) > 0)
            {
                activeUnitTypes.Add(unitType);
            }
        }
    }

    public int UnitsRemaining()
    {
        return activeUnitTypes.Count;
    }

    public UnitStats RandomlySelectUnit()
    {
        // get number of active unit types remaining
        int numTypes = activeUnitTypes.Count;

        if (numTypes == 0)
        {
            return null;
            //bad
        }

        int index = UnityEngine.Random.Range(0, numTypes);

        // randomly generate a number between 0 - numTypes

        UnitType unitType = activeUnitTypes.ElementAt(index);


        // fix unitAmounts & types
        int numUnits = activeUnitNumbers.GetNumber(unitType);

        if (numUnits == 1)
        {
            activeUnitTypes.Remove(unitType);
        }

        activeUnitNumbers.Remove(unitType);

        return UnitStatsFactory.Create(unitType);
    }

    public string MapStatusString()
    {
        return activeUnitNumbers.StatusString();
    }

    // Returns defeated unit counts
    public UnitMap GetUnitLosses()
    {
        return activeUnitNumbers.UnitsRequiredToBecome(startingUnits);
    }
}
