using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructBuildingCommand : GameBehaviourCommand
{
    private BuildPlotLocation buildPlotLocation;
    private BuildingType buildingType;
    private BuildingModel buildingModel;

    public ConstructBuildingCommand(BuildPlotLocation buildPlotLocation, BuildingType buildingType)
    {
        this.buildPlotLocation = buildPlotLocation;
        this.buildingType = buildingType;
        buildingModel = null;

        Debug.Log("build command created");
    }

    public override bool OnCreate()
    {
        return true;

        // nothing special for AddWorkerCommand
    }

    public override void Execute()
    {
        Debug.Log("build command executing");

        // Get required data on building

        BuildPlotController buildPlotController = GetBuildPlotController();
        buildingModel = BuildingModelFactory.Create(buildingType);
        ResourceTransaction transaction = buildingModel.buildCost;

        // Check if Building is possible

        // Plot isn't empty
        if (!buildPlotController.IsBuildable(buildPlotLocation))
        {
            Debug.LogError(string.Format("Error: there is already a building on {0}", buildPlotLocation));
            // abort
            return;
        }
        // transaction fails
        if (!PayOutTransaction(transaction))
        {
            // abort
            return;
        }

        // Success -> Build
        buildPlotController.Build(buildPlotLocation, buildingType, buildingModel);

        // -> update building
        // find controller -> will eventually be smoother

    }



}
