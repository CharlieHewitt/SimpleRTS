using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitPurchaseModel
{
    protected UnitType type;

    // game ticks
    protected int trainingTime;

    protected int armySize;

    protected ResourceTransaction buildCost;

    protected BuildingType prerequisite;

    // generic method to define unit cost (eventually could be from a database or something)
    protected abstract ResourceTransaction InitialiseCost();


}
