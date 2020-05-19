using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalWandShopModel : BuildingModel
{
    public MagicalWandShopModel()
    {
        type = BuildingType.MAGICAL_WAND_SHOP;
        constructionTime = 150;
        buildCost = InitialiseCost();
    }

    protected override ResourceTransaction InitialiseCost()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.WOOD, 1200));
        transaction.AddResourceCost(ResourceCostFactory.Create(ResourceType.MAGIC_STONE, 3000));

        return transaction;
    }

}