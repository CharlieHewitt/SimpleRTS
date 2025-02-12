﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Wrapper around GameBehaviourCommand, storing information about what is needed for it to execute (to help AI control execution )
public class AI_GameBehaviourCommand
{
    public GameBehaviourCommand command { get; private set; }
    public ResourceTransaction transaction { get; private set; }
    public int waitForTicksAfterExecuting { get; private set; }

    // Commands without a resource cost/ enforced wait time after executing
    public AI_GameBehaviourCommand(GameBehaviourCommand command)
    {
        this.command = command;
        transaction = ResourceTransactionFactory.Create();
        waitForTicksAfterExecuting = 0;
    }

    // Commands with a resource cost, but without enforced wait time after executing
    public AI_GameBehaviourCommand(GameBehaviourCommand command, ResourceTransaction transaction)
    {
        this.command = command;
        this.transaction = transaction;
        waitForTicksAfterExecuting = 0;
    }

    // Commands with a resource cost and enforced wait time after executing
    public AI_GameBehaviourCommand(GameBehaviourCommand command, ResourceTransaction transaction, int ticksToWait)
    {
        this.command = command;
        this.transaction = transaction;
        waitForTicksAfterExecuting = ticksToWait;
    }
}