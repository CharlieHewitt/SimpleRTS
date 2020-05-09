using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatheringController
{
    public ResourceGatheringModel gatheringModel { get; private set; }

    public ResourceGatheringController()
    {
        gatheringModel = new ResourceGatheringModel();
    }

    public void AddWorker(ResourceType type)
    {
        gatheringModel.AddWorker(type);
    }

    public void RemoveWorker(ResourceType type)
    {
        gatheringModel.RemoveWorker(type);
    }

    public void AddNewWorkers(int numWorkers)
    {
        gatheringModel.IncreaseWorkerCount(numWorkers);
    }
}
