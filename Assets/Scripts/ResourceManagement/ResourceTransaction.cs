using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTransaction
{
    // should this be type exclusive? probably? idk -> think about a set/ condensing resourceCosts into one another to reduce lookup times/ compares
    // iterable list of ResourceCosts

    public List<ResourceCost> resourceCosts {  get; private set; }
    public bool toBePayedIn { get; private set; }

    public ResourceTransaction(bool toBePayedIn)
    {
        resourceCosts = new List<ResourceCost>();
        this.toBePayedIn = toBePayedIn;
    }

    public void AddResourceCost(ResourceCost cost)
    {
        resourceCosts.Add(cost);
    }
}
