using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Agent
{
    // Randomly Initialise these
    private UnitPriorities unitPriorities;
    private Queue<AI_GameBehaviourCommand> commandQueue;

    private bool waiting;
    private int waitedTicks;
    private int waitingForTicks;

    public AI_Agent()
    {
        waiting = false;
        waitedTicks = 0;
        waitingForTicks = 0;
        commandQueue = new Queue<AI_GameBehaviourCommand>();
        
        
        RandomlyInitialiseUnitPriorities();
        TimeTickSystem.OnTick += TryQueueNext_OnTick;
    }

    public void PlanRound()
    {
        CombatRoundPlanner planner = new CombatRoundPlanner(unitPriorities);
        commandQueue =  planner.PlanCombatRound();
    }

    public void TryQueueNext()
    {
        if (waiting || commandQueue.Count == 0)
        {
            return;
        }

        AI_GameBehaviourCommand aiCommand = commandQueue.Peek();

        bool possible = GetResourceController().IsTransactionPossible(aiCommand.transaction);

        if (possible)
        {
            aiCommand = commandQueue.Dequeue();

            GetGameBehaviourController().QueueUpCommand(aiCommand.command);
            if (aiCommand.waitForTicksAfterExecuting > 0)
            {
                waitedTicks = 0;
                waitingForTicks = aiCommand.waitForTicksAfterExecuting;
                waiting = true;
                TimeTickSystem.OnTick += WaitForTicks;
            }

            Debug.Log("AI: Queued up " + aiCommand.command.GetType());
        }
        else
        {
            Debug.Log("AI: Not enough resources");
        }
    }
    
    public void RandomlyInitialiseUnitPriorities()
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;

        while (x + y + z != 3f)
        {
            x = Random.Range(0f, 1f);
            y = Random.Range(0f, 1f);
            z = Random.Range(0f, 1f);

            float sum = x + y + z;

            float toBeFilled = (3f - sum);

            x += toBeFilled / 3f;
            y += toBeFilled / 3f;
            z += toBeFilled / 3f;
        }

        Debug.Log(string.Format("{0} {1} {2}", x, y, z));

        if (x + y + z != 3f)
        {
            Debug.LogError("x+y+z != 3 but = " + (float)(x + y + z));
        }

        unitPriorities = new UnitPriorities(x, y, z);
    }
    public void TryQueueNext_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        TryQueueNext();
    }

    // TimeTickSystem.OnTick event handler
    public void WaitForTicks(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (waitedTicks < waitingForTicks)
        {
            waitedTicks++;
        }
        else
        {
            waiting = false;
            Unsubscribe_WaitForTicks();
            Debug.Log("AI: wait stopped.");
        }
    }
    
    public void Unsubscribe_WaitForTicks()
    {
        TimeTickSystem.OnTick -= WaitForTicks;
    }

    public void Unsubscribe_TryQueueNext_OnTick()
    {
        TimeTickSystem.OnTick -= TryQueueNext_OnTick;
    }


    // Utility ----- (controller access)

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }

    private GameBehaviourCommandController GetGameBehaviourController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).gameBehaviourCommandController;
    }

    private ResourceController GetResourceController()
    {
        return GetGameController().GetPlayerModel(PlayerType.AI).resourceController;
    }
}
