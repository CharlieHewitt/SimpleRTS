using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Army
{
    private PlayerType playerType;
    public UnitMap unitMap { get; private set; }
    private UnitTrainingQueue queue;

    public int currentSupply { get; private set; }
    public int maxSupply { get; private set; }



    public Army(PlayerType playerType)
    {
        this.playerType = playerType;
        queue = new UnitTrainingQueue(playerType);
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
        RemoveSupply(unitType);
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
    public void RemoveSupply(UnitType type)
    {
        int supplyToRemove = UnitPurchaseModelFactory.Create(type).armySize;

        if (currentSupply >= supplyToRemove)
        {
            currentSupply -= supplyToRemove;
        }
    }

    public void IncreaseSupply(int number)
    {
        maxSupply += number;
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

