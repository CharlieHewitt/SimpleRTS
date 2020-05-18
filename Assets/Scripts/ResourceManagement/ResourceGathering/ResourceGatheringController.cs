using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGatheringController
{
    public Dictionary<ResourceType, ResourceManagementView> resourceManagementViews;
    public IdleWorkerView idleView;

    public ResourceGatheringModel gatheringModel { get; private set; }

    public ResourceGatheringController()
    {
        gatheringModel = new ResourceGatheringModel();
        InitialiseResourceManagementViews();
    }

    public void AddWorker(ResourceType type)
    {
        gatheringModel.AddWorker(type);

        UpdateViews(type);
    }

    public void RemoveWorker(ResourceType type)
    {
        gatheringModel.RemoveWorker(type);
        UpdateViews(type);
    }

    public void AddNewWorkers(int numWorkers)
    {
        gatheringModel.IncreaseWorkerCount(numWorkers);
    }
    
    public void InitialiseResourceManagementViews()
    {
        //idleview
        resourceManagementViews = new Dictionary<ResourceType, ResourceManagementView>();

        resourceManagementViews[ResourceType.WOOD] = GameObject.Find("WorkerPanel - Wood").GetComponent<ResourceManagementView>();
        resourceManagementViews[ResourceType.MAGIC_STONE] = GameObject.Find("WorkerPanel - Magic Stone").GetComponent<ResourceManagementView>();

        idleView = GameObject.Find("WorkerPanel - Idle").GetComponent<IdleWorkerView>();

        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
        {
            UpdateViews(type);
        }

    }

    public void UpdateViews(ResourceType type)
    {
        resourceManagementViews[type].UpdateText(gatheringModel.GetNumWorkers(type));
        idleView.UpdateText(gatheringModel.GetNumIdleWorkers());
    }

}
