using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPurchaseModel : UnitPurchaseModel
{
    public ArcherPurchaseModel()
    {
        unitType = UnitType.ARCHER;
        trainingTime = 35;
        armySize = 2;
        buildCost = InitialiseCost();
        prerequisite = BuildingType.FLETCHERS_WORKSHOP;
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 150));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 25));

        return transaction;
    }

}