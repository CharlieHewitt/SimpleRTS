using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGatheringController
{
    public ResourceGatheringModel gatheringModel { get; private set; }

    public ResourceAmountView_Text textView;

    public ResourceGatheringController()
    {
        gatheringModel = new ResourceGatheringModel();
        textView = GameObject.Find("WorkerInfo").GetComponent<ResourceAmountView_Text>();
    }

    public void AddWorker(ResourceType type)
    {
        gatheringModel.AddWorker(type);
        textView.UpdateText(gatheringModel.GetWorkerStatusString());
    }

    public void RemoveWorker(ResourceType type)
    {
        gatheringModel.RemoveWorker(type);
        textView.UpdateText(gatheringModel.GetWorkerStatusString());
    }

    public void AddNewWorkers(int numWorkers)
    {
        gatheringModel.IncreaseWorkerCount(numWorkers);
    }
}
