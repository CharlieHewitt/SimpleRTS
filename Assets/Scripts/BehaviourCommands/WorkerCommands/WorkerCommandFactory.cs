using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorkerCommandFactory
{
    public static GameBehaviourCommand CreateAddWorkerCommand(ResourceType resourceType, PlayerType playerType)
    {
        return new AddWorkerCommand(resourceType, playerType);
    }

    public static GameBehaviourCommand CreateRemoveWorkerCommand(ResourceType resourceType, PlayerType playerType)
    {
        return new RemoveWorkerCommand(resourceType, playerType);
    }

}
