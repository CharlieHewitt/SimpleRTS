using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;

public class BuildingPlanner
{
    public int woodCost { get; private set; }
    public int magicStoneCost { get; private set; }

    public BuildingPlanner()
    {
        woodCost = 0;
        magicStoneCost = 0;
    }


    public AI_GameBehaviourCommand GetBuildingCommand(BuildingModel model)
    {
        BuildPlotController buildPlotController = GetBuildPlotController();

        BuildingType buildingType = model.type;

        foreach (BuildPlotLocation location in Enum.GetValues(typeof(BuildPlotLocation)).Cast<BuildPlotLocation>())
        {
            BuildingType buildingOnPlot = buildPlotController.buildPlotMap.GetBuilding(location);

            if (buildingOnPlot == BuildingType.NONE)
            {
                GameBehaviourCommand command = BuildingCommandFactory.CreateConstructBuildingCommand(location, buildingType, PlayerType.AI);
                AI_GameBehaviourCommand aiCommand = new AI_GameBehaviourCommand(command, model.buildCost, model.constructionTime);
                return aiCommand;
            }
        }

        // No building commmand
        return null;

    }

    // Get highest priority not-already built building, returns null if all are built.
    public BuildingModel PlanBuilding(UnitPriorities unitPriorities)
    {
        // check if all buildings are built?
        // -> prevent unnecessary checks
        Dictionary<UnitType, float> priorities = unitPriorities.priorities;

        List<UnitType> unitTypesSortedByPriority = new List<UnitType>();

        UnitType maxPriorityType = UnitType.SWORDSMAN;
        float maxPriorityValue = -1f;

        // sort by priority
        while (unitTypesSortedByPriority.Count < priorities.Count)
        {
            foreach (KeyValuePair<UnitType, float> entry in priorities)
            {
                if (!unitTypesSortedByPriority.Contains(entry.Key) && entry.Value > maxPriorityValue)
                {
                    maxPriorityType = entry.Key;
                    maxPriorityValue = entry.Value;
                }
            }
            Debug.Log("adding " + maxPriorityType);
            unitTypesSortedByPriority.Add(maxPriorityType);

            maxPriorityValue = -1f;
        }

        // iterate over sorted list
        foreach (UnitType type in unitTypesSortedByPriority)
        {

            UnitPurchaseModel unitModel = UnitPurchaseModelFactory.Create(type);
            BuildingType buildingType = unitModel.prerequisite;

            if (!GetBuildPlotController().IsComplete(buildingType))
            {
                BuildingModel buildingModel = BuildingModelFactory.Create(buildingType);

                // Update resource costs
                woodCost = buildingModel.buildCost.GetResourceAmount(ResourceType.WOOD);
                magicStoneCost = buildingModel.buildCost.GetResourceAmount(ResourceType.MAGIC_STONE);

                return buildingModel;
            }
        }

        // No building to be built
        return null;
    }


    // -------------- Utility (Controller access)

    private BuildPlotController GetBuildPlotController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).buildPlotController;
    }

    private ResourceController GetResourceController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).resourceController;
    }

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }


}