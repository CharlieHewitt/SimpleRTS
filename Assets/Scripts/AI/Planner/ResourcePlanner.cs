using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcePlanner
{
    public int requiredWood { get; private set; }
    public int requiredMagicStone { get; private set; }

    public ResourcePlanner()
    {
        requiredWood = 0;
        requiredMagicStone = 0;
    }

    public void SetRequiredResources(int wood, int magicStone)
    {
        requiredWood = wood;
        requiredMagicStone = magicStone;
    }

    public Dictionary<ResourceType, int> CalculateIdealWorkerDistribution()
    {
        // Get max number of workers
        int numWorkers = GetResourceController().gatheringController.gatheringModel.maxWorkers;


        float woodPercentage;
        // calculate % of workers to go on wood
        if (requiredMagicStone + requiredWood != 0)
        {
            woodPercentage = (float)requiredWood / (float)(requiredWood + requiredMagicStone);
        }
        else
        {
            woodPercentage = 0.5f;
        }

        // calculate actual numbers
        int woodWorkers = (int)(woodPercentage * numWorkers);
        int magicStoneWorkers = numWorkers - woodWorkers;

        Debug.Log(string.Format("{0} / ({1} + {0}) = wood {2} magicstone {3} ", requiredWood, requiredMagicStone, woodWorkers, magicStoneWorkers));

        // Output as Dictionary
        Dictionary<ResourceType, int> workerDistribution = new Dictionary<ResourceType, int>();

        workerDistribution[ResourceType.WOOD] = woodWorkers;
        workerDistribution[ResourceType.MAGIC_STONE] = magicStoneWorkers;

        return workerDistribution;
    }

    public Queue<AI_GameBehaviourCommand> GetWorkerReassignmentCommands(Dictionary<ResourceType, int> distribution)
    {

        // Queue to output
        Queue<AI_GameBehaviourCommand> commands = new Queue<AI_GameBehaviourCommand>();

        ResourceGatheringModel resourceGatheringModel = GetResourceController().gatheringController.gatheringModel;

        // current values
        int currWoodWorkers = resourceGatheringModel.GetNumWorkers(ResourceType.WOOD);
        int currMagicStoneWorkers = resourceGatheringModel.GetNumWorkers(ResourceType.MAGIC_STONE);
        int currIdleWorkers = resourceGatheringModel.GetNumIdleWorkers();


        // target values
        int targetWoodWorkers = distribution[ResourceType.WOOD];
        int targetMagicStoneWorkers = distribution[ResourceType.MAGIC_STONE];

        // differences
        int numWoodWorkersToAdd = targetWoodWorkers - currWoodWorkers;
        int numMagicStoneWorkersToAdd = targetMagicStoneWorkers - currMagicStoneWorkers;


        // Remove Wood Workers
        if (numWoodWorkersToAdd < 0)
        {
            for (int i = numWoodWorkersToAdd; i < 0; i++)
            {
                GameBehaviourCommand command = WorkerCommandFactory.CreateRemoveWorkerCommand(ResourceType.WOOD, PlayerType.AI);
                AI_GameBehaviourCommand aiCommand = new AI_GameBehaviourCommand(command);
                commands.Enqueue(aiCommand);
            }
        }
        
        // Remove Magic Stone Workers
        if (numMagicStoneWorkersToAdd < 0)
        {
            for (int i = numMagicStoneWorkersToAdd; i < 0; i++)
            {
                GameBehaviourCommand command = WorkerCommandFactory.CreateRemoveWorkerCommand(ResourceType.MAGIC_STONE, PlayerType.AI);
                AI_GameBehaviourCommand aiCommand = new AI_GameBehaviourCommand(command);
                commands.Enqueue(aiCommand);
            }
        }


        // Add Wood Workers
        if (numWoodWorkersToAdd > 0)
        {
            for (int i = 0; i < numWoodWorkersToAdd; i++)
            {
                GameBehaviourCommand command = WorkerCommandFactory.CreateAddWorkerCommand(ResourceType.WOOD, PlayerType.AI);
                AI_GameBehaviourCommand aiCommand = new AI_GameBehaviourCommand(command);
                commands.Enqueue(aiCommand);
            }
        }

        // Add Magic Stone Workers
        if (numMagicStoneWorkersToAdd > 0)
        {
            for (int i = 0; i < numMagicStoneWorkersToAdd; i++)
            {
                GameBehaviourCommand command = WorkerCommandFactory.CreateAddWorkerCommand(ResourceType.MAGIC_STONE, PlayerType.AI);
                AI_GameBehaviourCommand aiCommand = new AI_GameBehaviourCommand(command);
                commands.Enqueue(aiCommand);
            }
        }

        return commands;
    }

    // -------------- Utility (Controller access)

    private ResourceController GetResourceController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).resourceController;
    }

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }
}
