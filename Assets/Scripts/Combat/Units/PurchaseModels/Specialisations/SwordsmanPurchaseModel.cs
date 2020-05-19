using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanPurchaseModel : UnitPurchaseModel
{
    public SwordsmanPurchaseModel()
    {
        unitType = UnitType.SWORDSMAN;
        trainingTime = 20;
        armySize = 1;
        buildCost = InitialiseCost();
        prerequisite = BuildingType.BLACKSMITHS;
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 100));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 0));

        return transaction;
    }

}