using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingCommandFactory
{
    public static GameBehaviourCommand CreateConstructBuildingCommand(BuildPlotLocation plotLocation, BuildingType buildingType, PlayerType playerType)
    {
        return new ConstructBuildingCommand(plotLocation, buildingType, playerType);
    }

    public static GameBehaviourCommand CreateDemolishCommand(BuildPlotLocation plotLocation, PlayerType playerType) 
    {
        return new DemolishBuildingCommand(plotLocation, playerType);
    }

}
