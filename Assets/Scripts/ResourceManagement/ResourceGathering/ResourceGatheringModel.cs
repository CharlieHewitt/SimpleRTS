using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceGatheringModel
{
    public Dictionary<ResourceType, int> workerCounts { get; private set; }

    // Worker variables
    public int idleWorkers { get; private set; }
    public int maxWorkers { get; private set; }

    // Resource variables
    public int resourceTicks { get; private set; }
    public int resourcesGeneratedPerWorker { get; private set; }

    public ResourceGatheringModel()
    {
        // initialise variables
        idleWorkers = 0;
        maxWorkers = 10;
        resourceTicks = 10;
        resourcesGeneratedPerWorker = 40;

        // workerMap
        InitialiseWorkerCounts();
    }

    public void InitialiseWorkerCounts()
    {
        workerCounts = new Dictionary<ResourceType, int>();

        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
        {
            workerCounts.Add(type, 0);
        }
    }

    public void IncreaseWorkerCount(int numWorkers)
    {
        maxWorkers += numWorkers;
        idleWorkers += numWorkers;
    }


    public void SendResourcesToStore(ResourceTransaction transaction)
    {
        // Perform Transaction
    }

    public void SubscribeToTickSystem()
    {
        // Subscribe to tick system for { resourceTicks }
    }

    public void TickEventHandler()
    {
        // Pay out resources
        ResourceTransaction transaction = GeneratePayOutTransaction();
        SendResourcesToStore(transaction);
    }

    public void AddWorker(ResourceType type)
    {
        // do validation
        workerCounts[type]++;
    }

    public void RemoveWorker(ResourceType type)
    {
        workerCounts[type]--;
    }

    public ResourceTransaction GeneratePayOutTransaction()
    {
        ResourceTransaction transaction = new ResourceTransaction(true);

        foreach (var workerMapEntry in workerCounts)
        {
            ResourceType type = workerMapEntry.Key;
            int numWorkers = workerMapEntry.Value;

            ResourceCost cost = ResourceCostFactory.Create(workerMapEntry.Key, numWorkers * resourcesGeneratedPerWorker);
            transaction.AddResourceCost(cost);
        }

        return transaction;
    }
}
