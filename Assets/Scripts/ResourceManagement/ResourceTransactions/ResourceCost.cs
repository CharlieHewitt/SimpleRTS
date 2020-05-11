using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCost
{
    public ResourceType type {  get; private set; }
    public int amount { get; private set; }

    public ResourceCost(ResourceType type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }

    public string FormattedStatusString()
    {
        return string.Format("{0} ({1})", type, amount);
    }
}
