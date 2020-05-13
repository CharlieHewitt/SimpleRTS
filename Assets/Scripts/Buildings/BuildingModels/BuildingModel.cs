using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingModel
{
    public BuildingType type { get; protected set; }

    // game ticks
    public int constructionTime { get; protected set; }

    public ResourceTransaction buildCost { get; protected set; }

    // generic method to define building cost (eventually could be from a database or something)
    protected abstract ResourceTransaction InitialiseCost();


}
