using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// CHECK PREREQS FOR BUILDING UNITS
public class Army
{
    public UnitMap unitMap { get; private set; }
    private UnitTrainingQueue queue;

    private int currentSupply;
    private int maxSupply;



    public Army()
    {
        queue = new UnitTrainingQueue();
        unitMap = new UnitMap();
        currentSupply = 0;
        maxSupply = 20;
    }

    public string StatusString()
    {
        string output = string.Format("supply: {0}/{1}\n", currentSupply, maxSupply);
        return output += unitMap.StatusString();
    }

    public string QueueStatus()
    {
        return queue.QueueStatus();
    }

    public void AddUnit(UnitPurchaseModel model)
    {
        queue.AddToQueue(model);
    }


    // To be called by UnitTrainer
    public void AddCompleteUnit(UnitPurchaseModel model)
    {
        unitMap.Add(model.unitType);
    }

    public void RemoveUnit(UnitType unitType)
    {
        unitMap.Remove(unitType);
    }

    public bool CheckSupply(UnitPurchaseModel model)
    {
        return (model.armySize + currentSupply) <= maxSupply;
    }


    // done at start of construction -> before unit is "finished"!
    public void ReserveSupply(UnitPurchaseModel model)
    {
        currentSupply += model.armySize;
    }

    // Maybe needed for post combat situations
    public void RemoveSupply(int num)
    {
        if (currentSupply >= num)
        {
            currentSupply -= num;
        }
    }

    public int GetNumber(UnitType type)
    {
        return unitMap.GetNumber(type);
    }

    public string SupplyStatus()
    {
        return string.Format("{0}/{1}", currentSupply, maxSupply);
    }



}

