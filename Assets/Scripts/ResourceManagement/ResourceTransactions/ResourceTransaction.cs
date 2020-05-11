using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTransaction
{
    // should this be type exclusive? probably? idk -> think about a set/ condensing resourceCosts into one another to reduce lookup times/ compares
    // iterable list of ResourceCosts

    public List<ResourceCost> resourceCosts {  get; private set; }


    public ResourceTransaction()
    {
        resourceCosts = new List<ResourceCost>();
    }

    public void AddResourceCost(ResourceCost cost)
    {
        resourceCosts.Add(cost);
    }

    public string FormattedStatusString() 
    {
        string output = "ResourceTransaction:\n";
        
        foreach (ResourceCost cost in resourceCosts)
        {
            output += cost.FormattedStatusString() + "  ";
        }

        return output;
    }
}
