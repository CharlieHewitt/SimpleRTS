using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This is a wrapper controlling access to a map of <BuildPlotLocation, BuildPlot>
public class BuildPlotMap
{
    private Dictionary<BuildPlotLocation, BuildPlot> buildPlots;

    public BuildPlotMap()
    {
        buildPlots = new Dictionary<BuildPlotLocation, BuildPlot>();
        SetToDefault();
    }

    private void SetToDefault()
    {
        foreach (BuildPlotLocation location in Enum.GetValues(typeof(BuildPlotLocation)).Cast<BuildPlotLocation>())
        {
            buildPlots[location] = new BuildPlot(location);
        }
    }

    public string StatusString()
    {
        string output = "Plots:\n";
        
        foreach (BuildPlot plot in buildPlots.Values)
        {
            output += plot.StatusString();
        }

        return output;
    }

    public BuildingType GetBuilding(BuildPlotLocation location)
    {
        return buildPlots[location].buildingType;
    }


    public bool IsUnderConstruction(BuildPlotLocation location)
    {
        return buildPlots[location].isUnderConstruction;
    }

    // Safety functions
    public bool IsBuildable(BuildPlotLocation location)
    {
        return (buildPlots[location].IsEmpty() && !buildPlots[location].isUnderConstruction);
    }

    public bool IsDemolishable(BuildPlotLocation location)
    {
        return !(buildPlots[location].IsEmpty() || buildPlots[location].isUnderConstruction);
    }


    // Check if buildable before this!
    public void Build(BuildPlotLocation location, BuildingType buildingType, BuildingModel buildingModel)
    {

        buildPlots[location].Build(buildingType, buildingModel);
    }

    // Check if Demolishable before this!
    public void Demolish(BuildPlotLocation location)
    {
        buildPlots[location].Demolish();
    }

}


