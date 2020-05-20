using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArmyPlanner
{
    // fields
    public int requiredWood { get; private set; }
    public int requiredMagicStone { get; private set; }
    public int remainingSupply { get; private set; }
    public UnitMap startingUnits { get; private set; }

    public ArmyPlanner()
    {
        requiredWood = 0;
        requiredMagicStone = 0;

        remainingSupply = GetArmyController().army.maxSupply - GetArmyController().army.currentSupply;
        startingUnits = new UnitMap(GetArmyController().army.unitMap);
    }

    // -------------------------------------------------------------------------------------------------------------------------------------------------------
    // Planning Stage

    // Check whether we can train this unit in this planning phase 
    public bool IsUnitTrainable(UnitType type, int remSupply, BuildingType plannedBuilding)
    {
        UnitPurchaseModel model = UnitPurchaseModelFactory.Create(type);

        bool prerequisite = GetBuildPlotController().IsComplete(model.prerequisite) || model.prerequisite == plannedBuilding;

        bool enoughSupply = remSupply >= model.armySize;

        return prerequisite && enoughSupply;
    }

    // generate target army for this combat phase
    public UnitMap GenerateTargetArmy(UnitPriorities unitPriorities, BuildingType plannedBuilding)
    {
        UnitMap targetArmy = new UnitMap(startingUnits);
        int remainingSupplyCopy = remainingSupply;

        // while army not full (won't cause any issues as all units currently have 1 or 2 as their supplyCost, may need changes in future)
        while (remainingSupplyCopy > 0)
        {
            UnitPurchaseModel model = null;

            while (model == null)
            {
                model = RandomlySelectUnit(unitPriorities);
            }

            UnitType type = model.unitType;
            if (IsUnitTrainable(type, remainingSupplyCopy, plannedBuilding))
            {
                requiredWood += model.buildCost.GetResourceAmount(ResourceType.WOOD);
                requiredMagicStone += model.buildCost.GetResourceAmount(ResourceType.MAGIC_STONE);
                remainingSupplyCopy -= model.armySize;

                targetArmy.Add(type);
            };
        }

        // check if supply has gone negative
        if (remainingSupplyCopy != 0)
        {
            Debug.LogError("supply < 0? (=" + remainingSupplyCopy + ")");
        }

        Debug.Log(targetArmy.StatusString());
        return targetArmy;
    }

    // Randomly selects a unit (weighted off their "priority")
    public UnitPurchaseModel RandomlySelectUnit(UnitPriorities unitPriorities)
    {

        // Generate random number
        float randomNumber = UnityEngine.Random.Range(0f, 3f);
        Debug.Log(string.Format("random number: {0}", randomNumber));


        // Priority Threshold guarantees that the current range maps only to the given type
        float priorityThreshold = 0;
        
        foreach(UnitType type in Enum.GetValues(typeof(UnitType)).Cast<UnitType>())
        {
            // update threshold
            priorityThreshold += unitPriorities.Get(type);

            // check if within threshold
            if (randomNumber <= priorityThreshold && unitPriorities.Get(type) != 0)
            {
                return UnitPurchaseModelFactory.Create(type);
            }
        }

        Debug.LogError("No available unit ...");
        return null;
    }

    // -------------------------------------------------------------------------------------------------------------------------------------------------------
    // Execution Phase

    // Gets command for given Unit type
    public GameBehaviourCommand GetUnitToAddToQueue(UnitType type)
    {
        UnitPurchaseModel model = UnitPurchaseModelFactory.Create(type);

        // update internal state

        startingUnits.Add(type);

        // add command to list
        return ArmyCommandFactory.CreateBuyUnitCommand(type, PlayerType.AI);
    }


    // queue up target army creation
    public Queue<AI_GameBehaviourCommand> GetArmyConstructionCommands(UnitMap targetMap, BuildingType plannedBuilding)
    {
        // calculate units that need to be trained
        Queue<AI_GameBehaviourCommand> armyCommands = new Queue<AI_GameBehaviourCommand>();
        UnitMap unitsToBeConstructed = startingUnits.UnitsRequiredToBecome(targetMap);
        Debug.Log(unitsToBeConstructed.StatusString());

        // iterate over required units and add the command to the queue
        foreach (KeyValuePair<UnitType, int> unitMapEntry in unitsToBeConstructed.units)
        {
            UnitType type = unitMapEntry.Key;
            UnitPurchaseModel model = UnitPurchaseModelFactory.Create(type);
            int numUnits = unitMapEntry.Value;

            while (numUnits > 0)
            {
                if (IsUnitTrainable(type, remainingSupply, plannedBuilding))
                {
                    GameBehaviourCommand command = GetUnitToAddToQueue(type);
                    AI_GameBehaviourCommand aiCommand = new AI_GameBehaviourCommand(command, model.buildCost);

                    armyCommands.Enqueue(aiCommand);
                    numUnits--;
                    remainingSupply -= model.armySize;
                }
                else
                {
                    Debug.LogError("Bad error -- cant create unit that was planned to be created");
                    break;
                }
            }
        }

        return armyCommands;
    }

    // ------------- Utility (Controller Access)

    private BuildPlotController GetBuildPlotController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).buildPlotController;
    }

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }

    private ArmyController GetArmyController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).armyController;
    }
}