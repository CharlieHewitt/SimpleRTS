using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitPurchaseModel
{
    public UnitType unitType { get; protected set; }

    // game ticks
    public int trainingTime { get; protected set; }

    public int armySize { get; protected set; }

    public ResourceTransaction buildCost { get; protected set; }

    public BuildingType prerequisite { get; protected set; }

    // generic method to define unit cost (eventually could be from a database or something)
    protected abstract ResourceTransaction InitialiseCost();


}
