using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStoreMap
{
    public Dictionary<ResourceType, ResourceStore> resourceStores { get; private set; }

    public ResourceStoreMap()
    {
        resourceStores = new Dictionary<ResourceType, ResourceStore>();
    }

    // should take in the store tbh
    public void AddResourceStore(ResourceType type, ResourceStore store)
    {
        if (resourceStores.ContainsKey(type))
        {
            // error -> store of that type already exists 
        }

        resourceStores.Add(type, store);
    }

    // TODO: cleanup transaction.resourceCosts ...
    public bool IsTransactionPossible(ResourceTransaction transaction)
    {
        foreach (var cost in transaction.resourceCosts)
        {
            ResourceType type = cost.type;

            if (!resourceStores.ContainsKey(type))
            {
                // error -> no resource store of that type
                return false;
            }

            if (!transaction.toBePayedIn && !resourceStores[type].CheckPayOutPossible(cost))
            {
                // error -> not enough resources
                return false;
            }

        }

        return true;
    }

    // TODO: cleanup transaction.resourceCosts ...
    public void PerformTransaction(ResourceTransaction transaction)
    {
        if (!IsTransactionPossible(transaction))
        {
            // error -> not enough resources
        }


        foreach(var cost in transaction.resourceCosts)
        {

            ResourceStore store = resourceStores[cost.type];
            if (transaction.toBePayedIn)
            {
                store.PayIn(cost);
            }
            else
            {
                store.PayOut(cost);
            }
        }
    }


    // public void RemoveResourceStore(ResourceType) -> shouldnt be needed?


}
