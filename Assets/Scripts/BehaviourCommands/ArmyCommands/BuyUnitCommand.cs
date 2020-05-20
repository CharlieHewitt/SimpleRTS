using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUnitCommand : GameBehaviourCommand
{
    private UnitType unitType;
    private UnitPurchaseModel model;

    public BuyUnitCommand(UnitType unitType, PlayerType playerType)
    {
        this.playerType = playerType;

        this.unitType = unitType;
        model = null;
        Debug.Log("buy unit command created");
    }

    public override bool Execute()
    {
        Debug.Log("buy unit command executing");
        ArmyController armyController = GetArmyController();
        ResourceController resourceController = GetResourceController();

        model = UnitPurchaseModelFactory.Create(unitType);


        // Check if prerequisite building has been built
        bool prerequisiteBuilt = GetBuildPlotController().IsComplete(model.prerequisite);


        if (!prerequisiteBuilt)
        {
            // abort
            Debug.LogError(string.Format("Can't construct {0}, as its prerequisite building {1} hasn't been constructed.", unitType, model.prerequisite));
            GetGameLogController().Log(string.Format("Error: Can't construct {0}, as its prerequisite building {1} hasn't been constructed.", unitType, model.prerequisite));
            return false;
        }

        // Check supply

        bool supplyAvailable = armyController.CheckSupply(model);
        if (!supplyAvailable)
        {
            // abort
            Debug.LogError("no supply available");
            GetGameLogController().Log("Error: Not enough supply to construct" + unitType);

            return false;
        }

        // transaction succeeds
        if (resourceController.PayOutTransaction(model.buildCost))
        {
            armyController.AddUnitToBuildQueue(model);
        }
        else // rejected
        {
            GetGameLogController().Log("Error: Not enough resources to construct" + unitType);
            return false;
        }

        return true;
    }



}
