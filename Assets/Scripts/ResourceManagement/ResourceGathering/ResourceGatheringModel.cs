using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// TODO: seperate worker from resource generation logic?
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
        resourceTicks = 25;

        // Might have to change this eventually for individual resource types but should be ok
        resourcesGeneratedPerWorker = 40;

        // workerMap
        InitialiseWorkerCounts();
        SubscribeToTickSystem();
    }

    public void InitialiseWorkerCounts()
    {
        workerCounts = new Dictionary<ResourceType, int>();

        // NOTE keep track of this variable, could get dangerous when num starting workers is modified!
        int startingWorkersPerResource = 5; 
        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
        {
            workerCounts.Add(type, startingWorkersPerResource);
        }
    }

    public void IncreaseWorkerCount(int numWorkers)
    {
        maxWorkers += numWorkers;
        idleWorkers += numWorkers;
    }


    public void SendResourcesToStore(ResourceTransaction transaction)
    {
        ResourceController resourceController = GameObject.Find("Resource System").GetComponent<ResourceController>();
        resourceController.PayInTransaction(transaction);
    }

    // event handler for gathering resources
    public void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        //Debug.Log(String.Format("event handler called {0}", e.tick));
        // TODO: See if using OnTick5 makes sense
        if (e.tick % resourceTicks == 0)
        {
            Debug.Log(GetWorkerStatusString());
            // send resources to store
            ResourceTransaction transaction = GeneratePayOutTransaction();

            Debug.Log(transaction.FormattedStatusString());
            SendResourcesToStore(transaction);
        }
    }

    public void SubscribeToTickSystem()
    {
        Debug.Log("ResourceSystem Subscribed");
        TimeTickSystem.OnTick += OnTick;
    }

    public void UnSubscribeFromTickSystem()
    {
        TimeTickSystem.OnTick -= OnTick;
    }

    public void AddWorker(ResourceType type)
    {
        // do validation
        if (idleWorkers <= 0)
        {
            Debug.LogError("Error reassigning worker. (No idle workers available)");
            return;
        }

        idleWorkers--;
        workerCounts[type]++;
    }

    public void RemoveWorker(ResourceType type)
    {
        if (workerCounts[type] <= 0)
        {
            Debug.LogError(string.Format("Error reassigning worker. (No workers are currently on {0}", type));
            return;
        }

        workerCounts[type]--;
        idleWorkers++;
    }

    public ResourceTransaction GeneratePayOutTransaction()
    {
        ResourceTransaction transaction = ResourceTransactionFactory.Create();

        foreach (var workerMapEntry in workerCounts)
        {
            ResourceType type = workerMapEntry.Key;
            int numWorkers = workerMapEntry.Value;

            ResourceCost cost = ResourceCostFactory.Create(workerMapEntry.Key, numWorkers *resourcesGeneratedPerWorker);
            transaction.AddResourceCost(cost);
        }

        return transaction;
    }

    public string GetWorkerStatusString()
    {
        string output = "Currently assigned workers:\n";

        foreach (var workerCount in workerCounts)
        {
            output += string.Format(" {0} ({1}) ", workerCount.Key, workerCount.Value);
        }

        if (idleWorkers > 0)
        {
            Debug.Log("Note: You have unassigned workers! Assign your idle workers to resources!");
        }

        return output;
    }
}
