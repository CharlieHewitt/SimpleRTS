using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructBuildingCommand : GameBehaviourCommand
{
    private BuildPlotLocation buildPlotLocation;
    private BuildingType buildingType;
    private BuildingModel buildingModel;

    public ConstructBuildingCommand(BuildPlotLocation buildPlotLocation, BuildingType buildingType, PlayerType playerType)
    {
        this.playerType = playerType;
        this.buildPlotLocation = buildPlotLocation;
        this.buildingType = buildingType;
        buildingModel = null;

        Debug.Log("build command created");
    }

    public override bool Execute()
    {
        Debug.Log("build command executing");

        // Get required data on building

        BuildPlotController buildPlotController = GetBuildPlotController();
        buildingModel = BuildingModelFactory.Create(buildingType);
        ResourceTransaction transaction = buildingModel.buildCost;

        // Check if constructing the building is possible

        // Building has already been constructed in another plot
        if (buildPlotController.IsBuilt(buildingType))
        {
            Debug.LogError(string.Format("Error: there is already a {0} on another plot.", buildingType));
            GetGameLogController().Log(string.Format("Error: there is already a {0} on another plot.", buildingType));

            //abort
            return false;
        }

        // Plot isn't empty
        if (!buildPlotController.IsBuildable(buildPlotLocation))
        {
            Debug.LogError(string.Format("Error: there is already a building on {0}", buildPlotLocation));
            GetGameLogController().Log(string.Format("Error: there is already a building on {0}", buildPlotLocation));


            // abort
            return false;
        }

        // transaction fails
        if (!PayOutTransaction(transaction))
        {
            // abort
            GetGameLogController().Log(string.Format("Error: not enough resources to construct {0}", buildingType));
            return false;
        }

        // Success -> Build
        buildPlotController.Build(buildPlotLocation, buildingType, buildingModel);

        return true;
    }



}
