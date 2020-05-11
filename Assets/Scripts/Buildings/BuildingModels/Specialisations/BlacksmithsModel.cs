using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithsModel : BuildingModel
{
    public BlacksmithsModel()
    {
        type = BuildingType.BLACKSMITHS;
        constructionTime = 30;
        buildCost = InitialiseCost();
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 500));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 100));

        return transaction;
    }

}