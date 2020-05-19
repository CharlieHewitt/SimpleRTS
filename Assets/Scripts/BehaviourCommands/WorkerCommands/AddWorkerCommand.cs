using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWorkerCommand : GameBehaviourCommand
{
    private ResourceType resourceType;

    public AddWorkerCommand(ResourceType resourceType, PlayerType playerType)
    {
        this.playerType = playerType;
        this.resourceType = resourceType;
    }

    public override bool Execute()
    {
        // add worker
        return GetResourceController().gatheringController.AddWorker(resourceType);

        // Questionable
    }
}
