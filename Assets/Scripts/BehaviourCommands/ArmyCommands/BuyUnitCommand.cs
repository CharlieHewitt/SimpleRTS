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

        model = UnitPurchaseModelFactory.Create(unitType);

        // Get ArmyController.CheckSupply()
        // Try Transaction
        // If works
        // Get ArmyController.ReserveSupply()
        // -> add unit to construction queue for x ticks
    }



}
