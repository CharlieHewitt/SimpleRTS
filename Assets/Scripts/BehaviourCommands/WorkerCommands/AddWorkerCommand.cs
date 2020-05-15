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

    public override bool OnCreate()
    {
        return true;
        // nothing special for AddWorkerCommand
    }

    public override void Execute()
    {
        // add worker
        GetResourceController().gatheringController.AddWorker(resourceType);
    }
}
