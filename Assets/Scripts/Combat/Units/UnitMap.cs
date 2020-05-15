using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This is a wrapper controlling access to a map of <BuildPlotLocation, BuildPlot>
public class UnitMap
{
    private Dictionary<UnitType, int> units;

    public UnitMap()
    {
        units = new Dictionary<UnitType, int>();
        SetToDefault();
    }

    private void SetToDefault()
    {
        foreach (UnitType unitType in Enum.GetValues(typeof(UnitType)).Cast<UnitType>())
        {
            units[unitType] = 0;
        }
    }

    public string StatusString()
    {
        string output = "Army:\n";

        foreach (UnitType unit in units.Keys)
        {
            output += string.Format("{0} ({1}) ", unit, units[unit]);
        }

        return output;
    }

    public void Add(UnitType unitType)
    {
        units[unitType]++;
    }

    public void Remove(UnitType unitType)
    {
        units[unitType]--;
    }

    public void AddMultiple(UnitType unitType, int amount)
    {
        units[unitType] += amount;
    }

    public void RemoveMultiple(UnitType unitType, int amount)
    {
        units[unitType] -= amount;
    }

}


