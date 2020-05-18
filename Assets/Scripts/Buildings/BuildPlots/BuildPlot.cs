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

    // These values are updated when a new building is constructed
    private int constructedTicks;
    private int constructionTime;

    public BuildPlot(BuildPlotLocation location)
    {
        buildingType = BuildingType.NONE;
        this.location = location;
        isUnderConstruction = false;
        constructedTicks = 0;
        constructionTime = 0;
    }

    public bool IsEmpty()
    {
        return (buildingType == BuildingType.NONE);
    }

    public void Build(BuildingType type, BuildingModel buildingModel)
    {
        if (!IsEmpty())
        {
            Debug.Log(string.Format("Can't build {0}. There is already a building on this plot ({1})", type, buildingType));
            return;
        }

        // update state
        buildingType = type;
        isUnderConstruction = true;

        BuildForTicks(buildingModel.constructionTime);
    }

    public void Demolish()
    {
        if (IsEmpty())
        {
            Debug.Log("Can't demolish. There is no building on this plot.");
        }

        // update state
        buildingType = BuildingType.NONE;
    }

    public string StatusString()
    {
        return (string.Format("Plot {0} = {1}",location, buildingType));
    }


    // ------------------------ Time Tick Building

    public void BuildForTicks(int ticks)
    {
        constructedTicks = 0;
        constructionTime = ticks;
        TimeTickSystem.OnTick += OnTickEventHandler;
    }

    public void OnTickEventHandler(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (constructedTicks < constructionTime)
        {
            constructedTicks++;
        }
        else
        {
            isUnderConstruction = false;
            Unsubscribe();
            Debug.Log("command succesfully executed.");

           // update view on building completion!!
           // GameObject.Find("BuildPlotController").GetComponent<BuildPlotController>().UpdateBuildPlotView(location);
        }
    }

    public void Unsubscribe()
    {
        TimeTickSystem.OnTick -= OnTickEventHandler;
    }

}