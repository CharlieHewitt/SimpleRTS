using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlotController
{
    private BuildPlotMap buildPlotMap;

    public BuildPlotController()
    {
        buildPlotMap = new BuildPlotMap();
    }

    public bool IsBuildable(BuildPlotLocation location)
    {
        return buildPlotMap.IsBuildable(location);
    }

    public void Build(BuildPlotLocation location, BuildingType buildingType, BuildingModel buildingModel)
    {
        buildPlotMap.Build(location, buildingType, buildingModel);
        OutputPlotStatus();
    }

    public bool IsDemolishable(BuildPlotLocation location)
    {
        return buildPlotMap.IsDemolishable(location);
    }

    public void Demolish(BuildPlotLocation location)
    {
        buildPlotMap.Demolish(location);
        OutputPlotStatus();
    }

    public void OutputPlotStatus()
    {
        Debug.Log(buildPlotMap.StatusString());
    }

}
