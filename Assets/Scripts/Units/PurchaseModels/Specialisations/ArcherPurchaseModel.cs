using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPurchaseModel : UnitPurchaseModel
{
    public ArcherPurchaseModel()
    {
        type = UnitType.ARCHER;
        trainingTime = 40;
        armySize = 1;
        buildCost = InitialiseCost();
        prerequisite = BuildingType.FLETCHERS_WORKSHOP;
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 100));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 0));

        return transaction;
    }

}