using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FletchersWorkshopModel : BuildingModel
{
    public FletchersWorkshopModel()
    {
        type = BuildingType.FLETCHERS_WORKSHOP;
        constructionTime = 45;
        buildCost = InitialiseCost();
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 750));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 0));

        return transaction;
    }

}