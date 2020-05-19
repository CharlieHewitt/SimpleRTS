using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWorkerCommand : GameBehaviourCommand
{
    private ResourceType resourceType;

    public RemoveWorkerCommand(ResourceType resourceType, PlayerType playerType)
    {
        this.playerType = playerType;
        this.resourceType = resourceType;
    }

    public override bool Execute()
    {
        // remove worker
        return GetResourceController().gatheringController.RemoveWorker(resourceType);
    }
}
