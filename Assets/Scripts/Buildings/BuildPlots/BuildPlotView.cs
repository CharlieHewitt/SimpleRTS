using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPlotView : MonoBehaviour
{
    public BuildPlotLocation location;
    public Text currentBuildingType;
    public bool isUnderConstruction;

    public void UpdateCurrentBuilding(string currentBuilding)
    {
        currentBuildingType.text = string.Format("Current Building: {0} ({1})", currentBuilding, isUnderConstruction);
    }

    public void UpdateUnderConstruction(bool underConstruction)
    {
        isUnderConstruction = underConstruction;
    }
    // Implement selection logic! -> conditional show Build/ Demolish panels
}
