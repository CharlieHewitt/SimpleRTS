using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedBuildPlotManager : MonoBehaviour
{
    public Dropdown dropdown;

    public Dictionary<BuildPlotLocation, BuildPlotView> buildPlotViews;

    private void Start()
    {
        InitialiseBuildPlotViewObjects();
        ShowSelectedBuildPlot();
        dropdown.onValueChanged.AddListener(delegate {
            ShowSelectedBuildPlot();
        });

    }

    public BuildPlotLocation ConvertStringToBuildPlotLocation(string text)
    {
        if(text == "North East")
        {
            return BuildPlotLocation.NORTH_EAST;
        }
        else if (text == "North West")
        {
            return BuildPlotLocation.NORTH_WEST;
        }
        else if (text == "South")
        {
            return BuildPlotLocation.SOUTH;
        }
        else // text == "West"
        {
            return BuildPlotLocation.WEST;
        }
    }

    public BuildPlotLocation GetSelectedLocation()
    {
        string dropdownText = dropdown.options[dropdown.value].text;
        return ConvertStringToBuildPlotLocation(dropdownText);
    }

    public void InitialiseBuildPlotViewObjects()
    {
        buildPlotViews = new Dictionary<BuildPlotLocation, BuildPlotView>();

        BuildPlotLocation location = ConvertStringToBuildPlotLocation("North East");
        buildPlotViews[ConvertStringToBuildPlotLocation("North East")] = GameObject.Find("BuildPlotPanel - NorthEast").GetComponent<BuildPlotView>();

        location = ConvertStringToBuildPlotLocation("North West");
        buildPlotViews[location] = GameObject.Find("BuildPlotPanel - NorthWest").GetComponent<BuildPlotView>();

        location = ConvertStringToBuildPlotLocation("South");
        buildPlotViews[location] = GameObject.Find("BuildPlotPanel - South").GetComponent<BuildPlotView>();

        location = ConvertStringToBuildPlotLocation("West");
        buildPlotViews[location] = GameObject.Find("BuildPlotPanel - West").GetComponent<BuildPlotView>();
    }

    public void ShowSelectedBuildPlot()
    {
        BuildPlotLocation selectedItem = GetSelectedLocation();

        foreach (KeyValuePair<BuildPlotLocation, BuildPlotView> entry in buildPlotViews)
        {
            if (selectedItem == entry.Key)
            {
                entry.Value.gameObject.SetActive(true);
            }
            else
            {
                entry.Value.gameObject.SetActive(false);
            }
        }
    }
}