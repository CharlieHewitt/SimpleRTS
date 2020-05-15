using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStoreMap
{
    public Dictionary<ResourceType, ResourceStore> resourceStores { get; private set; }

    public ResourceStoreMap()
    {
        InitialiseStores();
    }

    //public ResourceStore get(ResourceType type)
    //{
    //    return resourceStores[type];
    //}

    // should take in the store tbh
    public void AddResourceStore(ResourceType type, ResourceStore store)
    {
        if (resourceStores.ContainsKey(type))
        {
            Debug.Log(string.Format("Error resourceStore of {0} already exists", type));
            // error -> store of that type already exists 
        }

        resourceStores.Add(type, store);
    }

    public void InitialiseStores()
    {
        resourceStores = new Dictionary<ResourceType, ResourceStore>();
        
        // "hard coded" to specific values, may want to move this initialisation elsewhere?

        resourceStores[ResourceType.WOOD] = ResourceStoreFactory.CreateWithStartingResources(ResourceType.WOOD,300);
        resourceStores[ResourceType.MAGIC_STONE] = ResourceStoreFactory.CreateWithStartingResources(ResourceType.MAGIC_STONE,50);
    }

    public bool IsTransactionPossible(ResourceTransaction transaction)
    {
        foreach (ResourceCost cost in transaction.resourceCosts)
        {
            ResourceType type = cost.type;

            if (!resourceStores.ContainsKey(type))
            {
                // error -> no resource store of that type
                Debug.LogError(string.Format("Wrong Resource Type ({0})", type));
                return false;
            }

            if (!resourceStores[type].CheckPayOutPossible(cost))
            {
                // error -> not enough resources
                Debug.LogError(string.Format("not enough {0}", type));
                return false;
            }

        }

        return true;
    }

    public void PayInTransaction(ResourceTransaction transaction)
    {
        foreach (ResourceCost cost in transaction.resourceCosts)
        {
            ResourceType type = cost.type;
            resourceStores[type].PayIn(cost);
        }

        Debug.Log(StoredResourcesStatusString());
    }


    // POTENTIAL BIG BUG -> CHECK ALL COSTS BEFORE TRANSACTING ANY => FIX
    public void PayOutTransaction(ResourceTransaction transaction)
    {
        bool success = true;
        foreach (ResourceCost cost in transaction.resourceCosts)
        {
            ResourceType type = cost.type;
            success = resourceStores[type].PayOut(cost);
        }
    }

    public string StoredResourcesStatusString()
    {
        string output = "Resources currently stored:\n";

        foreach (ResourceStore store in resourceStores.Values)
        {
            output += string.Format("{0} ({1}) ", store.type, store.storedResources);
        }

        return output;
    }

}
