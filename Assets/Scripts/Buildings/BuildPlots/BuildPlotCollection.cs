using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlotCollection
{
    private int numPlots;
    private BuildPlot[] buildPlots;

    public BuildPlotCollection(int initialNumPlots)
    {
        numPlots = initialNumPlots;
        buildPlots = new BuildPlot[numPlots];

        // TODO: Eventually change to have correct positions on initialisation!
        for (int i = 0; i < numPlots; i++)
        {
            buildPlots[i] = new BuildPlot(new Vector3(i,i));
        }
    }
    public string StatusString()
    {
        string output = "Building Plots:\n";

        foreach (BuildPlot plot in buildPlots)
        {
            output += plot.StatusString();
        }

        return output;
    }

}