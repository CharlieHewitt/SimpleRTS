using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGatheringController
{
    private PlayerType playerType;

    public Dictionary<ResourceType, ResourceManagementView> resourceManagementViews;
    public IdleWorkerView idleView;

    public ResourceGatheringModel gatheringModel { get; private set; }

    public ResourceGatheringController(PlayerType playerType)
    {
        this.playerType = playerType;
        gatheringModel = new ResourceGatheringModel(playerType);
        InitialiseResourceManagementViews();
    }

    public bool AddWorker(ResourceType type)
    {
        bool success = gatheringModel.AddWorker(type);

        UpdateViews(type);

        return success;
    }

    public bool RemoveWorker(ResourceType type)
    {
        bool success = gatheringModel.RemoveWorker(type);
        UpdateViews(type);

        return success;
    }

    public void AddNewWorkers(int numWorkers)
    {
        gatheringModel.IncreaseWorkerCount(numWorkers);
        UpdateIdleWorkerView();
    }
    
    private void InitialiseResourceManagementViews()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

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

    private void UpdateViews(ResourceType type)
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }
        resourceManagementViews[type].UpdateText(gatheringModel.GetNumWorkers(type));
        idleView.UpdateText(gatheringModel.GetNumIdleWorkers());
    }

    private void UpdateIdleWorkerView()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }
        idleView.UpdateText(gatheringModel.GetNumIdleWorkers());

    }

}
