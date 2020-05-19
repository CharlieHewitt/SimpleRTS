using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithsModel : BuildingModel
{
    public BlacksmithsModel()
    {
        type = BuildingType.BLACKSMITHS;
        constructionTime = 50;
        buildCost = InitialiseCost();
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 1000));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 0));

        return transaction;
    }

}