using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlot
{
    public BuildingType buildingType { get; private set; }
    public Vector3 position { get; private set; }

    public BuildPlot(Vector3 pos)
    {
        buildingType = BuildingType.NONE;
        position = pos;
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
        return (string.Format("Build plot information:\nPosition: ({0},{1},{2}) Building: {3}", position.x, position.y, position.z, buildingType));
    }

}