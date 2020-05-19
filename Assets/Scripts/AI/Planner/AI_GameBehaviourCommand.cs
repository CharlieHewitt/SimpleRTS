using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AI_GameBehaviourCommand
{
    public GameBehaviourCommand command { get; private set; }
    public ResourceTransaction transaction { get; private set; }
    public int waitForTicksAfterExecuting { get; private set; }

    public AI_GameBehaviourCommand(GameBehaviourCommand command)
    {
        this.command = command;
        transaction = ResourceTransactionFactory.Create();
        waitForTicksAfterExecuting = 0;
    }

    public AI_GameBehaviourCommand(GameBehaviourCommand command, ResourceTransaction transaction)
    {
        this.command = command;
        this.transaction = transaction;
        waitForTicksAfterExecuting = 0;
    }

    public AI_GameBehaviourCommand(GameBehaviourCommand command, ResourceTransaction transaction, int ticksToWait)
    {
        this.command = command;
        this.transaction = transaction;
        waitForTicksAfterExecuting = ticksToWait;
    }
}