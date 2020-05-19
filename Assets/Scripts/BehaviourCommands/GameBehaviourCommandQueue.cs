using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviourCommandQueue
{
    private Queue<GameBehaviourCommand> commandQueue;

    public GameBehaviourCommandQueue()
    {
        commandQueue = new Queue<GameBehaviourCommand>();
    }

    public void ExecuteNextCommand()
    {
        if (commandQueue.Count > 0)
        {
            GameBehaviourCommand nextCommand = commandQueue.Dequeue();
            nextCommand.Execute();
        }
    }

    public void QueueUpCommand(GameBehaviourCommand command)
    {
        commandQueue.Enqueue(command);
    }

    // try execute a command every game tick?

    // eventually potentially cancel commands ...

}
