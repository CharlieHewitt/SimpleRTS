using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceCostFactory
{
    public static ResourceCost Create(ResourceType type, int amount)
    {
        return new ResourceCost(type, amount);
    }

}
