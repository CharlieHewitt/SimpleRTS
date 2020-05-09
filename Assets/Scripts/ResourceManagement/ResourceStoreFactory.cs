using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceStoreFactory
{
    public static ResourceStore Create(ResourceType type)
    {
        return new ResourceStore(type);
    }

    public static ResourceStore CreateWithStartingResources(ResourceType type, int initialAmount)
    {
        ResourceStore store = new ResourceStore(type);
        store.PayIn(new ResourceCost(type, initialAmount));

        return store;
    }
}
