using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUnitCommand : GameBehaviourCommand
{
    private UnitType unitType;
    private UnitPurchaseModel model;

    public BuyUnitCommand(UnitType unitType)
    {
        this.unitType = unitType;
        model = null;
        Debug.Log("buy unit command created");
    }

    public override bool OnCreate()
    {
        return true;

        // nothing special for AddWorkerCommand
    }

    public override void Execute()
    {
        Debug.Log("buy unit command executing");
        ArmyController armyController = GetArmyController();
        ResourceController resourceController = GetResourceController();

        model = UnitPurchaseModelFactory.Create(unitType);

        bool supplyAvailable = armyController.CheckSupply(model);
        
        if (!supplyAvailable)
        {
            // abort
            Debug.LogError("no supply available");
            return;
        }

        // transaction succeeds
        if (resourceController.PayOutTransaction(model.buildCost))
        {
            armyController.AddUnitToBuildQueue(model);
        }
        // Get ArmyController.CheckSupply()
        // Try Transaction
        // If works
        // Get ArmyController.ReserveSupply()
        // -> add unit to construction queue for x ticks
    }



}
