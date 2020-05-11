using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingModel
{
    protected BuildingType type;

    // game ticks
    protected int constructionTime;

    protected ResourceTransaction buildCost;

    // generic method to define building cost (eventually could be from a database or something)
    protected abstract ResourceTransaction InitialiseCost();


}
