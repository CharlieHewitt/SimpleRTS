using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This is a wrapper controlling access to a map of <BuildPlotLocation, BuildPlot>
public class Army
{
    private UnitMap unitMap;
    private UnitTrainingQueue queue;

    private int currentSupply;
    private int maxSupply;

    public Army()
    {
        unitMap = new UnitMap();
    }

    public string StatusString()
    {
        return unitMap.StatusString();
    }

    public void AddUnit(UnitPurchaseModel model)
    {
        unitMap.Add(model.unitType);
    }

    public void RemoveUnit(UnitType unitType)
    {
        unitMap.Remove(unitType);
    }

    public bool CheckSupply(UnitPurchaseModel model)
    {
        return (model.armySize + currentSupply <= maxSupply);
    }


    // done at start of construction -> before unit is "finished"!
    public void ReserveSupply(UnitPurchaseModel model)
    {
        currentSupply += model.armySize;
    }

    // Maybe needed for post combat situations
    public void ResetSupply(int num)
    {

    }


}

