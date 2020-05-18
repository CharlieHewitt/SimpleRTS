using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlotController
{
    private BuildPlotMap buildPlotMap;

    // views
    private Dictionary<BuildPlotLocation, BuildPlotView> buildPlotViews;

    public BuildPlotController()
    {
        buildPlotMap = new BuildPlotMap();
        InitialiseBuildPlotViews();
    }

    public bool IsBuildable(BuildPlotLocation location)
    {
        return buildPlotMap.IsBuildable(location);
    }

    public void Build(BuildPlotLocation location, BuildingType buildingType, BuildingModel buildingModel)
    {
        buildPlotMap.Build(location, buildingType, buildingModel);
        OutputPlotStatus();
        UpdateBuildPlotView(location);
    }

    public bool IsDemolishable(BuildPlotLocation location)
    {
        return buildPlotMap.IsDemolishable(location);
    }

    public void Demolish(BuildPlotLocation location)
    {
        buildPlotMap.Demolish(location);
        OutputPlotStatus();
        UpdateBuildPlotView(location);
    }

    public void OutputPlotStatus()
    {
        Debug.Log(buildPlotMap.StatusString());
    }

    // View related code

    public void InitialiseBuildPlotViews()
    {
        buildPlotViews = new Dictionary<BuildPlotLocation, BuildPlotView>();

        buildPlotViews[BuildPlotLocation.NORTH_EAST] = GameObject.Find("BuildPlotPanel - NorthEast").GetComponent<BuildPlotView>();
        buildPlotViews[BuildPlotLocation.NORTH_WEST] = GameObject.Find("BuildPlotPanel - NorthWest").GetComponent<BuildPlotView>();
        buildPlotViews[BuildPlotLocation.SOUTH] = GameObject.Find("BuildPlotPanel - South").GetComponent<BuildPlotView>();
        buildPlotViews[BuildPlotLocation.WEST] = GameObject.Find("BuildPlotPanel - West").GetComponent<BuildPlotView>();

        foreach (BuildPlotLocation location in buildPlotViews.Keys)
        {
            UpdateBuildPlotView(location);
        }
    }

    public void UpdateBuildPlotView(BuildPlotLocation location)
    {
        bool isUnderConstruction = buildPlotMap.IsUnderConstruction(location);
        buildPlotViews[location].UpdateUnderConstruction(isUnderConstruction);

        string building = GetBuildingOnPlotAsString(location);
        buildPlotViews[location].UpdateCurrentBuilding(building);
    }

    public string GetBuildingOnPlotAsString(BuildPlotLocation location)
    {
        BuildingType type = buildPlotMap.GetBuilding(location);
        switch(type)
        {
            case BuildingType.NONE:
                return "Empty";

            case BuildingType.BLACKSMITHS:
                return "Blacksmiths";

            case BuildingType.FLETCHERS_WORKSHOP:
                return "Fletcher's workshop";

            case BuildingType.MAGICAL_WAND_SHOP:
                return "Magical wand shop";

            default:
                Debug.LogError("BuildingType not implemented");
                return "error";
        }
    }

}
