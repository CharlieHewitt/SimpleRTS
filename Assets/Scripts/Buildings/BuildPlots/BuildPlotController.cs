using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlotController
{
    private PlayerType playerType;
    public BuildPlotMap buildPlotMap { get; private set; }

    // views
    private Dictionary<BuildPlotLocation, BuildPlotView> buildPlotViews;
    private Dictionary<BuildingType, BuildingInfoView> buildingInfoViews;

    public BuildPlotController(PlayerType playerType)
    {
        this.playerType = playerType;
        buildPlotMap = new BuildPlotMap(playerType);
        InitialiseBuildPlotViews();
        InitialiseBuildingInfoViews();
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
        UpdateBuildingInfoView(buildingType);
    }

    public bool IsDemolishable(BuildPlotLocation location)
    {
        return buildPlotMap.IsDemolishable(location);
    }

    public void Demolish(BuildPlotLocation location)
    {
        // get type for view update
        BuildingType buildingType = buildPlotMap.GetBuilding(location);

        // demolish
        buildPlotMap.Demolish(location);

        // update views
        OutputPlotStatus();
        UpdateBuildPlotView(location);
        UpdateBuildingInfoView(buildingType);
    }

    public bool IsBuilt(BuildingType type)
    {
        return buildPlotMap.IsBuilt(type);
    }

    public bool IsComplete(BuildingType type)
    {
        return buildPlotMap.IsComplete(type);
    }

    public void OutputPlotStatus()
    {
        Debug.Log(buildPlotMap.StatusString());
    }

    // --------------- View related code

    private void InitialiseBuildPlotViews()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

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

    private void InitialiseBuildingInfoViews()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        buildingInfoViews = new Dictionary<BuildingType, BuildingInfoView>();

        buildingInfoViews[BuildingType.BLACKSMITHS] = GameObject.Find("BuildingPanel - Blacksmiths").GetComponent<BuildingInfoView>();
        buildingInfoViews[BuildingType.FLETCHERS_WORKSHOP] = GameObject.Find("BuildingPanel - FletchersWorkshop").GetComponent<BuildingInfoView>();
        buildingInfoViews[BuildingType.MAGICAL_WAND_SHOP] = GameObject.Find("BuildingPanel - MagicalWandShop").GetComponent<BuildingInfoView>();

        foreach (BuildingType type in buildingInfoViews.Keys)
        {
            buildingInfoViews[type].UpdateConstructionCost(type);
        }
    }


    public void UpdateBuildPlotView(BuildPlotLocation location)
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        bool isUnderConstruction = buildPlotMap.IsUnderConstruction(location);
        buildPlotViews[location].UpdateUnderConstruction(isUnderConstruction);

        BuildingType building = buildPlotMap.GetBuilding(location);
        buildPlotViews[location].UpdateCurrentBuilding(building);
    }

    private void UpdateBuildingInfoView(BuildingType type)
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        bool isBuilt = IsBuilt(type);
        buildingInfoViews[type].UpdateIsBuilt(isBuilt);
    }


}
