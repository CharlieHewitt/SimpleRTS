using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Agent : MonoBehaviour
{
    // Randomly Initialise these
    private UnitPriorities unitPriorities;
    private CombatRoundPlanner planner;
    private bool initialised;
    private Queue<AI_GameBehaviourCommand> commandQueue;

    private bool waiting;
    private int waitedTicks;
    private int waitingForTicks;

    private void Awake()
    {
        initialised = false;
        waiting = false;
        waitedTicks = 0;
        waitingForTicks = 0;
        commandQueue = new Queue<AI_GameBehaviourCommand>();

        TimeTickSystem.OnTick += TryQueueNext_OnTick;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!initialised)
            {
                unitPriorities = new UnitPriorities(1, 1, 1);
                planner = new CombatRoundPlanner(unitPriorities);
                initialised = true;
            }

           commandQueue = planner.PlanCombatRound();

           foreach (AI_GameBehaviourCommand aiCommand in commandQueue)
            {
                Debug.Log("Q: " + aiCommand.command.GetType());
            }
        }
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
