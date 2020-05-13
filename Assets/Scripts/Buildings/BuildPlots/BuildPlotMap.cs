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

    // TODO: implement status string iterator method

}


