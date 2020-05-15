using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingCommandFactory
{
    public static GameBehaviourCommand CreateConstructBuildingCommand(BuildPlotLocation plotLocation, BuildingType buildingType)
    {
        return new ConstructBuildingCommand(plotLocation, buildingType);
    }

    public static GameBehaviourCommand CreateDemolishCommand(BuildPlotLocation plotLocation) 
    {
        return new DemolishBuildingCommand(plotLocation);
    }

}
