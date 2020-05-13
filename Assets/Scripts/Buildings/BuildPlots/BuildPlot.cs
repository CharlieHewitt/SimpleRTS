using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlot
{
    public BuildingType buildingType { get; private set; }
    public BuildPlotLocation location { get; private set; }

    // figure out how to use this one to stop multiple commands on same buildingplot queue up!
    public bool isUnderConstruction { get; private set; }

    public BuildPlot(BuildPlotLocation location)
    {
        buildingType = BuildingType.NONE;
        this.location = location;
    }

    public void Build(BuildingType type)
    {
        if (buildingType != BuildingType.NONE)
        {
            Debug.Log(string.Format("Can't build {0}. There is already a building on this plot ({1})", type, buildingType));
            return;
        }

        // update state
        buildingType = type;
    }

    public void Demolish(BuildingType type)
    {
        if (buildingType == BuildingType.NONE)
        {
            Debug.Log("Can't demolish. There is no building on this plot.");
        }

        // update state
        buildingType = BuildingType.NONE;
    }

    public string StatusString()
    {
        return (string.Format("Build plot information:\nPosition: ({0}) Building: {1}",location, buildingType));
    }

}