using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWorkerCommand : GameBehaviourCommand
{
    private ResourceType resourceType;

    public AddWorkerCommand(ResourceType resourceType)
    {
        this.resourceType = resourceType;
    }

    public override void OnCreate()
    {
        // nothing special for AddWorkerCommand
    }

    public override void Execute()
    {
        // find controller -> will eventually be smoother
        ResourceController resourceController = GameObject.Find("Resource System").GetComponent<ResourceController>();

        // add worker
        resourceController.gatheringController.AddWorker(resourceType);

    }
}
