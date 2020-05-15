using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWorkerCommand : GameBehaviourCommand
{
    private ResourceType resourceType;

    public RemoveWorkerCommand(ResourceType resourceType)
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
        // remove worker
        GetResourceController().gatheringController.RemoveWorker(resourceType);

    }
}
