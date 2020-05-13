using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructBuildingCommand : GameBehaviourCommand
{
    private BuildPlotLocation buildPlotLocation;
    private BuildingType buildingType;

    public ConstructBuildingCommand(BuildPlotLocation buildPlotLocation, BuildingType buildingType)
    {
        this.buildPlotLocation = buildPlotLocation;
        this.buildingType = buildingType;
    }

    public override void OnCreate()
    {
        // nothing special for AddWorkerCommand
    }

    public override void Execute()
    {
        BuildingModel model = BuildingModelFactory.Create(buildingType);

        WaitForTicks(model.constructionTime);

        // -> update building
        // find controller -> will eventually be smoother

    }
}
