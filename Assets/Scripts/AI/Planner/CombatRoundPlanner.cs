using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class CombatRoundPlanner
{

    // Unit Priorities
    public UnitPriorities unitPriorities { get; private set; }

    // Planners
    public ArmyPlanner armyPlanner { get; private set; }
    public ResourcePlanner resourcePlanner { get; private set; }
    public BuildingPlanner buildingPlanner { get; private set; }

    public Queue<GameBehaviourCommand> commandQueue;

    public CombatRoundPlanner(UnitPriorities priorities)
    {
        armyPlanner = new ArmyPlanner();
        resourcePlanner = new ResourcePlanner();
        buildingPlanner = new BuildingPlanner();

        unitPriorities = priorities;

        commandQueue = new Queue<GameBehaviourCommand>();
    }

    // Resource check!!!!!!!!!
    public Queue<AI_GameBehaviourCommand> PlanCombatRound()
    {

        // Create empty queue
        Queue<AI_GameBehaviourCommand> commands = new Queue<AI_GameBehaviourCommand>();

        // Check Priorities
        if (!unitPriorities.CheckSum())
        {
            Debug.LogError("Priority checksum problem");
        };

        // Are we building a building?
        BuildingModel buildingModel = buildingPlanner.PlanBuilding(unitPriorities);

        // Which units do we want?
        UnitMap targetArmy = armyPlanner.GenerateTargetArmy(unitPriorities, buildingModel.type);

        // Calculate total cost
        int totalWood = CalculateTotalWoodCost();
        int totalMagicStone = CalculateTotalMagicStoneCost();

        // Set total cost
        resourcePlanner.SetRequiredResources(totalWood, totalMagicStone);

        // Worker Optimisation
        Dictionary<ResourceType, int> idealWorkerDistribution = resourcePlanner.CalculateIdealWorkerDistribution();

        // Resource Check -> Is it possible -> should always be yes


        // Get WorkerCommand Queue
        Queue<AI_GameBehaviourCommand> workerCommands = resourcePlanner.GetWorkerReassignmentCommands(idealWorkerDistribution);

        // Queue up worker commands
        int workerCommandCount = workerCommands.Count;
        for (int i = 0; i < workerCommandCount; i++)
        {
            commands.Enqueue(workerCommands.Dequeue());
        }

        // Get Building Command
        AI_GameBehaviourCommand buildingCommand = buildingPlanner.GetBuildingCommand(buildingModel);

        // Queue up Building Command
        if (buildingCommand != null)
        {
            commands.Enqueue(buildingCommand);
        }

        // Get Army Command Queue
        Queue<AI_GameBehaviourCommand> armyCommands = armyPlanner.GetArmyConstructionCommands(targetArmy, buildingModel.type);

        // Queue up army commands
        int armyCommandCount = armyCommands.Count;
        for (int i = 0; i < armyCommandCount; i++)
        {
            commands.Enqueue(armyCommands.Dequeue());
        }

        return commands;
    }

    public int CalculateTotalWoodCost()
    {
        return (armyPlanner.requiredWood + buildingPlanner.woodCost);
    }

    public int CalculateTotalMagicStoneCost()
    {
        return (armyPlanner.requiredMagicStone + buildingPlanner.magicStoneCost);
    }

    // Copy Constructor
    //public CombatRoundPlanner(CombatRoundPlanner combatRoundPlanner)
    //{
        
    //}








    // ++ RESOURCES>
    //public bool IsPlanPossibleInTimeFrame()
    //{

    //}




}