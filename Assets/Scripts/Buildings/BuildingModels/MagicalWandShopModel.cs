using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalWandShopModel : BuildingModel
{
    public MagicalWandShopModel()
    {
        type = BuildingType.MAGICAL_WAND_SHOP;
        constructionTime = 60;
        buildCost = InitialiseCost();
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 1500));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 1000));

        return transaction;
    }

}