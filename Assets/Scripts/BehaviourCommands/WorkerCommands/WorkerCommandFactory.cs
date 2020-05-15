using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorkerCommandFactory
{
    public static GameBehaviourCommand CreateAddWorkerCommand(ResourceType resourceType)
    {
        return new AddWorkerCommand(resourceType);
    }

    public static GameBehaviourCommand CreateRemoveWorkerCommand(ResourceType resourceType)
    {
        return new RemoveWorkerCommand(resourceType);
    }

}
