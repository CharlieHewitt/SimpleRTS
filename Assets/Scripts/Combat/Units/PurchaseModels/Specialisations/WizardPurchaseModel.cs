using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardPurchaseModel : UnitPurchaseModel
{
    public WizardPurchaseModel()
    {
        unitType = UnitType.WIZARD;
        trainingTime = 50;
        armySize = 2;
        prerequisite = BuildingType.MAGICAL_WAND_SHOP;
        buildCost = InitialiseCost();
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 150));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 210));

        return transaction;
    }

}