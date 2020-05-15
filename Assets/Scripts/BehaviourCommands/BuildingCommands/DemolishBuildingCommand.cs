﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolishBuildingCommand : GameBehaviourCommand
{
    private BuildPlotLocation buildPlotLocation;

    public DemolishBuildingCommand(BuildPlotLocation buildPlotLocation)
    {
        this.buildPlotLocation = buildPlotLocation;


        Debug.Log("demolish command created");
    }

    public override bool OnCreate()
    {
        return true;

        // nothing special for AddWorkerCommand
    }

    public override void Execute()
    {
        BuildPlotController buildPlotController = GetBuildPlotController();

        if (buildPlotController.IsDemolishable(buildPlotLocation))
        {
            buildPlotController.Demolish(buildPlotLocation);
        }
        else
        {
            Debug.LogError(string.Format("Can't demolish. There is no building at {0}", buildPlotLocation));
        }
    }

}